using Colections.Colectii;
using Colections.Common;

namespace Colections
{
    public class CoadaCirculara<T> : ColectieAbstracta<T>, ICoada<T>
    {
        T[] items = new T[4];
        int first = 0;
        public int Capacity { get; private set; } = 4;

        //IColectie

        public override void Add(T item) => Push(item);

        public override bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[(first + i) % items.Length], item))
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        items[(first + j) % items.Length] = items[(first + j + 1) % items.Length];
                    }

                    items[(first + Count - 1) % items.Length] = default;
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
            first = 0;
            Capacity = 4;
        }

        public override T[] ToArray()
        {
            T[] array = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                array[i] = items[(first + i) % items.Length];
            }

            return array;
        }

        //ICoada

        public void Push(T item)
        {
            ResizeIfFull();
            items[(first + Count++) % items.Length] = item;
        }

        public T Pop()
        {
            if (Count == 0) throw new InvalidOperationException("Coada este goala.");
            T value = items[first];
            items[first] = default;

            first = (first + 1) % items.Length;
            Count--;
            return value;
        }

        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("Coada este goala.");
            return items[first];
        }

        private void ResizeIfFull()
        {
            if (Count < items.Length) return;

            if (first + Count == Capacity) Capacity *= 2;

            T[] newItems = new T[Count + 1];

            for (int i = 0; i < Count; i++)
            {
                newItems[i] = items[(first + i) % items.Length];
            }

            items = newItems;
            first = 0;

        } 
    }
}
