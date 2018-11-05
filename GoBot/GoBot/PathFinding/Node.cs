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
using Geometry.Shapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace AStarFolder
{
	/// <summary>
	/// Basically a node is defined with a geographical position in space.
	/// It is also characterized with both collections of outgoing arcs and incoming arcs.
	/// </summary>
	public class Node
	{
        RealPoint _pos;
		bool _passable;
        
        List<Arc> _incomingArcs;
        List<Arc> _outgoingArcs;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public Node(double x, double y)
        {
            _pos = new RealPoint(x, y);
            _passable = true;
            _incomingArcs = new List<Arc>();
            _outgoingArcs = new List<Arc>();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pos">Position.</param>
        public Node(RealPoint pos)
        {
            _pos = new RealPoint(pos);
            _passable = true;
            _incomingArcs = new List<Arc>();
            _outgoingArcs = new List<Arc>();
        }

        /// <summary>
        /// Default constructor (0, 0)
        /// </summary>
        public Node()
        {
            _pos = new RealPoint();
            _passable = true;
            _incomingArcs = new List<Arc>();
            _outgoingArcs = new List<Arc>();
        }

		/// <summary>
		/// Gets the list of the arcs that lead to this node.
		/// </summary>
		public List<Arc> IncomingArcs { get { return _incomingArcs; } }

		/// <summary>
		/// Gets the list of the arcs that start from this node.
		/// </summary>
		public List<Arc> OutgoingArcs { get { return _outgoingArcs; } }

		/// Gets/Sets the functional state of the node.
		/// 'true' means that the node is in its normal state.
		/// 'false' means that the node will not be taken into account (as if it did not exist).
		public bool Passable
		{
			set
			{
				foreach (Arc A in _incomingArcs) A.Passable = value;
				foreach (Arc A in _outgoingArcs) A.Passable = value;
				_passable = value;
			}
			get { return _passable; }
		}

		/// <summary>
		/// Gets X coordinate.
		/// </summary>
		public double X { get { return _pos.X; } }

		/// <summary>
		/// Gets Y coordinate.
		/// </summary>
		public double Y { get { return _pos.Y; } }
        

        public RealPoint Position { get { return _pos; } }
        
		/// <summary>
		/// Returns the arc that leads to the specified node if it exists.
		/// </summary>
		/// <exception cref="ArgumentNullException">Argument node must not be null.</exception>
		/// <param name="N">A node that could be reached from this one.</param>
		/// <returns>The arc leading to N from this / null if there is no solution.</returns>
		public Arc ArcGoingTo(Node N)
		{
			if ( N==null ) throw new ArgumentNullException();
			foreach (Arc A in _outgoingArcs)
				if (A.EndNode == N) return A;
			return null;
		}

		/// <summary>
		/// object.ToString() override.
		/// Returns the textual description of the node.
		/// </summary>
		/// <returns>String describing this node.</returns>
		public override string ToString() { return _pos.ToString(); }

		/// <summary>
		/// Object.Equals override.
		/// Tells if two nodes are equal by comparing positions.
		/// </summary>
		/// <exception cref="ArgumentException">A Node cannot be compared with another type.</exception>
		/// <param name="o">The node to compare with.</param>
		/// <returns>'true' if both nodes are equal.</returns>
		public override bool Equals(object o)
		{
			Node other = (Node)o;

            return (other != null) && (_pos == other.Position);
		}

		/// <summary>
		/// Returns a copy of this node.
		/// </summary>
		/// <returns>The reference of the new object.</returns>
		public object Clone()
		{
			Node other = new Node(_pos);
			other.Passable = _passable;

			return other;
		}

		/// <summary>
		/// Object.GetHashCode override.
		/// </summary>
		/// <returns>HashCode value.</returns>
		public override int GetHashCode() { return _pos.GetHashCode(); }

		/// <summary>
		/// Returns the euclidian distance between two nodes : Sqrt(Dx²+Dy²)
		/// </summary>
		/// <param name="n1">First node.</param>
		/// <param name="n2">Second node.</param>
		/// <returns>Distance value.</returns>
		public static double EuclidianDistance(Node n1, Node n2)
		{
			return Math.Sqrt( SquareEuclidianDistance(n1, n2) );
		}

		/// <summary>
		/// Returns the square euclidian distance between two nodes : Dx²+Dy²
		/// </summary>
		/// <exception cref="ArgumentNullException">Argument nodes must not be null.</exception>
		/// <param name="n1">First node.</param>
		/// <param name="n2">Second node.</param>
		/// <returns>Distance value.</returns>
		public static double SquareEuclidianDistance(Node n1, Node n2)
		{
			if ( n1==null || n2==null ) throw new ArgumentNullException();
			double DX = n1.X - n2.X;
			double DY = n1.Y - n2.Y;
			return DX*DX+DY*DY;
		}

		/// <summary>
		/// Returns the manhattan distance between two nodes : |Dx|+|Dy|
		/// </summary>
		/// <exception cref="ArgumentNullException">Argument nodes must not be null.</exception>
		/// <param name="n1">First node.</param>
		/// <param name="n2">Second node.</param>
		/// <returns>Distance value.</returns>
		public static double ManhattanDistance(Node n1, Node n2)
		{
			if ( n1==null || n2==null ) throw new ArgumentNullException();
			double DX = n1.X - n2.X;
			double DY = n1.Y - n2.Y;
			return Math.Abs(DX)+Math.Abs(DY);
		}

		/// <summary>
		/// Returns the maximum distance between two nodes : Max(|Dx|, |Dy|)
		/// </summary>
		/// <exception cref="ArgumentNullException">Argument nodes must not be null.</exception>
		/// <param name="n1">First node.</param>
		/// <param name="n2">Second node.</param>
		/// <returns>Distance value.</returns>
		public static double MaxDistanceAlongAxis(Node n1, Node n2)
		{
			if ( n1==null || n2==null ) throw new ArgumentNullException();
			double DX = Math.Abs(n1.X - n2.X);
			double DY = Math.Abs(n1.Y - n2.Y);
			return Math.Max(DX, DY);
		}
	}
}

