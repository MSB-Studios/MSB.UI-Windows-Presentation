using System.Windows.Documents;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows;
using System;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents an icon that uses a glyph from the specified font.
    /// </summary>
    [TemplatePart(Name = "PART_Glyph", Type = typeof(TextBlock))]
    public sealed class FontIcon : IconElement
    {
        /// <summary>
        /// Initializes a new instance of the FontIcon class.
        /// </summary>
        public FontIcon()
        {
            this.DefaultStyleKey = typeof(FontIcon);

            // add the child...
            AddVisualChild(child);
        }

        #region Properties

        /// <inheritdoc/>
        protected override int VisualChildrenCount
        {
            get => 1;
        }

        /// <summary>
        /// Gets or sets the font size.
        /// </summary>
        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the character code that identifies the icon glyph.
        /// </summary>
        public string Glyph
        {
            get => (string)GetValue(GlyphProperty);
            set => SetValue(GlyphProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the FontSize dependency property.
        /// </summary>
        public static readonly DependencyProperty FontSizeProperty =
                TextElement.ForegroundProperty.AddOwner(typeof(FontIcon));

        /// <summary>
        /// Identifies the Glyph dependency property.
        /// </summary>
        public static readonly DependencyProperty GlyphProperty =
                DependencyProperty.Register(nameof(Glyph), typeof(string), typeof(FontIcon), new PropertyMetadata(string.Empty, GlyphChanged_Callback));

        #endregion

        #region Callbacks

        private static void GlyphChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is FontIcon fontIcon)
            {
                fontIcon.child.Text = (string)e.NewValue;
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        protected override void OnForegroundChanged(DependencyPropertyChangedEventArgs e)
        {
            child.Foreground = (Brush)e.NewValue;
        }

        /// <inheritdoc/>
        protected override Visual GetVisualChild(int index)
        {
            return index is 0 ? child : throw new ArgumentOutOfRangeException(nameof(index));
        }

        /// <inheritdoc/>
        protected override Size MeasureOverride(Size availableSize)
        {
            child.Measure(availableSize);

            return child.DesiredSize;
        }

        /// <inheritdoc/>
        protected override Size ArrangeOverride(Size finalSize)
        {
            child.Arrange(new Rect(finalSize));

            return finalSize;
        }

        #endregion

        readonly TextBlock child = new()
        {
            Name = "PART_Glyph",
            FontFamily = new FontFamily("Segoe MDL2 Assets"),
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center
        };
    }
}
