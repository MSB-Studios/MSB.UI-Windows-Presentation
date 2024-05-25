using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows;
using System;

namespace MSB.UI.Controls
{
    /// <summary>
    /// A control that displays a message to the user in a banner.
    /// </summary>
    public sealed class ToastAlert : Control
    {
        readonly DispatcherTimer timer = null;
        private Button btnHide = null;

        /// <summary>
        /// Initializes a new instance of the 'ToastAlert' class.
        /// </summary>
        public ToastAlert()
        {
            DefaultStyleKey = typeof(ToastAlert);

            this.timer = new();
            this.timer.Tick += OnTimerTick;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the message to display.
        /// <para>The default is an empty string.</para>
        /// </summary>
        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        /// <summary>
        /// Gets or sets the severity of the message.
        /// <para>The default is **Information**.</para>
        /// </summary>
        public ToastAlertSeverity Severity
        {
            get => (ToastAlertSeverity)GetValue(SeverityProperty);
            set => SetValue(SeverityProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the alert should be automatically hidden.
        /// <para>The default is **true**.</para>
        /// </summary>
        public bool AutoHideEnabled
        {
            get => (bool)GetValue(AutoHideEnabledProperty);
            set => SetValue(AutoHideEnabledProperty, value);
        }

        /// <summary>
        /// Gets or sets the delay before the alert is hidden.
        /// <para>The default is 3000 milliseconds.</para>
        /// </summary>
        public int AutoHideDelay
        {
            get => (int)GetValue(AutoHideDelayProperty);
            set => SetValue(AutoHideDelayProperty, value);
        }

        /// <summary>
        /// 
        /// </summary>
        internal bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Message dependency property.
        /// </summary>
        public static readonly DependencyProperty MessageProperty =
                DependencyProperty.Register(nameof(Message), typeof(string), typeof(ToastAlert), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Identifies the Severity dependency property.
        /// </summary>
        public static readonly DependencyProperty SeverityProperty =
                            DependencyProperty.Register(nameof(Severity), typeof(ToastAlertSeverity), typeof(ToastAlert), new PropertyMetadata(ToastAlertSeverity.Information));

        /// <summary>
        /// Identifies the AutoHideEnabled dependency property.
        /// </summary>
        public static readonly DependencyProperty AutoHideEnabledProperty =
                DependencyProperty.Register(nameof(AutoHideEnabled), typeof(bool), typeof(ToastAlert), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the AutoHideDelay dependency property.
        /// </summary>
        public static readonly DependencyProperty AutoHideDelayProperty =
                DependencyProperty.Register(nameof(AutoHideDelay), typeof(int), typeof(ToastAlert), new PropertyMetadata(3000));

        /// <summary>
        /// 
        /// </summary>
        internal static readonly DependencyProperty IsOpenProperty =
                DependencyProperty.Register(nameof(IsOpen), typeof(bool), typeof(ToastAlert), new PropertyMetadata(false, IsOpenChanged));

        #endregion

        #region Callbacks

        private static void IsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is ToastAlert toast)
            {
                toast.UpdateVisualState();
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (btnHide is not null)
                btnHide.Click -= OnHideButtonClick;

            btnHide = (Button)GetTemplateChild("HideButton");

            if (btnHide is not null)
                btnHide.Click += OnHideButtonClick;

            UpdateVisualState();
        }

        private void UpdateVisualState()
        {
            VisualStateManager.GoToState(this, this.IsOpen ? "Open" : "Closed", true);
        }

        private void OnHideButtonClick(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            this.IsOpen = false;
        }

        private void OnTimerTick(object sender, System.EventArgs e)
        {
            this.IsOpen = false;

            timer.Stop();
        }

        /// <summary>
        /// Displays the alert.
        /// </summary>
        public void Show()
        {
            this.IsOpen = true;

            if (this.AutoHideEnabled)
            {
                timer.Interval = TimeSpan.FromMilliseconds(this.AutoHideDelay);
                timer.Start();
            }
        }

        #endregion
    }
}
