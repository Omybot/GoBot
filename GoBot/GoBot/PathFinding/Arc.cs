using System;

namespace AStarFolder
{
    public class Arc
    {
        private Node _startNode;
        private Node _endNode;

        private bool _passable;
        private double _length;
        
        public Arc(Node Start, Node End)
        {
            StartNode = Start;
            EndNode = End;
            _length = _startNode.Position.Distance(_endNode.Position);
            _passable = true;
        }

        public Node StartNode
        {
            set
            {
                if(_startNode != null) _startNode.OutgoingArcs.Remove(this);
                _startNode = value;
                _startNode.OutgoingArcs.Add(this);
            }
            get { return _startNode; }
        }
        
        public Node EndNode
        {
            set
            {
                if (_endNode != null) _endNode.IncomingArcs.Remove(this);
                _endNode = value;
                _endNode.IncomingArcs.Add(this);
            }
            get { return _endNode; }
        }
        
        public bool Passable
        {
            set { _passable = value; }
            get { return _passable; }
        }
        
        public double Length
        {
            get
            {
                return _length;
            }
        }
        
        virtual public double Cost
        {
            get { return Math.Sqrt(_length); }
        }
        
        public override string ToString()
        {
            return _startNode.ToString() + "-->" + _endNode.ToString();
        }
        
        public override bool Equals(object o)
        {
            Arc arc = (Arc)o;
            
            return arc != null && _startNode.Equals(arc._startNode) && _endNode.Equals(arc._endNode);
        }
        
        public override int GetHashCode()
        {
            return _startNode.GetHashCode() + _endNode.GetHashCode();
        }
    }
}

