using System.Collections.Generic;

namespace Jd.ACES.Common
{
    public class TDEConcurrentDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        private readonly object mutex = new object();

        public TDEConcurrentDictionary() : base()
        {
        }

        public new TValue this[TKey key]
        {
            get { lock (mutex) { return base[key]; } }
            set { lock (mutex) { base[key] = value; } }
        }

        public new int Count { get { lock (mutex) { return base.Count; } } }

        public new ICollection<TKey> Keys { get{ lock (mutex) { return base.Keys; } } }

        public new ICollection<TValue> Values { get { lock (mutex) { return base.Values; } } }

        /// <summary>
        /// Attempts to add the specified key and value.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be null for reference types.</param>
        /// <returns>true if the key/value pair was added successfully; false if the key already exists.</returns>
        public bool TryAdd(TKey key, TValue value)
        {
            lock (mutex)
            {
                base.TryGetValue(key, out TValue existed);
                if (existed == null)
                {
                    base.Add(key, value);
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }

        /// <summary>
        /// Attempts to get the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value"> When this method returns, contains the value associated with the specified key,
        ///     if the key is found; otherwise, the default value for the type of the value parameter.
        ///     This parameter is passed uninitialized.</param>
        /// <returns>true if it contains an element with the specified key; otherwise, false.</returns>
        public new bool TryGetValue(TKey key, out TValue value)
        {
            lock (mutex)
            {
                return base.TryGetValue(key, out value);
            }
        }

        /// <summary>
        ///  Compares the existing value for the specified key with a specified value, and
        ///     if they are equal, updates the key with a third value.
        /// </summary>
        /// <param name="key">The key whose value is compared with comparisonValue and possibly replaced.</param>
        /// <param name="newValue">The value that replaces the value of the element that has the specified key if
        ///     the comparison results in equality.</param>
        /// <param name="comparisonValue">The value that is compared to the value of the element that has 
        ///     the specifiedkey.</param>
        /// <returns>true if the value with key was equal to comparisonValue and was replaced with newValue; 
        ///     otherwise, false.</returns>
        public bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue)
        {
            lock (mutex)
            {
                bool result = base.TryGetValue(key, out TValue value) && value != null && value.Equals(comparisonValue);
                if (result)
                    base[key] = newValue;
                return result;
            }
        }

        public new void Add(TKey key, TValue value)
        {
            this.TryAdd(key, value);
        }

        public new bool Remove(TKey key)
        {
            lock (mutex)
            {
                return base.Remove(key);
            }
        }

        public void Remove(ICollection<TKey> target)
        {
            lock (mutex)
            {
                foreach (TKey id in target)
                {
                    base.Remove(id);
                }
            }
        }

        public new bool ContainsKey(TKey key)
        {
            lock (mutex)
            {
                return base.ContainsKey(key);
            }
        }

        public new bool ContainsValue(TValue value)
        {
            lock (mutex)
            {
                return base.ContainsValue(value);
            }
        }

        public new void Clear()
        {
            lock (mutex)
            {
                base.Clear();
            }
        }
    }
}
