using Colections.Common;
using System.Collections;

namespace Colections.Colectii
{
    public abstract class ColectieAbstracta<T> : IColectie<T>
    {
        private int count = 0;
        public int Count { get => count; set { count = value; } }

        public abstract void Add(T item);

        public abstract bool Remove(T item);

        public bool Contains(T item)
        {
            foreach (T x in ToArray())
            {
                if (EqualityComparer<T>.Default.Equals(x, item)) return true;
            }
            return false;
        }

        public abstract void Clear();

        public abstract T[] ToArray();
        
        public IEnumerator<T> GetEnumerator()
        {
            T[] array = ToArray();
            for(int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => "[" + String.Join(",", ToArray()) + "]";
    }
}
