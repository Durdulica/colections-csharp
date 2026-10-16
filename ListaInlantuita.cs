using System.Collections;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;

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

        public ListaInlantuita(T data)
        {
            Count = 0;
            Node<T> node = new Node<T>(data, null);
            Head = Tail = node;
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
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            if (comparer.Equals(Head.Data, item))
            {
                Head = Head.Next;

                Count--;
                return true;
            }

            Node<T> aux = Head;

            while (Head.Next != null) 
            {
                if(comparer.Equals(Head.Next.Data, item))
                {
                    Head.Next = Head.Next.Next;
                    if (Head.Next == null)
                    {
                        Tail = Head;
                    }
                    Head = aux;
                    Count--;

                    return true;
                }

                Head = Head.Next;
            }

            Head = aux;
            return false;
        }

        public bool Contains(T item)
        {
            Node<T> aux = Head;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            while (Head != null) 
            {
                if (comparer.Equals(Head.Data, item))
                {
                    Head = aux;
                    return true;
                }

                Head = Head.Next;
            }

            Head = aux;
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
            Node<T> aux = Head;
            T[] array = new T[Count];
            int index = 0;

            while(Head != null)
            {
                array[index++] = Head.Data;
                Head = Head.Next;
            }

            Head = aux;
            return array;
        }

        //IList

        public void Insert(int index, T item) 
        {
            if (index > Count) return;

            if (index == 0)
            {
                Node<T> aux2 = new Node<T>(item, Head);
                Head = aux2;
                Count++;

                return;
            }

            Node<T> aux = Head;
            int counter = 0;
            
            while (Head != null) 
            {
                if(counter + 1 == index)
                {
                    Node<T> aux2 = Head.Next;
                    Head.Next = new Node<T>(item, aux2);

                    if (Tail.Next != null)
                    {
                        Tail = Tail.Next;
                    }

                    Head = aux;
                    Count++;
      
                    return;
                }

                Head = Head.Next;
                counter++;
            }

            Head = aux;
        }

        public void RemoveAt(int index)
        {
            if(index > Count) return;

            if(index == 0)
            {
                Head = Head.Next;
                Count--;
            }

            Node<T> aux = Head;
            int counter = 0;

            while(Head.Next != null)
            {
                if(counter + 1 == index)
                {
                    Head.Next = Head.Next.Next;

                    if(Head.Next == null)
                    {
                        Tail = Head;
                    }
                    Head = aux;
                    Count--;

                    return;
                }

                Head = Head.Next;
                counter++;
            }

            Head.Next = null;
            Tail = Head;
            Count--;
            Head = aux;
        }

        public int IndexOf(T item)
        {
            Node<T> aux = Head;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            int index = 0;

            while (Head != null)
            {
                if(comparer.Equals(Head.Data, item))
                {
                    Head = aux;
                    return index;
                }

                index++;
                Head = Head.Next;
            }

            Head = aux;
            return -1;
        }

        public T this[int index] {
            get 
            { 
                if(index > Count - 1)
                {
                    return default(T);
                }

                Node<T> aux = Head;
                int cnt = 0;
                while (Head != null) 
                {
                    if(cnt == index)
                    {
                        T data = Head.Data;
                        Head = aux;
                        return data;
                    }

                    cnt++;
                    Head = Head.Next;
                }

                Head = aux;
                return default(T);
            }
            set 
            {
                if (index > Count - 1)
                {
                    return;
                }

                Node<T> aux = Head;
                int cnt = 0;
                while (Head != null)
                {
                    if (cnt == index)
                    {
                        Head.Data = value;
                        Head = aux;
                        return;
                    }

                    cnt++;
                    Head = Head.Next;
                }

                Head = aux;
                return;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            //yield ????
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //????
            return GetEnumerator();
        }
    }
}
