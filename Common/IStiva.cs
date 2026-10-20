namespace Colections.Common
{
    public interface IStiva<T> : IColectie<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
    }
}
