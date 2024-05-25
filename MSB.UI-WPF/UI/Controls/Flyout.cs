using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows;
using System;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents a control to display content in a popup view.
    /// </summary>
    [Obsolete]
    public sealed class Flyout : ContentControl
    {
        /// <summary>
        /// Initializes a new instance of the 'Flyout' class.
        /// </summary>
        public Flyout()
        {
            this.DefaultStyleKey = typeof(Flyout);
        }

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the Flyout is open.
        /// </summary>
        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set
            {
                if (value)
                    this.Opening?.Invoke(this, EventArgs.Empty);
                else
                    if (!CheckCanClose())
                        return;

                SetValue(IsOpenProperty, value);
            }
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the IsOpen dependency property.
        /// </summary>
        public static readonly DependencyProperty IsOpenProperty =
                DependencyProperty.Register(nameof(IsOpen), typeof(bool), typeof(Flyout), new PropertyMetadata(false, IsOpenChanged_Callback));

        #endregion

        #region Callbacks

        private static async void IsOpenChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is Flyout flyout)
            {
                // update the visual state...
                flyout.UpdateVisualState();

                if ((bool)e.NewValue)
                {
                    flyout.Opened?.Invoke(flyout, EventArgs.Empty);
                }
                else
                {
                    await Task.Delay(260);
                    flyout.Closed?.Invoke(flyout, EventArgs.Empty);
                }
                    
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            UpdateVisualState();
        }

        private bool UpdateVisualState()
        {
            return VisualStateManager.GoToState(this, this.IsOpen ? "Open" : "Closed", true);
        }

        private bool CheckCanClose()
        {
            if (this.Closing is not null)
            {
                var args = new FlyoutClosingEventArgs();

                foreach (var closingDelegate in this.Closing.GetInvocationList())
                {
                    if (closingDelegate is not TypedEventHandler<object, FlyoutClosingEventArgs> handler)
                        continue;

                    handler(this, args);

                    if (args.Cancel)
                        return false;
                }
            }

            return true;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the Flyout is opened.
        /// </summary>
        public event TypedEventHandler<object, EventArgs> Opened;

        /// <summary>
        /// Occurs when the Flyout is opening.
        /// </summary>
        public event TypedEventHandler<object, EventArgs> Opening;

        /// <summary>
        /// Occurs when the Flyout is closed.
        /// </summary>
        public event TypedEventHandler<object, EventArgs> Closed;

        /// <summary>
        /// Occurs when the Flyout is closing.
        /// </summary>
        public event TypedEventHandler<object, FlyoutClosingEventArgs> Closing;

        #endregion
    }
}
