using System.Windows.Documents;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents an icon that uses a glyph from the Segoe MDL2 Assets font as its content.
    /// </summary>
    [TemplatePart(Name = "PART_Glyph", Type = typeof(TextBlock))]
    public sealed class SymbolIcon : IconElement
    {
        /// <summary>
        /// Initializes a new instance of the SymbolIcon class.
        /// </summary>
        public SymbolIcon() : base()
        {
            this.DefaultStyleKey = typeof(SymbolIcon);

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
        /// Gets or sets the symbol that is displayed.
        /// </summary>
        public Symbol Symbol
        {
            get => (Symbol)GetValue(SymbolProperty);
            set => SetValue(SymbolProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Foreground dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundProperty =
                TextElement.ForegroundProperty.AddOwner(typeof(SymbolIcon), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Identifies the FontSize dependency property.
        /// </summary>
        public static readonly DependencyProperty FontSizeProperty =
                TextElement.FontSizeProperty.AddOwner(typeof(SymbolIcon), new FrameworkPropertyMetadata(14d, FontSizeChanged_Callback));

        /// <summary>
        /// Identifies the Symbol dependency property.
        /// </summary>
        public static readonly DependencyProperty SymbolProperty =
                DependencyProperty.Register(nameof(Symbol), typeof(Symbol), typeof(SymbolIcon), new PropertyMetadata(Symbol.None, SymbolChanged_Callback));

        #endregion

        #region Callbacks

        private static void FontSizeChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is SymbolIcon icon)
            {
                (icon.Child as TextBlock).FontSize = (double)e.NewValue;
            }
        }

        private static void SymbolChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is SymbolIcon icon)
            {
                (icon.Child as TextBlock).Text = $"{(char)(Symbol)e.NewValue}";
            }
        }

        #endregion
    }
}
