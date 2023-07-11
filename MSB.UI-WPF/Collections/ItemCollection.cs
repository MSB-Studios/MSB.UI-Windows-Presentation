using System.Collections;
using System;

namespace MSB.Collections
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ItemCollection : CollectionBase
    {
        /// <summary>
        /// Gets or sets the item at the given zero-based index.
        /// </summary>
        /// <param name="index">The zero-based index of the item.</param>
        /// <returns>The object retrieved or the object that is being set to the specified index.</returns>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public object this[int index]
        {
            get => List[index];
            set => List[index] = value;
        }

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="value">The item to add to the collection.</param>
        /// <returns>The zero-based index at which the object is added
        /// of -1 if the item cannot be added.</returns>
        /// <exception cref="InvalidOperationException"/>
        public int Add(object value)
        {
            return List.Add(value);
        }

        /// <summary>
        /// Returns the index in this collection where the specified item is located.
        /// </summary>
        /// <param name="value">The object to look for in the collection.</param>
        /// <returns>The index of the item in the collection, or -1 if the item
        /// does not exist in the collection.</returns>
        public int IndexOf(object value)
        {
            return List.IndexOf(value);
        }

        /// <summary>
        /// Inserts an element into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which to insert the item.</param>
        /// <param name="value">The item to insert.</param>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public void Insert(int index, object value)
        {
            List.Insert(index, value);
        }

        /// <summary>
        /// Removes the specified item reference from the collecion or view.
        /// </summary>
        /// <param name="value">The object to remove.</param>
        /// <exception cref="InvalidOperationException"/>
        public void Remove(object value)
        {
            List.Remove(value);
        }

        /// <summary>
        /// Returns a value that indicates whether the specified item is in this view.
        /// </summary>
        /// <param name="value">The object to check.</param>
        /// <returns>true to indicate that the item belongs to this collection and passes
        /// the active filter; otherwise, false.</returns>
        public bool Contains(object value)
        {
            return List.Contains(value);
        }
    }
}
