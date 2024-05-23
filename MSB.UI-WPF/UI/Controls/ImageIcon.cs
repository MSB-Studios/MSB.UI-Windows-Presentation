using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents an icon that uses an image as its content.
    /// </summary>
    [TemplatePart(Name = "PART_Image", Type = typeof(Image))]
    public sealed class ImageIcon : IconElement
    {
        /// <summary>
        /// Initializes a new instance of the ImageIcon class.
        /// </summary>
        public ImageIcon() : base()
        {
            this.DefaultStyleKey = typeof(ImageIcon);

            // set 'n' add the child...
            AddVisualChild(Child = new Image
            {
                Name = "PART_Image",
                Stretch = Stretch.Uniform
            });
        }

        #region Properties

        /// <summary>
        /// Gets or sets the image source to represent the icon.
        /// </summary>
        public ImageSource Source
        {
            get => (ImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        #endregion

        #region Dependency Properties

        /// <summary>
        /// Identifies the Source dependency property.
        /// </summary>
        public static readonly DependencyProperty SourceProperty =
                DependencyProperty.Register(nameof(Source), typeof(ImageSource), typeof(ImageIcon), new PropertyMetadata(null, SourceChanged_Callback));

        #endregion

        #region Callbacks

        private static void SourceChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is ImageIcon icon)
            {
                (icon.Child as Image).Source = (ImageSource)e.NewValue;
            }
        }

        #endregion
    }
}
