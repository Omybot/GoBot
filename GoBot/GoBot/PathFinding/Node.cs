using Geometry.Shapes;
using System;
using System.Collections.Generic;


namespace AStarFolder
{
	public class Node
	{
        RealPoint _pos;
		bool _passable;
        
        List<Arc> _incomingArcs;
        List<Arc> _outgoingArcs;
        
        public Node()
        {
            _pos = new RealPoint();
            _passable = true;
            _incomingArcs = new List<Arc>();
            _outgoingArcs = new List<Arc>();
        }

        public Node(RealPoint pos) : this()
        {
            _pos = new RealPoint(pos);
        }

        public Node(double x, double y) : this(new RealPoint(x, y))
        {
        }
        
		public List<Arc> IncomingArcs { get { return _incomingArcs; } }
        
		public List<Arc> OutgoingArcs { get { return _outgoingArcs; } }
        
		public bool Passable
		{
			set
			{
				foreach (Arc A in _incomingArcs) A.Passable = value;
				foreach (Arc A in _outgoingArcs) A.Passable = value;
				_passable = value;
			}
			get
            {
                return _passable;
            }
		}
        
		public double X { get { return _pos.X; } }
        
		public double Y { get { return _pos.Y; } }
        
        public RealPoint Position { get { return _pos; } }
        
		public override string ToString()
        {
            return _pos.ToString();
        }
        
		public override bool Equals(object o)
		{
			Node other = (Node)o;

            return (other != null) && (_pos == other.Position);
		}
        
		public override int GetHashCode()
        {
            return _pos.GetHashCode();
        }
        
		public static double EuclidianDistance(Node n1, Node n2)
		{
			return Math.Sqrt( SquareEuclidianDistance(n1, n2) );
		}
        
		public static double SquareEuclidianDistance(Node n1, Node n2)
		{
			if ( n1==null || n2==null ) throw new ArgumentNullException();
			double DX = n1.X - n2.X;
			double DY = n1.Y - n2.Y;
			return DX*DX+DY*DY;
		}
	}
}

