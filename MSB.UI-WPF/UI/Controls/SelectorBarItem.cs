using System.Windows.Controls;
using System.Windows;
using System;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents a control that allows the user to select from a list of items.
    /// </summary>
    public sealed class SelectorBarItem : ListBoxItem
    {
        /// <summary>
        /// Initializes a new instance of the 'SelectorBarItem' class.
        /// </summary>
        public SelectorBarItem()
        {
            this.DefaultStyleKey = typeof(SelectorBarItem);
        }

        #region Properties

        /// <summary>
        /// Gets or sets the icon to show next to the menu item text.
        /// <para>The default is **null**.</para>
        /// </summary>
        public IconElement Icon
        {
            get => (IconElement)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        /// Gets or sets the icon padding inside the control.
        /// <para>The default is a Thickness with values of 11 on all four sides.</para>
        /// </summary>
        public Thickness IconPadding
        {
            get => (Thickness)GetValue(IconPaddingProperty);
            set => SetValue(IconPaddingProperty, value);
        }

        /// <summary>
        /// Gets or sets the Type to be navigated to when the item is invoked.
        /// <para>The default is **null**.</para>
        /// </summary>
        public Type SourcePageType
        {
            get => (Type)GetValue(SourcePageTypeProperty);
            set => SetValue(SourcePageTypeProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Icon dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
                    DependencyProperty.Register(nameof(Icon), typeof(IconElement), typeof(SelectorBarItem), new PropertyMetadata(null, IconChanged_Callback));

        /// <summary>
        /// Identifies the IconPadding dependency property.
        /// </summary>
        public static readonly DependencyProperty IconPaddingProperty =
                    DependencyProperty.Register(nameof(IconPadding), typeof(Thickness), typeof(SelectorBarItem), new PropertyMetadata(new Thickness(11)));

        /// <summary>
        /// Identifies the SourcePageType dependency property.
        /// </summary>
        public static readonly DependencyProperty SourcePageTypeProperty =
                    DependencyProperty.Register(nameof(SourcePageType), typeof(Type), typeof(SelectorBarItem), new PropertyMetadata(null));

        #endregion

        #region Callbacks

        private static void IconChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is SelectorBarItem barItem)
            {
                barItem.UpdateVisualState(false);
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            UpdateVisualState(false);
        }

        /// <inheritdoc />
        protected override void OnSelected(RoutedEventArgs e)
        {
            base.OnSelected(e);

            UpdateVisualState(true);
        }

        /// <inheritdoc />
        protected override void OnUnselected(RoutedEventArgs e)
        {
            base.OnUnselected(e);

            UpdateVisualState(true);
        }

        private void UpdateVisualState(bool animate)
        {
            VisualStateManager.GoToState(this, this.IsSelected ? "NotchVisible" : "NotchCollapsed", animate);
        }

        #endregion
    }
}
