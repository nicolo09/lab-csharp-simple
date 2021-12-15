namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>, IEquatable<IMap2D<TKey1, TKey2, TValue>>
    {
        IDictionary<Tuple<TKey1, TKey2>, TValue> values = new Dictionary<Tuple<TKey1, TKey2>, TValue>();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements { get => values.Values.Count; }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get => values[new Tuple<TKey1, TKey2>(key1, key2)];
            set => values[new Tuple<TKey1, TKey2>(key1, key2)] = value;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            IList<Tuple<TKey2, TValue>> result = new List<Tuple<TKey2, TValue>>();
            foreach (var item in values)
            {
                if (item.Key.Item1.Equals(key1))
                {
                    result.Add(new Tuple<TKey2, TValue>(item.Key.Item2, item.Value));
                }
            }
            return result;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            IList<Tuple<TKey1, TValue>> result = new List<Tuple<TKey1, TValue>>();
            foreach (var item in values)
            {
                if (item.Key.Item2.Equals(key2))
                {
                    result.Add(new Tuple<TKey1, TValue>(item.Key.Item1, item.Value));
                }
            }
            return result;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            IList<Tuple<TKey1, TKey2, TValue>> result = new List<Tuple<TKey1, TKey2, TValue>>();
            foreach (var item in values)
            {
                result.Add(new Tuple<TKey1, TKey2, TValue>(item.Key.Item1, item.Key.Item2, item.Value));
            }
            return result;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            IEnumerator<TKey1> keys1enumerator = keys1.GetEnumerator();
            IEnumerator<TKey2> keys2enumerator = keys2.GetEnumerator();
            while (keys1enumerator.MoveNext() && keys2enumerator.MoveNext())
            {
                values.Add(new Tuple<TKey1, TKey2>(keys1enumerator.Current, keys2enumerator.Current), generator.Invoke(keys1enumerator.Current, keys2enumerator.Current));
            }
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            if (other.GetElements().Equals(this.GetElements()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            if (obj is Map2D<TKey1, TKey2, TValue>)
            {
                return Equals(obj as Map2D<TKey1, TKey2, TValue>);
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(values);
        }


        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.ToString"/>
        public override string ToString()
        {
            return values.ToString();
        }

    }
}
