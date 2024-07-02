using System.Windows.Documents;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows;

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
        public FontIcon() : base()
        {
            this.DefaultStyleKey = typeof(FontIcon);

            // set 'n' add the child...
            AddVisualChild(Child = new TextBlock
            {
                Name = "PART_Glyph",
                FontSize = 14,
                FontFamily = new FontFamily("Segoe MDL2 Assets"),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            });
        }

        #region Properties

        /// <summary>
        /// Gets or sets a brush that describes the foreground color.
        /// </summary>
        public Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
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
        /// Identifies the Foreground dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundProperty =
                TextElement.ForegroundProperty.AddOwner(typeof(FontIcon), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Identifies the FontSize dependency property.
        /// </summary>
        public static readonly DependencyProperty FontSizeProperty =
                TextElement.FontSizeProperty.AddOwner(typeof(FontIcon), new FrameworkPropertyMetadata(14d, FontSizeChanged_Callback));

        /// <summary>
        /// Identifies the Glyph dependency property.
        /// </summary>
        public static readonly DependencyProperty GlyphProperty =
                DependencyProperty.Register(nameof(Glyph), typeof(string), typeof(FontIcon), new PropertyMetadata(string.Empty, GlyphChanged_Callback));

        #endregion

        #region Callbacks

        private static void FontSizeChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is FontIcon icon)
            {
                (icon.Child as TextBlock).FontSize = (double)e.NewValue;
            }
        }

        private static void GlyphChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is FontIcon icon)
            {
                (icon.Child as TextBlock).Text = (string)e.NewValue;
            }
        }

        #endregion
    }
}
