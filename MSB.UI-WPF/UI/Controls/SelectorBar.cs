using ItemCollection = MSB.Collections.ItemCollection;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows;
using System;


namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents a control that allows the user to select from a list of items.
    /// </summary>
    [ContentProperty(nameof(Items))]
    public sealed class SelectorBar : Control
    {
        /// <summary>
        /// Initializes a new instance of the 'SelectorBar' class.
        /// </summary>
        public SelectorBar()
        {
            this.DefaultStyleKey = typeof(SelectorBar);
        }

        #region Properties

        /// <summary>
        /// Gets the collection of menu items displayed in the NavigationView menu.
        /// <para>The default is an empty collection.</para>
        /// </summary>
        public ItemCollection Items
        {
            get => (ItemCollection)GetValue(ItemsProperty);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Items dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsProperty =
                DependencyProperty.Register(nameof(Items), typeof(ItemCollection), typeof(SelectorBar), new PropertyMetadata(new ItemCollection()));

        #endregion
    }
}
