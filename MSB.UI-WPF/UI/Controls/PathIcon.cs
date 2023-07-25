using System.Windows.Documents;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents an icon that uses a vector path as its content.
    /// </summary>
    [TemplatePart(Name = "PART_Path", Type = typeof(Path))]
    public sealed class PathIcon : IconElement
    {
        /// <summary>
        /// Initializes a new instance of the PathIcon class.
        /// </summary>
        public PathIcon() : base()
        {
            this.DefaultStyleKey = typeof(PathIcon);

            // set 'n' add the child...
            AddVisualChild(Child = new Path
            {
                Name = "PART_Path",
                Stretch = Stretch.Uniform
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
        /// Gets or sets a Geometry that specifies the shape to be drawn.
        /// <para>In XAML this can also be set using the Path Markup Syntax.</para>
        /// </summary>
        public Geometry Data
        {
            get => (Geometry)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Foreground dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundProperty =
                TextElement.ForegroundProperty.AddOwner(typeof(PathIcon), new FrameworkPropertyMetadata(null, ForegroundChanged_Callback));

        /// <summary>
        /// Identifies the Data dependency property.
        /// </summary>
        public static readonly DependencyProperty DataProperty =
                DependencyProperty.Register(nameof(Data), typeof(Geometry), typeof(PathIcon), new PropertyMetadata(null, DataChanged_Callback));

        #endregion

        #region Callbacks

        private static void ForegroundChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is PathIcon icon)
            {
                (icon.Child as Path).Fill = (Brush)e.NewValue;
            }
        }

        private static void DataChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is PathIcon icon)
            {
                (icon.Child as Path).Data = (Geometry)e.NewValue;
            }
        }
        
        #endregion
    }
}
