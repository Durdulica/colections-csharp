namespace Colections
{
    public interface ILista<T> : IColectie<T>
    {
        T this[int index] { get; set; }
        void Insert(int index, T item);
        void RemoveAt(int index);
        int IndexOf(T item);
    }
}
