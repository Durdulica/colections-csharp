namespace Colections
{
    public class Lista<T>
    {
        public readonly Node<T> Head;

        public Lista(Node<T> head)
        {
            Head = head;
        }

        public void Push(Node<T> node)
        {
            Node<T> aux = Head;
            while(aux.Next != null)
            {
                aux = aux.Next;
            }
            aux = node;
        }

        public void Pop() 
        {
            
        }
    }
}
