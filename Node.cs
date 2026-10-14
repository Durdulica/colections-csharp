namespace Colections
{
    public class Node<T>
    {
        public readonly T Data;
        public readonly Node<T> Next;

        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }

    }
}
