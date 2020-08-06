using System;
using System.Collections;

/// <summary>
/// Name: Mark Felchlin
/// Description: Set Implementation / Assignment1
/// </summary>

namespace Assignment1
{
    public class Set : IEnumerable, ICollection
    {
        private readonly ArrayList _list;

        public Set()
        {
            _list = new ArrayList();
        }

        #region Properties
        public object this[int index]
        {
            get 
            { 
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return _list[index];  
            }

            set 
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                _list[index] = value; 
            }
        }
        public int Count { get { return _list.Count; } }
        public bool Empty { get { return 0 == Count; } }
        #endregion

        #region Methods
        public bool Contains(object o)
        {
            foreach (var obj in _list)
            {
                if (obj.Equals(o))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Add(object o)
        {
            if (Contains(o))
            {
                Console.WriteLine("Cannot add object to the Set. Object is already within the Set.");
                return false;
            }
            else
            {
                _list.Add(o);
                return true;
            }
        }

        public bool Remove(object o)
        {
            if (!Empty && Contains(o))
            {
                _list.Remove(o);
                return true;
            }
            else
            {
                Console.WriteLine("The object was not removed as it is not in the list.");
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Set other = (Set) obj;

            if (other.Count == Count)
            {
                foreach (var item in other)
                {
                    if (!Contains(item))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 0;

            foreach (var obj in _list)
            {
                hashCode += obj.GetHashCode();
            }

            return hashCode;
        }

        public override string ToString()
        {
            var output = "[";

            foreach (var item in _list)
            {
                output += item.ToString() + ",";
            }

            return output + "]";
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection)_list).CopyTo(array, index);
        }
        public bool IsSynchronized => ((ICollection)_list).IsSynchronized;

        public object SyncRoot => ((ICollection)_list).SyncRoot;

        #endregion
    }
}
