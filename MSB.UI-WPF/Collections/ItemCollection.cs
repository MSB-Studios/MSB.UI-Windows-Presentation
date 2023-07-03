using System.Collections.Specialized;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System;

namespace MSB.Collections
{
    /// <summary>
    /// Represents a collection of objects.
    /// </summary>
    [Serializable]
    public sealed class ItemCollection : ICollection<object>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the 'ItemCollection' class.
        /// </summary>
        public ItemCollection()
        {
            data = new List<object>();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public object this[int index]
        {
            get => data[index];
            set
            {
                if (data.IsReadOnly)
                    throw new NotSupportedException();

                if (index < 0 || index >= data.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                data[index] = value;
            }
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
            get => data.IsReadOnly;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The object to add to the collection.</param>
        /// <exception cref="NotSupportedException"></exception>
        public void Add(object item)
        {
            if (data.IsReadOnly)
                throw new NotSupportedException();

            data.Add(item);

            // Notify listeners
            PropertyChanged?.Invoke(this, new(nameof(Count)));
            CollectionChanged?.Invoke(this, new(NotifyCollectionChangedAction.Add, item));
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        public void Clear()
        {
            if (data.IsReadOnly)
                throw new NotSupportedException();

            data.Clear();

            // Notify listeners
            PropertyChanged?.Invoke(this, new(nameof(Count)));
            CollectionChanged?.Invoke(this, new(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Determines whether the collection contains a specific value.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(object item)
        {
            return data.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the collection to an array, starting at a particular array index.
        /// </summary>
        /// <param name="array"> The one-dimensional array that is the destination of the elements copied from the collection.
        /// The array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(object[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<object> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the collection.
        /// </summary>
        /// <param name="item">The object to remove from the collection.</param>
        /// <returns>**<see langword="true"/>** if item was successfully removed from the collection; otherwise, **<see langword="false"/>**.
        /// This method also returns <see langword="false"/> if item is not found in the original collection.</returns>
        /// <exception cref="NotSupportedException"></exception>
        public bool Remove(object item)
        {
            if (data.IsReadOnly)
                throw new NotSupportedException();

            var index = data.IndexOf(item);

            if (data.Remove(item))
            {
                // Notify listeners
                PropertyChanged?.Invoke(this, new(nameof(Count)));
                CollectionChanged?.Invoke(this, new(NotifyCollectionChangedAction.Remove, item, index));

                return true;
            }

            return false;
        }

        #endregion

        #region Events

        /// <inheritdoc/>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        readonly IList<object> data = null;
    }
}
