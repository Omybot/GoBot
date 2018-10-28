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

using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using GoBot;
using Geometry.Shapes;
using System.Threading;
using System.Linq;

namespace AStarFolder
{
    /// <summary>
    /// Graph structure. It is defined with :
    /// It is defined with both a list of nodes and a list of arcs.
    /// </summary>
    [Serializable]
    public class Graph
    {
        private double _resolution, _distanceMax;

        private ArrayList _nodes, _arcs;

        double Resolution { get { return _resolution; } }
        double DistanceMaxRaccordable { get { return _distanceMax; } }


        /// <summary>
        /// Constructor.
        /// </summary>
        public Graph(double resolution, double distanceMaxRaccordable)
        {
            _resolution = resolution;
            _distanceMax = distanceMaxRaccordable;

            _nodes = new ArrayList();
            _arcs = new ArrayList();
        }

        /// <summary>
        /// Gets the List interface of the nodes in the graph.
        /// </summary>
        public IList Nodes { get { return _nodes; } }

        /// <summary>
        /// Gets the List interface of the arcs in the graph.
        /// </summary>
        public IList Arcs { get { return _arcs; } }

        /// <summary>
        /// Empties the graph.
        /// </summary>
        public void Clear()
        {
            _nodes.Clear();
            _arcs.Clear();
        }

        /// <summary>
        /// Directly Adds a node to the graph.
        /// </summary>
        /// <param name="NewNode">The node to add.</param>
        /// <returns>'true' if it has actually been added / 'false' if the node is null or if it is already in the graph.</returns>
        public bool AddNode(Node NewNode)
        {
            //if ( NewNode==null || LN.Contains(NewNode) ) return false;
            _nodes.Add(NewNode);
            return true;
        }

        /// <summary>
        /// Creates a node, adds to the graph and returns its reference.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <returns>The reference of the new node / null if the node is already in the graph.</returns>
        public Node AddNode(float x, float y, float z)
        {
            Node NewNode = new Node(x, y, z);
            return AddNode(NewNode) ? NewNode : null;
        }

        /// <summary>
        /// Ajoute un noeud au graph en reliant tous les points à une distance maximale et en prenant en compte les obstacles à éviter
        /// Si permanent == false, le point sera supprimé au prochain appel de @CleanNodesArcsAdd
        /// </summary>
        /// <param name="node">Noeud à ajouter</param>
        /// <param name="obstacles">Obstacles à éviter</param>
        /// <param name="distanceSecurite">Distance (mm) de sécurité auour des obstacles</param>
        /// <param name="permnant">True si le point est ajouté de façon permanente et donc ne sera pas supprimé au prochain appel de @CleanNodesArcsAdd</param>
        /// <returns>Nombre de points reliés au point ajouté</returns>
        public int AddNode(Node node, IEnumerable<IShape> obstacles, double distanceSecurite, bool permanent = false)
        {
            double distanceNode;

            // Si un noeud est deja présent à cet endroit on ne l'ajoute pas
            ClosestNode(node.X, node.Y, node.Z, out distanceNode, true);
            if (distanceNode == 0)
                return 0;

            // Teste si le noeud est franchissable avec la liste des obstacles
            foreach (IShape obstacle in obstacles)
            {
                if (obstacle.Distance(new RealPoint(node.X, node.Y)) < distanceSecurite)
                {
                    node.Passable = false;
                    return 0;
                }
            }

            Nodes.Add(node);

            if(!permanent)
                nodesAdd.Add(node);

            int nbLiaisons = 0;

            // Liaisons avec les autres noeuds du graph
            foreach (Node no in Nodes)
            {
                if (node != no)
                {
                    double distance = new RealPoint(node.Position.X, node.Position.Y).Distance(new RealPoint(no.Position.X, no.Position.Y));
                    if (distance < _distanceMax)
                    {
                        Arc arc = new Arc(no, node);
                        arc.Weight = Math.Sqrt(distance);
                        Arc arc2 = new Arc(node, no);
                        arc2.Weight = Math.Sqrt(distance);

                        foreach (IShape obstacle in obstacles)
                        {
                            if (obstacle.Distance(new Segment(new RealPoint(no.X, no.Y), new RealPoint(node.X, node.Y))) < distanceSecurite)
                            {
                                arc.Passable = false;
                                arc2.Passable = false;
                                break;
                            }
                        }

                        if (arc.Passable)
                        {
                            AddArc(arc);
                            AddArc(arc2);

                            if (!permanent)
                            {
                                arcsAdd.Add(arc);
                                arcsAdd.Add(arc2);
                            }

                            nbLiaisons++;
                        }
                    }
                }
            }

            return nbLiaisons;
        }

