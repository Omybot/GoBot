using System;

namespace AStarFolder
{
    /// <summary>
    /// An arc is defined with its two extremity nodes StartNode and EndNode therefore it is oriented.
    /// It is also characterized by a crossing factor named 'Weight'.
    /// This value represents the difficulty to reach the ending node from the starting one.
    /// </summary>
    public class Arc
    {
        Node _startNode;
        Node _endNode;
        double _weight;
        bool _passable;
        double _length;

        /// <summary>
        /// Arc constructor.
        /// </summary>
        /// <exception cref="ArgumentNullException">Extremity nodes cannot be null.</exception>
        /// <exception cref="ArgumentException">StartNode and EndNode must be different.</exception>
        /// <param name="Start">The node from which the arc starts.</param>
        /// <param name="End">The node to which the arc ends.</param>
        public Arc(Node Start, Node End)
        {
            StartNode = Start;
            EndNode = End;
            _weight = 1;
            _length = _startNode.Position.Distance(_endNode.Position);
            _passable = true;
        }

        /// <summary>
        /// Gets/Sets the node from which the arc starts.
        /// </summary>
        /// <exception cref="ArgumentNullException">StartNode cannot be set to null.</exception>
        /// <exception cref="ArgumentException">StartNode cannot be set to EndNode.</exception>
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

        /// <summary>
        /// Gets/Sets the node to which the arc ends.
        /// </summary>
        /// <exception cref="ArgumentNullException">EndNode cannot be set to null.</exception>
        /// <exception cref="ArgumentException">EndNode cannot be set to StartNode.</exception>
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

        /// <summary>
        /// Sets/Gets the weight of the arc.
        /// This value is used to determine the cost of moving through the arc.
        /// </summary>
        public double Weight
        {
            set { _weight = value; }
            get { return _weight; }
        }

        /// <summary>
        /// Gets/Sets the functional state of the arc.
        /// 'true' means that the arc is in its normal state.
        /// 'false' means that the arc will not be taken into account (as if it did not exist or if its cost were infinite).
        /// </summary>
        public bool Passable
        {
            set { _passable = value; }
            get { return _passable; }
        }

        /// <summary>
        /// Gets arc's length.
        /// </summary>
        public double Length
        {
            get
            {
                return _length;
            }
        }

        /// <summary>
        /// Gets the cost of moving through the arc.
        /// Can be overriden when not simply equals to Weight*Length.
        /// </summary>
        virtual public double Cost
        {
            get { return _weight * _length; }
        }

        /// <summary>
        /// Returns the textual description of the arc.
        /// object.ToString() override.
        /// </summary>
        /// <returns>String describing this arc.</returns>
        public override string ToString()
        {
            return _startNode.ToString() + "-->" + _endNode.ToString();
        }

        /// <summary>
        /// Object.Equals override.
        /// Tells if two arcs are equal by comparing StartNode and EndNode.
        /// </summary>
        /// <exception cref="ArgumentException">Cannot compare an arc with another type.</exception>
        /// <param name="O">The arc to compare with.</param>
        /// <returns>'true' if both arcs are equal.</returns>
        public override bool Equals(object O)
        {
            Arc A = (Arc)O;
            if (A == null)
                return false;
            return _startNode.Equals(A._startNode) && _endNode.Equals(A._endNode);
        }

        /// <summary>
        /// Object.GetHashCode override.
        /// </summary>
        /// <returns>HashCode value.</returns>
        public override int GetHashCode() { return (int)_startNode.GetHashCode() + _endNode.GetHashCode(); }
    }
}

