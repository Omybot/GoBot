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

        private ArrayList _nodes, _arcs;
        List<Arc> _tmpArcs = new List<Arc>();
        List<Node> _tmpNodes = new List<Node>();

        double Resolution { get { return _resolution; } }
        double DistanceMaxRaccordable { get { return _distanceMax; } }
        
        public Graph(double resolution, double distanceMaxRaccordable)
        {
            _resolution = resolution;
            _distanceMax = distanceMaxRaccordable;

            _nodes = new ArrayList();
            _arcs = new ArrayList();
        }
        
        public IList Nodes { get { return _nodes; } }
        public IList Arcs { get { return _arcs; } }
        
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
        /// <param name="distanceSecurite">Distance (mm) de sécurité auour des obstacles</param>
        /// <param name="permnant">True si le point est ajouté de façon permanente et donc ne sera pas supprimé au prochain appel de @CleanNodesArcsAdd</param>
        /// <returns>Nombre de points reliés au point ajouté</returns>
        public int AddNode(Node node, IEnumerable<IShape> obstacles, double distanceSecurite, bool isPermanent = false)
        {
            double distanceNode;

            // Si un noeud est deja présent à cet endroit on ne l'ajoute pas
            ClosestNode(node.X, node.Y, out distanceNode);
            if (distanceNode == 0)
                return 0;

            // Teste si le noeud est franchissable avec la liste des obstacles
            foreach (IShape obstacle in obstacles)
            {
                if (obstacle.Distance(node.Position) < distanceSecurite)
                {
                    node.Passable = false;
                    return 0;
                }
            }

            Nodes.Add(node);

            if(!isPermanent)
                _tmpNodes.Add(node);

            int nbLiaisons = 0;

            // Liaisons avec les autres noeuds du graph
            foreach (Node no in Nodes)
            {
                if (node != no)
                {
                    double distance = node.Position.Distance(no.Position);
                    if (distance < _distanceMax)
                    {
                        bool ok = true;

                        foreach (IShape obstacle in obstacles)
                        {
                            if (obstacle.Distance(new Segment(no.Position, node.Position)) < distanceSecurite)
                            {
                                ok = false;
                                break;
                            }
                        }

                        if (ok)
                        {
                            AddLiaison(node, no, Math.Sqrt(distance), isPermanent);
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
                    double distance = node.Position.Distance(no.Position);
                    if (distance < _distanceMax)
                    {
                        ok = (obstacles.FirstOrDefault(o => o.Distance(new Segment(no.Position, node.Position)) < distanceSecurite) == null);
                        
                        if (ok)
                            return true;
                    }
                }
            }

            return false;
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
        
        public bool AddArc(Arc NewArc)
        {
            //if ( NewArc==null || LA.Contains(NewArc) ) return false;
            if (NewArc == null) return false;

            //if (!_nodes.Contains(NewArc.StartNode) || !_nodes.Contains(NewArc.EndNode))
            //    throw new ArgumentException("Cannot add an arc if one of its extremity nodes does not belong to the graph.");
            _arcs.Add(NewArc);
            return true;
        }

        public Arc AddArc(Node StartNode, Node EndNode, double Weight, bool isPermanent)
        {
            Arc NewArc = new Arc(StartNode, EndNode);
            if(!isPermanent) _tmpArcs.Add(NewArc);

            NewArc.Weight = Weight;
            return AddArc(NewArc) ? NewArc : null;
        }

        public void AddLiaison(Node Node1, Node Node2, double Weight, bool isPermanent)
        {
            AddArc(Node1, Node2, Weight, isPermanent);
            AddArc(Node2, Node1, Weight, isPermanent);
        }

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

        public bool RemoveNodeAt(int index)
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

        public bool RemoveArcAt(int index)
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

        public Node ClosestNode(double PtX, double PtY, out double Distance)
        {
            Node NodeMin = null;
            double DistanceMin = -1;
            RealPoint P = new RealPoint(PtX, PtY);
            foreach (Node node in _nodes)
            {
                if (node.Passable == false) continue;
                double DistanceTemp = node.Position.Distance(P);
                if (DistanceMin == -1 || DistanceMin > DistanceTemp)
                {
                    DistanceMin = DistanceTemp;
                    NodeMin = node;
                }
            }
            Distance = DistanceMin;
            return NodeMin;
        }
    }
}
