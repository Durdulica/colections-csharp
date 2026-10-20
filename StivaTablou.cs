using Colections.Colectii;
using Colections.Common;

namespace Colections
{
    public class StivaTablou<T> : ColectieAbstracta<T>, IStiva<T>
    {
        private T[] items = new T[4];
        public int Capacity { get; private set; } = 4;

        //IColectie

        public override void Add(T item) => Push(item);

        public override bool Remove(T item)
        {
            for (int i = 0; i < Count; i++) 
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item)) 
                {
                    for(int j = i; j < Count - 1; j++)
                    {
                        items[j] = items[j + 1];
                    }

                    items[Count - 1] = default;
                    Count--;
                    return true; 
                }
            }

            return false;
        }

        public override void Clear()
        {
            items = new T[4];
            Capacity = 4;
            Count = 0;
        }

        public override T[] ToArray()
        {
            T[] array = new T[Count];

            for (int i = 0; i < Count; i++) 
            {
                array[i] = items[i];
            }

            return array;
        }

        //IStiva

        public void Push(T item)
        {
            ResizeIfFull();
            items[Count++] = item;
        }

        public T Pop()
        {
            if(Count == 0) throw new InvalidOperationException("Stiva e goala");
            T value = items[Count - 1];
            items[Count - 1] = default;
            Count--;
            return value;
        }

        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("Stiva e goala");
            return items[Count - 1];
        }

        private void ResizeIfFull()
        {
            if (Count < items.Length) return;

            T[] newItems = new T[Count + 1];

            for (int i = 0; i < Count; i++)
            {
                newItems[i] = items[i];
            }

            items = newItems;
        }
    }
}
