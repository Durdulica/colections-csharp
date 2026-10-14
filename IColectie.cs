namespace Colections
{
    public interface IColectie<T> : IEnumerable<T>
    {
        int Count { get; }
        void Add(T item);
        bool Delete(T item);
        bool Contains(T item);
        void Clear(T item);
        T[] AsVector();
    }
}