        /// <summary>
        /// Retourne vrai si le noeud peut se lier avec au moins un autre noeud du graph
        /// </summary>
        /// <param name="node"></param>
        /// <param name="obstacles"></param>
        /// <param name="distanceSecurite"></param>
        /// <param name="distanceMax"></param>
        /// <returns></returns>
        public bool Raccordable(Node node, IEnumerable<IShape> obstacles, double distanceSecurite)
        {
            bool ok;

            foreach (Node no in Nodes)
            {
                if (!node.Equals(no))
                {
                    double distance = new RealPoint(node.Position.X, node.Position.Y).Distance(new RealPoint(no.Position.X, no.Position.Y));
                    if (distance < _distanceMax)
                    {
                        ok = (obstacles.FirstOrDefault(o => o.Distance(new Segment(new RealPoint(no.X, no.Y), new RealPoint(node.X, node.Y))) < distanceSecurite) == null);
                        
                        if (ok)
                            return true;
                    }
                }
            }

            return false;
        }

        List<Arc> arcsAdd = new List<Arc>();
        List<Node> nodesAdd = new List<Node>();

        /// <summary>
        /// Nettoie les arcs et noeuds ajoutés temporairement
        /// </summary>
        public void CleanNodesArcsAdd()
        {
            foreach (Arc a in arcsAdd)
                RemoveArc(a);
            arcsAdd.Clear();

            foreach (Node n in nodesAdd)
                RemoveNode(n);
            nodesAdd.Clear();
        }

        /// <summary>
        /// Directly Adds an arc to the graph.
        /// </summary>
        /// <exception cref="ArgumentException">Cannot add an arc if one of its extremity nodes does not belong to the graph.</exception>
        /// <param name="NewArc">The arc to add.</param>
        /// <returns>'true' if it has actually been added / 'false' if the arc is null or if it is already in the graph.</returns>
        public bool AddArc(Arc NewArc)
        {
            //if ( NewArc==null || LA.Contains(NewArc) ) return false;
            if (NewArc == null) return false;

            if (!_nodes.Contains(NewArc.StartNode) || !_nodes.Contains(NewArc.EndNode))
                throw new ArgumentException("Cannot add an arc if one of its extremity nodes does not belong to the graph.");
            _arcs.Add(NewArc);
            return true;
        }

        /// <summary>
        /// Creates an arc between two nodes that are already registered in the graph, adds it to the graph and returns its reference.
        /// </summary>
        /// <exception cref="ArgumentException">Cannot add an arc if one of its extremity nodes does not belong to the graph.</exception>
        /// <param name="StartNode">Start node for the arc.</param>
        /// <param name="EndNode">End node for the arc.</param>
        /// <param name="Weight">Weight for the arc.</param>
        /// <returns>The reference of the new arc / null if the arc is already in the graph.</returns>
        public Arc AddArc(Node StartNode, Node EndNode, float Weight)
        {
            Arc NewArc = new Arc(StartNode, EndNode);
            NewArc.Weight = Weight;
            return AddArc(NewArc) ? NewArc : null;
        }

        /// <summary>
        /// Adds the two opposite arcs between both specified nodes to the graph.
        /// </summary>
        /// <exception cref="ArgumentException">Cannot add an arc if one of its extremity nodes does not belong to the graph.</exception>
        /// <param name="Node1"></param>
        /// <param name="Node2"></param>
        /// <param name="Weight"></param>
        public void Add2Arcs(Node Node1, Node Node2, float Weight)
        {
            AddArc(Node1, Node2, Weight);
            AddArc(Node2, Node1, Weight);
        }

        /// <summary>
        /// Removes a node from the graph as well as the linked arcs.
        /// </summary>
        /// <param name="NodeToRemove">The node to remove.</param>
        /// <returns>'true' if succeeded / 'false' otherwise.</returns>
        public bool RemoveNode(Node NodeToRemove)
        {
            if (NodeToRemove == null) return false;
            try
            {
                foreach (Arc A in NodeToRemove.IncomingArcs)
                {
                    A.StartNode.OutgoingArcs.Remove(A);
                    _arcs.Remove(A);
                }
                foreach (Arc A in NodeToRemove.OutgoingArcs)
                {
                    A.EndNode.IncomingArcs.Remove(A);
                    _arcs.Remove(A);
                }
                _nodes.Remove(NodeToRemove);
            }
            catch { return false; }
            return true;
        }

