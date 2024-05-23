using System;
using System.Windows;
using System.Windows.Media;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents tha base class for an icon UI element.
    /// </summary>
    public abstract class IconElement : FrameworkElement
    {
        /// <summary>
        /// Provides base class initialization behavior for IconElement derived class.
        /// </summary>
        protected IconElement()
        {
            this.Focusable = false;
        }

        #region Properties

        /// <summary>
        /// Gets the count of visual child elements within this element.
        /// </summary>
        protected override int VisualChildrenCount
        {
            get => 1;
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        protected override Visual GetVisualChild(int index)
        {
            return index is 0 ? Child : throw new ArgumentOutOfRangeException(nameof(index));
        }

        /// <inheritdoc/>
        protected override Size MeasureOverride(Size availableSize)
        {
            Child.Measure(availableSize);

            return Child.DesiredSize;
        }

        /// <inheritdoc/>
        protected override Size ArrangeOverride(Size finalSize)
        {
            Child.Arrange(new Rect(finalSize));

            return finalSize;
        }

        #endregion

        /// <summary>
        /// Gets the child element.
        /// </summary>
        protected FrameworkElement Child = null;
    }
}
