using System.Collections;

namespace Colections
{
    public class ListaInlantuita<T> : ILista<T>
    {
        private Node<T> Head;
        private Node<T> Tail;
        public int Count { get; private set; }
        
        public ListaInlantuita()
        {
            Head = null;
            Tail = new Node<T>();
            Count = 0;
        }

        //ICollection
        
        public void Add(T item)
        {
            if (Head == null)
            {
                Head = Tail = new Node<T>(item, null);
                Count++;
                return;
            }
            
            Tail.Next = new Node<T>(item, null);
            Tail = Tail.Next;
            Count++;
        }

        public bool Remove(T item)
        {
            if(Head == null) return false;

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            if (comparer.Equals(Head.Data, item))
            {
                Head = Head.Next;

                Count--;
                return true;
            }

            Node<T> current = Head;

            while (current.Next != null) 
            {
                if(comparer.Equals(current.Next.Data, item))
                {
                    current.Next = current.Next.Next;
                    if (current.Next == null)
                    {
                        Tail = Head;
                    }
                    Count--;

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public bool Contains(T item)
        {
            Node<T> current = Head;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            while (current != null) 
            {
                if (comparer.Equals(current.Data, item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        public T[] AsVector()
        {
            Node<T> current = Head;
            T[] array = new T[Count + 1];
            int index = 0;

            while(current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }

            return array;
        }

        //IList

        public void Insert(int index, T item) 
        {
            if (Head == null)
            {
                Head = Tail = new Node<T>(item, null);
                Count++;
                return;
            }

            if (index > Count || index < 0) return;

            if (index == 0)
            {
                Head = new Node<T>(item, Head);
                Count++;

                return;
            }

            Node<T> current = Head;
            int counter = 0;
            
            while (current != null) 
            {
                if(counter + 1 == index)
                {
                    Node<T> aux2 = current.Next;
                    current.Next = new Node<T>(item, aux2);

                    if (aux2 == null)
                    {
                        Tail = Tail.Next;
                    }
                    Count++;
      
                    return;
                }

                current = current.Next;
                counter++;
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0 || Head == null) return;

            if(index == 0)
            {
                Head = Head.Next;
                Count--;
                return;
            }

            Node<T> current = Head;
            int counter = 0;

            while(current.Next != null)
            {
                if(counter + 1 == index)
                {
                    current.Next = current.Next.Next;

                    if(current.Next == null)
                    {
                        Tail = current;
                    }
                    Count--;

                    return;
                }

                current = current.Next;
                counter++;
            }
        }

        public int IndexOf(T item)
        {
            Node<T> current = Head;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            int index = 0;

            while (current != null)
            {
                if(comparer.Equals(current.Data, item))
                {
                    return index;
                }

                index++;
                current = current.Next;
            }

            return -1;
        }

        public T this[int index] {
            get 
            { 
                if(index > Count - 1 || index < 0)
                {
                    return default(T);
                }

                Node<T> current = Head;
                int cnt = 0;
                while (current != null) 
                {
                    if(cnt == index)
                    {
                        T data = current.Data;
                        return data;
                    }

                    cnt++;
                    current = current.Next;
                }

                return default(T);
            }
            set 
            {
                if (index > Count - 1 || index < 0)
                {
                    return;
                }

                Node<T> current = Head;
                int cnt = 0;
                while (current != null)
                {
                    if (cnt == index)
                    {
                        current.Data = value;
                        return;
                    }

                    cnt++;
                    current = current.Next;
                }

                return;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;

            while (current != null) 
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            string text = "[";

            if(Count > 0)
            {
                text += Head.Data; //???
            }
            foreach (T item in this) 
            {
                text += ", " + item;
            }
            text += "]";

            return text;
        }
    }
}