        public bool RemoveNode(int index)
        {
            if (index < 0 || index > _nodes.Count) return false;
            try
            {
                Node NodeToRemove = (Node)_nodes[index];
                foreach (Arc A in NodeToRemove.IncomingArcs)
                {
                    A.StartNode.OutgoingArcs.Remove(A);
                    _arcs.Remove(A);
                }
                foreach (Arc A in NodeToRemove.OutgoingArcs)
                {
                    A.EndNode.IncomingArcs.Remove(A);
                    _arcs.Remove(A);
                }
                _nodes.RemoveAt(index);
            }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// Removes a node from the graph as well as the linked arcs.
        /// </summary>
        /// <param name="ArcToRemove">The arc to remove.</param>
        /// <returns>'true' if succeeded / 'false' otherwise.</returns>
        public bool RemoveArc(Arc ArcToRemove)
        {
            if (ArcToRemove == null) return false;
            try
            {
                _arcs.Remove(ArcToRemove);
                ArcToRemove.StartNode.OutgoingArcs.Remove(ArcToRemove);
                ArcToRemove.EndNode.IncomingArcs.Remove(ArcToRemove);
            }
            catch { return false; }
            return true;
        }

        public bool RemoveArc(int index)
        {
            Arc ArcToRemove = (Arc)_arcs[index];
            if (ArcToRemove == null) return false;
            try
            {
                _arcs.RemoveAt(index);
                ArcToRemove.StartNode.OutgoingArcs.Remove(ArcToRemove);
                ArcToRemove.EndNode.IncomingArcs.Remove(ArcToRemove);
            }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// Determines the bounding box of the entire graph.
        /// </summary>
        /// <exception cref="InvalidOperationException">Impossible to determine the bounding box for this graph.</exception>
        /// <param name="MinPoint">The point of minimal coordinates for the box.</param>
        /// <param name="MaxPoint">The point of maximal coordinates for the box.</param>
        public void BoundingBox(out double[] MinPoint, out double[] MaxPoint)
        {
            try
            {
                Node.BoundingBox(Nodes, out MinPoint, out MaxPoint);
            }
            catch (ArgumentException e)
            { throw new InvalidOperationException("Impossible to determine the bounding box for this graph.\n", e); }
        }

        /// <summary>
        /// This function will find the closest node from a geographical position in space.
        /// </summary>
        /// <param name="PtX">X coordinate of the point from which you want the closest node.</param>
        /// <param name="PtY">Y coordinate of the point from which you want the closest node.</param>
        /// <param name="PtZ">Z coordinate of the point from which you want the closest node.</param>
        /// <param name="Distance">The distance to the closest node.</param>
        /// <param name="IgnorePassableProperty">if 'false', then nodes whose property Passable is set to false will not be taken into account.</param>
        /// <returns>The closest node that has been found.</returns>
        public Node ClosestNode(double PtX, double PtY, double PtZ, out double Distance, bool IgnorePassableProperty)
        {
            Node NodeMin = null;
            double DistanceMin = -1;
            Point3D P = new Point3D(PtX, PtY, PtZ);
            foreach (Node N in _nodes)
            {
                if (!IgnorePassableProperty && N.Passable == false) continue;
                double DistanceTemp = Point3D.DistanceBetween(N.Position, P);
                if (DistanceMin == -1 || DistanceMin > DistanceTemp)
                {
                    DistanceMin = DistanceTemp;
                    NodeMin = N;
                }
            }
            Distance = DistanceMin;
            return NodeMin;
        }

        /// <summary>
        /// This function will find the closest arc from a geographical position in space using projection.
        /// </summary>
        /// <param name="PtX">X coordinate of the point from which you want the closest arc.</param>
        /// <param name="PtY">Y coordinate of the point from which you want the closest arc.</param>
        /// <param name="PtZ">Z coordinate of the point from which you want the closest arc.</param>
        /// <param name="Distance">The distance to the closest arc.</param>
        /// <param name="IgnorePassableProperty">if 'false', then arcs whose property Passable is set to false will not be taken into account.</param>
        /// <returns>The closest arc that has been found.</returns>
        public Arc ClosestArc(double PtX, double PtY, double PtZ, out double Distance, bool IgnorePassableProperty)
        {
            Arc ArcMin = null;
            double DistanceMin = -1;
            Point3D P = new Point3D(PtX, PtY, PtZ);
            foreach (Arc A in _arcs)
            {
                if (IgnorePassableProperty && A.Passable == false) continue;
                Point3D Projection = Point3D.ProjectOnLine(P, A.StartNode.Position, A.EndNode.Position);
                double DistanceTemp = Point3D.DistanceBetween(P, Projection);
                if (DistanceMin == -1 || DistanceMin > DistanceTemp)
                {
                    DistanceMin = DistanceTemp;
                    ArcMin = A;
                }
            }
            Distance = DistanceMin;
            return ArcMin;
        }
    }
}
