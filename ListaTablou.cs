using System.Collections;
using Colections.Colectii;
using Colections.Common;

namespace Colections
{
    public class ListaTablou<T> : ColectieAbstracta<T>, ILista<T>
    {
        private T[] items = new T[4];
        public int Capacity = 4;

        //IColectie

        public override void Add(T item)
        {
            ResizeIfFull();

            items[Count++] = item;
        }

        public override bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        items[j] = items[j + 1];
                    }
                    items[Count] = default;
                    Count--;

                    return true;
                }
            }

            return false;
        }

        public override void Clear()
        {
            items = new T[4];
            Count = 0;
            Capacity = 0;
        }

        public override T[] ToArray()
        {
            return items;
        }

        //ILista

        public void Insert(int index, T item)
        {
            if (index > Count || index < 0) return;

            ResizeIfFull();

            for (int j = Count; j > index; j--)
            {
                items[j] = items[j - 1];
            }

            items[index] = item;
            Count++;

        }

        public void RemoveAt(int index)
        {
            if (index > Count || index < 0) return;

            for (int j = index; j < Count - 1; j++)
            {
                items[j] = items[j + 1];
            }
            items[Count] = default;
            Count--;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public T this[int index]
        {
            get {  return items[index]; }
            set { items[index] = value; }
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)this).GetEnumerator();

        private void ResizeIfFull()
        {
            if (Count == items.Length)
            {
                
                T[] newItems = new T[Count + 1];
                if(Count == Capacity) Capacity *= 2;
                
                for (int i = 0; i < Count; i++)
                {
                    newItems[i] = items[i];
                }

                items = newItems;
            }
        }
    }
}
