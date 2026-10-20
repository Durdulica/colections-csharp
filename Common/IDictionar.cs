using System.Diagnostics.CodeAnalysis;

namespace Colections.Common
{
    public interface IDictionar<K, V> where K : notnull
    {
        int Count { get; }
        V this[K key] { get; set; }
        void Add(K key, V value);
        bool TryToTake(K key, [MaybeNullWhen(false)] out V value);
        bool ContainsKey(K key);
        bool Remove(K key);
        void Clear();
        IEnumerable<K> Keys { get; }
        IEnumerable<V> Values { get; }
    }
}
