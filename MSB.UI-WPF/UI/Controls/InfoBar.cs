using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;

namespace MSB.UI.Controls
{
    /// <summary>
    /// A control that displays a message to the user in a banner.
    /// </summary>
    public sealed class InfoBar : Control
    {
        private Button btnClose = null;

        /// <summary>
        /// Initializes a new instance of the 'InfoBar' class.
        /// </summary>
        public InfoBar()
        {
            this.DefaultStyleKey = typeof(InfoBar);
        }

        #region Properties

        /// <summary>
        /// Gets or sets the title of the message.
        /// <para>The default is an empty string.</para>
        /// </summary>
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// Gets or sets the message to display.
        /// <para>The default is an empty string.</para>
        /// <para>The control will automatically switch to a long message style if the message is longer than **92** characters.</para>
        /// </summary>
        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        /// <summary>
        /// Gets or sets the severity of the message.
        /// <para>The default is **Informational**.</para>
        /// </summary>
        public InfoBarSeverity Severity
        {
            get => (InfoBarSeverity)GetValue(SeverityProperty);
            set => SetValue(SeverityProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the alert is open.
        /// <para>The default is **false**.</para>
        /// </summary>
        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the icon is visible.
        /// <para>The default is **true**.</para>
        /// </summary>
        public bool IsIconVisible
        {
            get => (bool)GetValue(IsIconVisibleProperty);
            set => SetValue(IsIconVisibleProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the alert is closable.
        /// <para>The default is **true**.</para>
        /// </summary>
        public bool IsClosable
        {
            get => (bool)GetValue(IsClosableProperty);
            set => SetValue(IsClosableProperty, value);
        }

        /// <summary>
        /// Gets or sets the command to execute when the close button is clicked.
        /// </summary>
        public ICommand CloseButtonCommand
        {
            get => (ICommand)GetValue(CloseButtonCommandProperty);
            set => SetValue(CloseButtonCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the parameter to pass to the <see cref="CloseButtonCommand"/>.
        /// </summary>
        public object CloseButtonCommandParameter
        {
            get => GetValue(CloseButtonCommandParameterProperty);
            set => SetValue(CloseButtonCommandParameterProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Title dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
                DependencyProperty.Register(nameof(Title), typeof(string), typeof(InfoBar), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Identifies the Message dependency property.
        /// </summary>
        public static readonly DependencyProperty MessageProperty =
                DependencyProperty.Register(nameof(Message), typeof(string), typeof(InfoBar), new PropertyMetadata(string.Empty, MessageChanged));

        /// <summary>
        /// Identifies the Severity dependency property.
        /// </summary>
        public static readonly DependencyProperty SeverityProperty =
                            DependencyProperty.Register(nameof(Severity), typeof(InfoBarSeverity), typeof(InfoBar), new PropertyMetadata(InfoBarSeverity.Informational));

        /// <summary>
        /// Identifies the IsOpen dependency property.
        /// </summary>
        internal static readonly DependencyProperty IsOpenProperty =
                DependencyProperty.Register(nameof(IsOpen), typeof(bool), typeof(InfoBar), new PropertyMetadata(false, IsOpenChanged));

        /// <summary>
        /// Identifies the IsIconVisible dependency property.
        /// </summary>
        public static readonly DependencyProperty IsIconVisibleProperty =
                DependencyProperty.Register(nameof(IsIconVisible), typeof(bool), typeof(InfoBar), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the IsClosable dependency property.
        /// </summary>
        public static readonly DependencyProperty IsClosableProperty =
                DependencyProperty.Register(nameof(IsClosable), typeof(bool), typeof(InfoBar), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the CloseButtonCommand dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonCommandProperty =
                DependencyProperty.Register(nameof(CloseButtonCommand), typeof(ICommand), typeof(InfoBar), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the CloseButtonCommandParameter dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonCommandParameterProperty =
                DependencyProperty.Register(nameof(CloseButtonCommandParameter), typeof(object), typeof(InfoBar), new PropertyMetadata(null));

        #endregion

        #region Callbacks

        private static void MessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is InfoBar bar)
            {
                bar.UpdateVisualState();
            }
        }

        private static void IsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is InfoBar bar)
            {
                bar.UpdateVisualState();
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this.btnClose != null)
                this.btnClose.Click -= this.OnCloseButtonClick;

            this.btnClose = (Button)this.GetTemplateChild("CloseButton");

            if (this.btnClose != null)
                this.btnClose.Click += this.OnCloseButtonClick;

            UpdateVisualState();
        }

        private void UpdateVisualState()
        {
            VisualStateManager.GoToState(this, this.IsOpen ? "Open" : "Closed", true);
            VisualStateManager.GoToState(this, this.Message.Length > 92 ? "Long" : "Short", false);
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.IsOpen = false;
            this.CloseButtonClick?.Invoke(this, e);
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the close button is clicked.
        /// </summary>
        public event TypedEventHandler<object, RoutedEventArgs> CloseButtonClick;

        #endregion
    }
}
