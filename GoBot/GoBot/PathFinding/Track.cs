using System;


namespace AStarFolder
{
	/// <summary>
	/// A track is a succession of nodes which have been visited.
	/// Thus when it leads to the target node, it is easy to return the result path.
	/// These objects are contained in Open and Closed lists.
	/// </summary>
	public class Track : IComparable
	{
		private static Node _Target = null;
		private static double _Coeff = 0.5;
		private static Heuristic _ChoosenHeuristic = AStar.EuclidianHeuristic;

		public static Node Target { set { _Target = value; } get { return _Target; } }

		public Node EndNode;
		public Track Queue;

		public static double DijkstraHeuristicBalance
		{
			get { return _Coeff; }
			set
			{
				if ( value<0 || value>1 ) throw new ArgumentException(
@"The coefficient which balances the respective influences of Dijkstra and the Heuristic must belong to [0; 1].
-> 0 will minimize the number of nodes explored but will not take the real cost into account.
-> 0.5 will minimize the cost without developing more nodes than necessary.
-> 1 will only consider the real cost without estimating the remaining cost.");
				_Coeff = value;
			}
		}

		public static Heuristic ChoosenHeuristic
		{
			set { _ChoosenHeuristic = value; }
			get { return _ChoosenHeuristic; }
		}

		private int _NbArcsVisited;
		public int NbArcsVisited { get { return _NbArcsVisited; } }

		private double _Cost;
		public double Cost { get { return _Cost; } }

		virtual public double Evaluation
		{
			get
			{
				return _Coeff*_Cost+(1-_Coeff)*_ChoosenHeuristic(EndNode, _Target);
			}
		}

		public bool Succeed { get { return EndNode==_Target; } }

		public Track(Node GraphNode)
		{
			if ( _Target==null ) throw new InvalidOperationException("You must specify a target Node for the Track class.");
			_Cost = 0;
			_NbArcsVisited = 0;
			Queue = null;
			EndNode = GraphNode;
		}

		public Track(Track PreviousTrack, Arc Transition)
		{
			if (_Target==null) throw new InvalidOperationException("You must specify a target Node for the Track class.");
			Queue = PreviousTrack;
			_Cost = Queue.Cost + Transition.Cost;
			_NbArcsVisited = Queue._NbArcsVisited + 1;
			EndNode = Transition.EndNode;
		}

		public int CompareTo(object Objet)
		{
			Track OtherTrack = (Track) Objet;
			return Evaluation.CompareTo(OtherTrack.Evaluation);
		}

		public static bool SameEndNode(Track O1, Track O2)
		{
			if ( O1==null || O2==null ) throw new ArgumentException("Objects must be of 'Track' type.");
			return O1.EndNode.X ==O2.EndNode.X && O1.EndNode.Y == O2.EndNode.Y;
		}
	}
}
