using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System;

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
        public PathIcon()
        {
            this.DefaultStyleKey = typeof(PathIcon);

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
        /// Gets or sets a Geometry that specifies the shape to be drawn.
        /// <para>In XAML this can also be set using the Path Markup Syntax.</para>
        /// </summary>
        public Geometry Data
        {
            get => (Geometry)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating when the geometric figure is closed.
        /// <para>**<see langword="true"/>** causes the <see cref="IconElement.Foreground"/> property to affect the fill, and **<see langword="false"/>** affects the stroke.</para>
        /// <para>The default is **<see langword="true"/>**.</para>
        /// </summary>
        public bool IsInverted
        {
            get => (bool)GetValue(IsInvertedProperty);
            set => SetValue(IsInvertedProperty, value);
        }

        /// <summary>
        /// Gets or sets the width of the <see cref="Shape"/> outline.
        /// <para>The default is 0.</para>
        /// </summary>
        public double StrokeThickness
        {
            get => (double)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Data dependency property.
        /// </summary>
        public static readonly DependencyProperty DataProperty =
                DependencyProperty.Register(nameof(Data), typeof(Geometry), typeof(PathIcon), new PropertyMetadata(null, DataChanged_Callback));

        /// <summary>
        /// Identifies the IsInverted dependency property.
        /// </summary>
        public static readonly DependencyProperty IsInvertedProperty =
                DependencyProperty.Register(nameof(IsInverted), typeof(bool), typeof(PathIcon), new PropertyMetadata(true, InvertChanged_Callback));

        /// <summary>
        /// Identifies the StrokeThickness dependency property.
        /// </summary>
        public static readonly DependencyProperty StrokeThicknessProperty =
                DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(PathIcon), new PropertyMetadata(0d, StrokeThicknessChanged_Callback));

        #endregion

        #region Callbacks

        private static void DataChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is PathIcon pathIcon)
            {
                pathIcon.child.Data = (Geometry)e.NewValue;
            }
        }

        private static void InvertChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is PathIcon pathIcon)
            {
                if ((bool)e.NewValue)
                {
                    pathIcon.child.Stroke = null;
                    pathIcon.child.Fill = pathIcon.Foreground;

                    pathIcon.StrokeThickness = 0d;
                }
                else
                {
                    pathIcon.child.Fill = null;
                    pathIcon.child.Stroke = pathIcon.Foreground;

                    pathIcon.StrokeThickness = 1d;
                }
            }
        }

        private static void StrokeThicknessChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is PathIcon pathIcon)
            {
                if (pathIcon.IsInverted)
                    throw new InvalidOperationException();

                pathIcon.child.StrokeThickness = (double)e.NewValue;
            }
        }

        #endregion

        #region Methods

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

        readonly Path child = new()
        {
            Name = "PART_Path",
            Stretch = Stretch.Uniform
        };
    }
}
