using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Collections;
using System.Windows;
using System.Windows.Markup;
using System;

namespace MSB.Collections
{
    /// <summary>
    /// Represents a collection of themes dictionaries.
    /// </summary>
    public sealed class ThemeCollection : IDictionary<string, ResourceDictionary>, INotifyCollectionChanged, INotifyPropertyChanged, IAddChild
    {
        /// <summary>
        /// Initializes a new instance of the 'ThemeDictionaries' class.
        /// </summary>
        public ThemeCollection()
        {
            data = new Dictionary<string, ResourceDictionary>();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the element with the specified key.
        /// </summary>
        /// <param name="key">The key of the element to get or set.</param>
        /// <returns>The element with the specified key.</returns>
        public ResourceDictionary this[string key]
        {
            get => data[key];
            set => data[key] = value;
        }

        /// <summary>
        /// Gets a collection containing the keys of the collection.
        /// </summary>
        public ICollection<string> Keys
        {
            get => data.Keys;
        }

        /// <summary>
        /// Gets a collection containing the values of the collection.
        /// </summary>
        public ICollection<ResourceDictionary> Values
        {
            get => data.Values;
        }

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public int Count
        {
            get => data.Count;
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get => false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds an element with the provided key and value to the collection.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, ResourceDictionary value)
        {
            data.Add(key, value);

            // Notify listeners...
            PropertyChanged?.Invoke(this, new(nameof(Count)));
            CollectionChanged?.Invoke(this, new(NotifyCollectionChangedAction.Add, value));
        }

        /// <summary>
        /// Add a theme to the collection.
        /// </summary>
        /// <param name="item">The theme to add.</param>
        public void Add(KeyValuePair<string, ResourceDictionary> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear()
        {
            data.Clear();

            // Notify listeners...
            PropertyChanged?.Invoke(this, new(nameof(Count)));
            CollectionChanged?.Invoke(this, new(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Determines whether the collection contains an element with the specified key.
        /// </summary>
        /// <param name="item">The object to locate in the collection.</param>
        /// <returns>**<see langword="true"/>** if the collection contains an element with the key; otherwise, **<see langword="false"/>**.</returns>
        public bool Contains(KeyValuePair<string, ResourceDictionary> item)
        {
            return data.Contains(item);
        }

        /// <summary>
        /// Determines whether the collection contains a specific key.
        /// </summary>
        /// <param name="key">The key to locate in the collection.</param>
        /// <returns>**<see langword="true"/>** if the collection contains an element with the key; otherwise, **<see langword="false"/>**.</returns>
        public bool ContainsKey(string key)
        {
            return data.ContainsKey(key);
        }

        /// <summary>
        /// Copies the elements of the collection to an array, starting at a particular array index.
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the elements copied from the collection.
        /// The array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(KeyValuePair<string, ResourceDictionary>[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, ResourceDictionary>> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        /// <summary>
        /// Removes the element with the specified key from the collection.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns>**<see langword="true"/>** if the element is successfully removed; otherwise, **<see langword="false"/>**.</returns>
        public bool Remove(string key)
        {
            if (data.Remove(key))
            {
                // Notify listeners...
                PropertyChanged?.Invoke(this, new(nameof(Count)));
                CollectionChanged?.Invoke(this, new(NotifyCollectionChangedAction.Remove, key));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the collection.
        /// </summary>
        /// <param name="item">The object to remove from the collection.</param>
        /// <returns>**<see langword="true"/>** if item was successfully removed from the collection; otherwise, **<see langword="false"/>**.</returns>
        public bool Remove(KeyValuePair<string, ResourceDictionary> item)
        {
            return Remove(item.Key);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified key.</param>
        /// <returns>**<see langword="true"/>** if the key is found; otherwise, **<see langword="false"/>**.</returns>
        public bool TryGetValue(string key, out ResourceDictionary value)
        {
            return data.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        /// <summary>
        /// Adds a child object.
        /// </summary>
        /// <param name="value"></param>
        public void AddChild(object value)
        {
            if (value is ResourceDictionary dictionary)
            {
                Add(dictionary.Source.OriginalString, dictionary);
            }
        }

        void IAddChild.AddText(string text)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Events

        /// <inheritdoc/>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        readonly IDictionary<string, ResourceDictionary> data = null;
    }
}
