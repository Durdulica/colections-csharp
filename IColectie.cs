namespace Colections
{
    public interface IColectie<T> : IEnumerable<T>
    {
        int Count { get; }
        void Add(T item);
        bool Remove(T item);
        bool Contains(T item);
        void Clear();
        T[] AsVector();
    }
}
