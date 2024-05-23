using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents an extentions of the 'ButtonBase' class that displays an icon.
    /// </summary>
    [ContentProperty(nameof(Icon))]
    public sealed class AppBarButton : ButtonBase
    {
        /// <summary>
        /// Initializes a new instance of 'AppBarButton' class.
        /// </summary>
        public AppBarButton()
        {
            this.DefaultStyleKey = typeof(AppBarButton);
        }

        #region Properties

        /// <summary>
        /// Gets or sets the icon to be displayed on the control.
        /// <para>The default is **null**.</para>
        /// </summary>
        public IconElement Icon
        {
            get => (IconElement)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        /// Gets or sets the text to be displayed on the control.
        /// <para>The default is an empty string.</para>
        /// </summary>
        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        /// <summary>
        /// Gets or sets the position of the label relative to the icon.
        /// <para>The default is **Bottom**.</para>
        /// </summary>
        public LabelPosition LabelPosition
        {
            get => (LabelPosition)GetValue(LabelPositionProperty);
            set => SetValue(LabelPositionProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Icon dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
                    DependencyProperty.Register(nameof(Icon), typeof(IconElement), typeof(AppBarButton), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the Label dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelProperty =
                    DependencyProperty.Register(nameof(Label), typeof(string), typeof(AppBarButton), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Identifies the LabelPosition dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelPositionProperty =
                    DependencyProperty.Register(nameof(LabelPosition), typeof(LabelPosition), typeof(AppBarButton), new PropertyMetadata(LabelPosition.Bottom));

        #endregion
    }
}
