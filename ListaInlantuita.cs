using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;

namespace Colections
{
    public class ListaInlantuita<T> /*: ILista<T>*/
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
            Node<T> aux = Head;

            while (Head.Next != null) 
            {
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;

                if(comparer.Equals(Head.Data, item))
                {
                    Head = Head.Next.Next;
                    Count--;

                    return true;
                }
            }

            return false;
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
    }
}
