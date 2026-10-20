namespace Colections.Common
{
    public interface ICoada<T> : IColectie<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
    }
}
