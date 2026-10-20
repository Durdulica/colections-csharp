using Colections.Common;
using System.Diagnostics.CodeAnalysis;

namespace Colections
{
    public class DictionarHash<K, V> : IDictionar<K, V> where K : notnull
    {
        internal Node<K> key;
        internal V value;
        internal Node<K>? next;
        internal Node<K>[]? buckets = new Node<K>[8];
        EqualityComparer<K> comparer = EqualityComparer<K>.Default;

        public V this[K key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int BucketsLength
        {
            get { return buckets.Length; }
        }

        public int Count { get; set; } = 0;

        
        public void Add(K key, V value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(K key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(K key)
        {
            throw new NotImplementedException();
        }

        public bool TryToTake(K key, [MaybeNullWhen(false)] out V value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<K> Keys => throw new NotImplementedException();

        public IEnumerable<V> Values => throw new NotImplementedException();

    }
}
