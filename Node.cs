namespace Colections
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Next;

        public Node()
        {
            Next = null;
        }

        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }

    }
}
