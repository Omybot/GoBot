// Copyright 2003 Eric Marchesin - <eric.marchesin@laposte.net>
//
// This source file(s) may be redistributed by any means PROVIDING they
// are not sold for profit without the authors expressed written consent,
// and providing that this notice and the authors name and all copyright
// notices remain intact.
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED. USE IT AT YOUR OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//-----------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AStarFolder
{
    /// <summary>
    /// A heuristic is a function that associates a value with a node to gauge it considering the node to reach.
    /// </summary>
    public delegate double Heuristic(Node NodeToEvaluate, Node TargetNode);

    /// <summary>
    /// Class to search the best path between two nodes on a graph.
    /// </summary>
    public class AStar
    {
        Graph _graph;
        Tracks _open;
        Dictionary<Node, Track> _closedTracks;
        Dictionary<Node, Track> _openTracks;
        Track _LeafToGoBackUp;
        int _iterations = -1;
        
        /// <summary>
        /// Heuristic based on the euclidian distance : Sqrt(Dx²+Dy²)
        /// </summary>
        public static Heuristic EuclidianHeuristic
        { get { return new Heuristic(Node.EuclidianDistance); } }
        
        /// <summary>
        /// Gets/Sets the heuristic that AStar will use.
        /// It must be homogeneous to arc's cost.
        /// </summary>
        public Heuristic ChoosenHeuristic
        {
            get { return Track.ChoosenHeuristic; }
            set { Track.ChoosenHeuristic = value; }
        }

        /// <summary>
        /// This value must belong to [0; 1] and it determines the influence of the heuristic on the algorithm.
        /// If this influence value is set to 0, then the search will behave in accordance with the Dijkstra algorithm.
        /// If this value is set to 1, then the cost to come to the current node will not be used whereas only the heuristic will be taken into account.
        /// </summary>
        /// <exception cref="ArgumentException">Value must belong to [0;1].</exception>
        public double DijkstraHeuristicBalance
        {
            get { return Track.DijkstraHeuristicBalance; }
            set
            {
                if (value < 0 || value > 1) throw new ArgumentException("DijkstraHeuristicBalance value must belong to [0;1].");
                Track.DijkstraHeuristicBalance = value;
            }
        }

        /// <summary>
        /// AStar Constructor.
        /// </summary>
        /// <param name="graph">The graph on which AStar will perform the search.</param>
        public AStar(Graph graph)
        {
            _graph = graph;
            _open = new Tracks();
            _openTracks = new Dictionary<Node, Track>();
            _closedTracks = new Dictionary<Node, Track>();
            ChoosenHeuristic = EuclidianHeuristic;
            DijkstraHeuristicBalance = 0.5;
        }

        /// <summary>
        /// Searches for the best path to reach the specified EndNode from the specified StartNode.
        /// </summary>
        /// <exception cref="ArgumentNullException">StartNode and EndNode cannot be null.</exception>
        /// <param name="startNode">The node from which the path must start.</param>
        /// <param name="endNode">The node to which the path must end.</param>
        /// <returns>'true' if succeeded / 'false' if failed.</returns>
        public bool SearchPath(Node startNode, Node endNode)
        {
            //lock (_graph)
            //{
                Initialize(startNode, endNode);
                while (NextStep()) { }
                return PathFound;
            //}
        }

        /// <summary>
        /// Use for a 'step by step' search only. This method is alternate to SearchPath.
        /// Initializes AStar before performing search steps manually with NextStep.
        /// </summary>
        /// <exception cref="ArgumentNullException">StartNode and EndNode cannot be null.</exception>
        /// <param name="StartNode">The node from which the path must start.</param>
        /// <param name="EndNode">The node to which the path must end.</param>
        protected void Initialize(Node StartNode, Node EndNode)
        {
            if (StartNode == null || EndNode == null) throw new ArgumentNullException();
            _closedTracks.Clear();
            _open.Clear();
            _openTracks.Clear();
            Track.Target = EndNode;
            Track newTrack = new Track(StartNode);
            _open.Add(newTrack);
            _openTracks.Add(StartNode, newTrack);
            _iterations = 0;
            _LeafToGoBackUp = null;
        }
        
        /// <summary>
        /// Use for a 'step by step' search only. This method is alternate to SearchPath.
        /// The algorithm must have been initialize before.
        /// </summary>
        /// <exception cref="InvalidOperationException">You must initialize AStar before using NextStep().</exception>
        /// <returns>'true' unless the search ended.</returns>
        protected bool NextStep()
        {
            if (_open.Count == 0) return false;
            _iterations++;
           // Console.WriteLine("_iterations : " + _iterations.ToString());
           
            Track bestTrack = _open[0];

            if (GoBot.Config.CurrentConfig.AfficheDetailTraj > 0)
            {
                GoBot.Dessinateur.CurrentTrack = bestTrack;
                System.Threading.Thread.Sleep(GoBot.Config.CurrentConfig.AfficheDetailTraj);
            }

            _open.RemoveAt(0);
            _openTracks.Remove(bestTrack.EndNode);

            if (bestTrack.Succeed)
            {
                _LeafToGoBackUp = bestTrack;
                _open.Clear();
                _openTracks.Clear();
            }
            else
            {
                Propagate(bestTrack);
            }

            return (_open.Count > 0);
        }

        private void Propagate(Track TrackToPropagate)
        {
            _closedTracks[TrackToPropagate.EndNode] = TrackToPropagate;
            
            foreach (Arc arc in TrackToPropagate.EndNode.OutgoingArcs)
            {
                if (arc.Passable && arc.EndNode.Passable)
                {
                    Track successor = new Track(TrackToPropagate, arc);
                    Track trackInClose, trackInOpen;

                    _closedTracks.TryGetValue(successor.EndNode, out trackInClose);
                    _openTracks.TryGetValue(successor.EndNode, out trackInOpen);

                    if (trackInClose != null && successor.Cost >= trackInClose.Cost)
                        continue;
                    if (trackInOpen != null && successor.Cost >= trackInOpen.Cost)
                        continue;

                    if (trackInClose != null)
                    {
                        _closedTracks.Remove(successor.EndNode);
                    }
                    if (trackInOpen != null)
                    {
                        _open.Remove(trackInOpen);
                    }

                    _open.Add(successor);
                    _openTracks[successor.EndNode] = successor;
                }
            }
        }
        
        /// <summary>
        /// To know if a path has been found.
        /// </summary>
        public bool PathFound { get { return _LeafToGoBackUp != null; } }

        /// <summary>
        /// Use for a 'step by step' search only.
        /// Gets the number of the current step.
        /// -1 if the search has not been initialized.
        /// 0 if it has not been started.
        /// </summary>
        public int StepCounter { get { return _iterations; } }
        
        /// <summary>
        /// Gets the array of nodes representing the found path.
        /// </summary>
        /// <exception cref="InvalidOperationException">You cannot get a result unless the search has ended.</exception>
        public Node[] PathByNodes
        {
            get
            {
                if (!PathFound) return null;
                return GoBackUpNodes(_LeafToGoBackUp);
            }
        }

        private Node[] GoBackUpNodes(Track T)
        {
            int Nb = T.NbArcsVisited;
            Node[] Path = new Node[Nb + 1];
            for (int i = Nb; i >= 0; i--, T = T.Queue)
                Path[i] = T.EndNode;
            return Path;
        }
    }
}

