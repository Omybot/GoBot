using System;
using System.Collections;
using System.Collections.Generic;


namespace AStarFolder
{
    /// <summary>
    /// The SortableList allows to maintain a list sorted as long as needed.
    /// If no IComparer interface has been provided at construction, then the list expects the Objects to implement IComparer.
    /// If the list is not sorted it behaves like an ordinary list.
    /// When sorted, the list's "Add" method will put new objects at the right place.
    /// As well the "Contains" and "IndexOf" methods will perform a binary search.
    /// </summary>
    public class Tracks : IEnumerable<Track>
    {
        private List<Track> _list;
        private IComparer<Track> _comparer;
        private bool _isSorted;
        private bool _keepSorted;

        /// <summary>
        /// Default constructor.
        /// Since no IComparer is provided here, added objects must implement the IComparer interface.
        /// </summary>
        public Tracks()
        {
            _comparer = new ComparisonCost();
            _list = new List<Track>();
            _isSorted = true;
            _keepSorted = true;
        }

        /// <summary>
        /// 'Get only' property that indicates if the list is sorted.
        /// </summary>
        public bool IsSorted { get { return _isSorted; } }

        /// <summary>
        /// Get : Indicates if the list must be kept sorted from now on.
        /// Set : Tells the list if it must stay sorted or not. Impossible to set to true if the list is not sorted.
        /// <see cref="KeepSorted">KeepSorted</see>==true implies that <see cref="IsSorted">IsSorted</see>==true
        /// </summary>
        /// <exception cref="InvalidOperationException">Cannot be set to true if the list is not sorted yet.</exception>
        public bool KeepSorted
        {
            set
            {
                _keepSorted = value;

                if (_keepSorted && !_isSorted)
                {
                    _list.Sort();
                    _isSorted = true;
                }
            }
            get { return _keepSorted; }
        }
        
        /// <summary>
        /// Gets object's value at a specified index.
        /// </summary>
        public Track this[int Index]
        {
            get
            {
                return _list[Index];
            }
        }

        /// <summary>
        /// IList implementation.
        /// If the <see cref="KeepSorted">KeepSorted</see> property is set to true, the object will be added at the right place.
        /// Else it will be added at the end of the list.
        /// </summary>
        /// <param name="newTrack">The object to add.</param>
        /// <returns>The index where the object has been added.</returns>
        /// <exception cref="ArgumentException">The SortableList is set to use object's IComparable interface, and the specifed object does not implement this interface.</exception>
        public int Add(Track newTrack)
        {
            int index = -1;

            if (_keepSorted)
            {
                int Index = IndexOf(newTrack);
                int NewIndex = Index >= 0 ? Index : -Index - 1;
                if (NewIndex >= Count) _list.Add(newTrack);
                else _list.Insert(NewIndex, newTrack);
                index = NewIndex;
            }
            else
            {
                _isSorted = false;
                _list.Add(newTrack);
                index = _list.Count - 1;
            }

            return index;
        }

        /// <summary>
        /// IList implementation.
        /// Search for a specified object in the list.
        /// If the list is sorted, a <see cref="ArrayList.BinarySearch">BinarySearch</see> is performed using IComparer interface.
        /// Else the <see cref="Equals">Object.Equals</see> implementation is used.
        /// </summary>
        /// <param name="t">The object to look for</param>
        /// <returns>true if the object is in the list, otherwise false.</returns>
        public bool Contains(Track t)
        {
            return _isSorted ? _list.BinarySearch(t, _comparer) >= 0 : _list.Contains(t);
        }

        /// <summary>
        /// IList implementation.
        /// Returns the index of the specified object in the list.
        /// If the list is sorted, a <see cref="ArrayList.BinarySearch">BinarySearch</see> is performed using IComparer interface.
        /// Else the <see cref="Equals">Object.Equals</see> implementation of objects is used.
        /// </summary>
        /// <param name="t">The object to locate.</param>
        /// <returns>
        /// If the object has been found, a positive integer corresponding to its position.
        /// If the objects has not been found, a negative integer which is the bitwise complement of the index of the next element.
        /// </returns>
        public int IndexOf(Track t)
        {
            int Result = -1;
            if (_isSorted)
            {
                Result = _list.BinarySearch(t, _comparer);
                while (Result > 0 && _list[Result - 1].Equals(t)) Result--; // We want to point at the FIRST occurence
            }
            else Result = _list.IndexOf(t);
            return Result;
        }
        
        /// <summary>
        /// IList implementation.
        /// Idem <see cref="ArrayList">ArrayList</see>
        /// </summary>
        public void Clear() { _list.Clear(); }
        
        /// <summary>
        /// IList implementation.
        /// Idem <see cref="ArrayList">ArrayList</see>
        /// </summary>
        /// <param name="t">The object whose value must be removed if found in the list.</param>
        public void Remove(Track t)
        {
            _list.Remove(t);
        }

        /// <summary>
        /// IList implementation.
        /// Idem <see cref="ArrayList">ArrayList</see>
        /// </summary>
        /// <param name="Index">Index of object to remove.</param>
        public void RemoveAt(int Index) { _list.RemoveAt(Index); }
        
        /// <summary>
        /// IList.ICollection implementation.
        /// Idem <see cref="ArrayList">ArrayList</see>
        /// </summary>
        public int Count { get { return _list.Count; } }
        
        /// <summary>
        /// Defines an equality for two objects
        /// </summary>
        public delegate bool Equality(Track O1, Track O2);
                
        /// <summary>
        /// Object.ToString() override.
        /// Build a string to represent the list.
        /// </summary>
        /// <returns>The string refecting the list.</returns>
        public override string ToString()
        {
            return "Count = " + _list.Count + " [" + (_isSorted ? "" : "Not ") + "Sorted]";
        }

        /// <summary>
        /// Object.Equals() override.
        /// </summary>
        /// <returns>true if object is equal to this, otherwise false.</returns>
        public override bool Equals(object O)
        {
            Tracks SL = (Tracks)O;
            if (SL.Count != Count) return false;
            for (int i = 0; i < Count; i++)
                if (!SL[i].Equals(this[i])) return false;
            return true;
        }

        /// <summary>
        /// Object.GetHashCode() override.
        /// </summary>
        /// <returns>HashCode value.</returns>
        public override int GetHashCode() { return _list.GetHashCode(); }

        /// <summary>
        /// Sorts the elements in the list using <see cref="ArrayList.Sort">ArrayList.Sort</see>.
        /// Does nothing if the list is already sorted.
        /// </summary>
        public void Sort()
        {
            if (_isSorted) return;
            _list.Sort(_comparer);
            _isSorted = true;
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
                return O1.Cost.CompareTo(O2.Cost);
            }
        }
    }
}
