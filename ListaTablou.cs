using System.Collections;

namespace Colections
{
    public class ListaTablou<T> : ILista<T>
    {
        private T[] items = new T[4];
        private int count = 0;

        public int Count { get => count; }
        public int Capacity = 4;

        //IColectie

        public void Add(T item)
        {
            if (count == items.Length)
            {
                T[] newItems = new T[Capacity * 2];
                Capacity *= 2;
                for (int i = 0; i < count; i++)
                {
                    newItems[i] = items[i];
                }

                items = newItems;
            }

            items[count++] = item;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        items[j] = items[j + 1];
                    }
                    count--;

                    return true;
                }
            }

            return false;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            items = new T[4];
            count = 0;
        }

        public T[] AsVector()
        {
            T[] vector = new T[count];

            for(int i = 0; i < count; i++)
            {
                vector[i] = items[i];
            }

            return vector;
        }

        //ILista

        public void Insert(int index, T item)
        {
            if (index > count || index < 0) return;

            if (count == items.Length)
            {
                T[] newItems = new T[Capacity * 2];
                Capacity *= 2;
                for (int i = 0; i < count; i++)
                {
                    newItems[i] = items[i];
                }

                items = newItems;
            }

            for (int i = 0; i <= count; i++)
            {
                if (i == index)
                {
                    for (int j = count; j > i; j--)
                    {
                        items[j] = items[j - 1];
                    }

                    items[i] = item;
                    count++;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index > count || index < 0) return;

            for (int i = 0; i < count; i++)
            {
                if (i == index)
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        items[j] = items[j + 1];
                    }

                    count--;
                }
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
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

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string text = "[";
            for(int i = 0; i < count; i++)
            {
                if (i + 1 == count)
                {
                    text += items[i];
                }
                else {
                    text += items[i] + ", "; }
            }

            text += "]";
            return text;
        }
    }
}
