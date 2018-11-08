using System;
using System.Collections;

using System.Collections.Generic;
using Geometry.Shapes;
using System.Linq;

namespace AStarFolder
{
    public class Graph
    {
        private double _resolution, _distanceMax;

        private List<Arc> _arcs, _tmpArcs;
        private List<Node> _nodes, _tmpNodes;

        public Graph(double resolution, double distanceMaxRaccordable)
        {
            _resolution = resolution;
            _distanceMax = distanceMaxRaccordable;

            _tmpArcs = new List<Arc>();
            _tmpNodes = new List<Node>();
            _arcs = new List<Arc>();
            _nodes = new List<Node>();
        }

        double Resolution { get { return _resolution; } }
        double DistanceMaxRaccordable { get { return _distanceMax; } }
        public IList<Node> Nodes { get { return _nodes; } }
        public IList<Arc> Arcs { get { return _arcs; } }

        public void Clear()
        {
            _nodes.Clear();
            _arcs.Clear();
        }

        /// <summary>
        /// Ajoute un noeud au graph en reliant tous les points à une distance maximale et en prenant en compte les obstacles à éviter
        /// Si permanent == false, le point sera supprimé au prochain appel de @CleanNodesArcsAdd
        /// </summary>
        /// <param name="node">Noeud à ajouter</param>
        /// <param name="obstacles">Obstacles à éviter</param>
        /// <param name="safeDistance">Distance (mm) de sécurité auour des obstacles</param>
        /// <param name="permnant">True si le point est ajouté de façon permanente et donc ne sera pas supprimé au prochain appel de @CleanNodesArcsAdd</param>
        /// <returns>Nombre de points reliés au point ajouté</returns>
        public int AddNode(Node node, IEnumerable<IShape> obstacles, double safeDistance, bool isPermanent = false)
        {
            // Si un noeud est deja présent à cet endroit on ne l'ajoute pas
            if (_nodes.Contains(node))
                return 0;

            // Teste si le noeud est franchissable avec la liste des obstacles
            if (obstacles.Any(o => o.Distance(node.Position) < safeDistance))
                return 0;

            _nodes.Add(node);
            if (!isPermanent) _tmpNodes.Add(node);

            int connections = 0;

            // Liaisons avec les autres noeuds du graph
            foreach (Node no in _nodes.Where(iNode => iNode != node
                                    && node.Position.Distance(iNode.Position) < _distanceMax
                                    && !obstacles.Any(iObstacle => iObstacle.Distance(new Segment(iNode.Position, node.Position)) < safeDistance)))
            {
                AddLiaison(node, no, node.Position.Distance(no.Position), isPermanent);
                connections++;
            }

            return connections;
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
            return _nodes.Any(iNode => iNode != node
                                && node.Position.Distance(iNode.Position) < _distanceMax
                                && !obstacles.Any(iObstacle => iObstacle.Distance(new Segment(iNode.Position, node.Position)) < distanceSecurite));
        }

        /// <summary>
        /// Nettoie les arcs et noeuds ajoutés temporairement
        /// </summary>
        public void CleanNodesArcsAdd()
        {
            foreach (Arc a in _tmpArcs)
                RemoveArc(a);
            _tmpArcs.Clear();

            foreach (Node n in _tmpNodes)
                RemoveNode(n);
            _tmpNodes.Clear();
        }

        public Arc AddArc(Node startNode, Node endNode, double weight, bool isPermanent)
        {
            Arc arc = new Arc(startNode, endNode);
            arc.Weight = weight;

            _arcs.Add(arc);
            if (!isPermanent) _tmpArcs.Add(arc);

            return arc;
        }

        public void AddLiaison(Node node1, Node node2, double weight, bool isPermanent)
        {
            AddArc(node1, node2, weight, isPermanent);
            AddArc(node2, node1, weight, isPermanent);
        }

        public void RemoveNode(Node node)
        {
            RemoveNodeAt(_nodes.IndexOf(node));
        }

        public void RemoveNodeAt(int index)
        {
            Node node = _nodes[index];

            foreach (Arc intput in node.IncomingArcs)
            {
                intput.StartNode.OutgoingArcs.Remove(intput);
                _arcs.Remove(intput);
            }
            foreach (Arc output in node.OutgoingArcs)
            {
                output.EndNode.IncomingArcs.Remove(output);
                _arcs.Remove(output);
            }

            _nodes.RemoveAt(index);
        }

        public void RemoveArc(Arc arc)
        {
            RemoveArcAt(_arcs.IndexOf(arc));
        }

        public void RemoveArcAt(int index)
        {
            Arc ArcToRemove = (Arc)_arcs[index];

                _arcs.RemoveAt(index);
                ArcToRemove.StartNode.OutgoingArcs.Remove(ArcToRemove);
                ArcToRemove.EndNode.IncomingArcs.Remove(ArcToRemove);
        }

        public Node ClosestNode(RealPoint p, out double distance)
        {
            Node closest = null;
            distance = double.MaxValue;

            foreach (Node node in _nodes.Where(o => o.Passable))
            {
                double currentDistance = node.Position.Distance(p);

                if (distance > currentDistance)
                {
                    distance = currentDistance;
                    closest = node;
                }
            }

            return closest;
        }
    }
}
