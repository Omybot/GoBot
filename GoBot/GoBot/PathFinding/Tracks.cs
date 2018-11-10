using System;
using System.Collections;
using System.Collections.Generic;


namespace AStarFolder
{
    public class Tracks : IEnumerable<Track>
    {
        private List<Track> _list;
        private IComparer<Track> _comparer;
        
        public Tracks()
        {
            _comparer = new ComparisonCost();
            _list = new List<Track>();
        }
        public Track this[int Index]
        {
            get
            {
                return _list[Index];
            }
        }
        
        public int Add(Track newTrack)
        {
            int index = -1;

            int Index = FindBestPlaceFor(newTrack);
            int NewIndex = Index >= 0 ? Index : -Index - 1;
            if (NewIndex >= Count) _list.Add(newTrack);
            else _list.Insert(NewIndex, newTrack);
            index = NewIndex;

            return index;
        }
        
        protected int FindBestPlaceFor(Track t)
        {
            int place = _list.BinarySearch(t, _comparer);

            while (place > 0 && _list[place - 1].Equals(t)) place--; // We want to point at the FIRST occurence

            return place;
        }
        
        public void Clear()
        {
            _list.Clear();
        }
        
        public void Remove(Track t)
        {
            _list.Remove(t);
        }
        
        public void RemoveAt(int Index) { _list.RemoveAt(Index); }
        
        public int Count { get { return _list.Count; } }
        
        public override string ToString()
        {
            return "Count = " + _list.Count;
        }
        
        public override bool Equals(object o)
        {
            Tracks other = (Tracks)o;

            if (other.Count != Count)
                return false;

            for (int i = 0; i < Count; i++)
                if (!other[i].Equals(this[i]))
                    return false;

            return true;
        }
        
        public override int GetHashCode()
        {
            return _list.GetHashCode();
        }

        public IEnumerator<Track> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        private class ComparisonCost : IComparer<Track>
        {
            public int Compare(Track O1, Track O2)
            {
                IComparable C = O1 as IComparable;
                return O1.Evaluation.CompareTo(O2.Evaluation);
            }
        }
    }
}
