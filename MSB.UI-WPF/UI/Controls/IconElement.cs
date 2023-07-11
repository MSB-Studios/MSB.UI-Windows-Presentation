using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;

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
        /// Gets or sets a brush that describes the foreground color.
        /// </summary>
        public Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        #endregion

        #region Dependency property

        /// <summary>
        /// Identifies the Foreground dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundProperty =
                TextElement.ForegroundProperty.AddOwner(typeof(IconElement), new FrameworkPropertyMetadata(null, ForegroundChanged_Callback));

        #endregion

        #region Callbacks

        private static void ForegroundChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is IconElement iconElement)
            {
                iconElement.OnForegroundChanged(e);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the effective property value of the Foreground property changes.
        /// </summary>
        /// <param name="e">The data for the event. </param>
        protected virtual void OnForegroundChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion
    }
}
