using System.Windows;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents a dialog box that displays a custom content and returns a value.
    /// </summary>
    public sealed class ContentDialog : FrameworkElement
    {
        #region Fields

        DialogWindow hostWindow;

        #endregion

        /// <summary>
        /// Initialize a new instance of the 'ContentDialog' class.
        /// </summary>
        public ContentDialog()
        {
            this.DefaultStyleKey = typeof(ContentDialog);
        }

        #region Properties

        /// <summary>
        /// Gets or sets the title bar caption to display.
        /// </summary>
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// Gets or sets the content to display.
        /// </summary>
        public UIElement Content
        {
            get => (UIElement)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        /// <summary>
        /// Gets or sets a value that specifies which button or buttons to display.
        /// </summary>
        public DialogButton Buttons
        {
            get => (DialogButton)GetValue(ButtonsProperty);
            set => SetValue(ButtonsProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Title dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
                DependencyProperty.Register("Title", typeof(string), typeof(ContentDialog), new PropertyMetadata(string.Empty));
        
        /// <summary>
        /// Identifies the Content dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentProperty =
                DependencyProperty.Register("Content", typeof(UIElement), typeof(ContentDialog), new PropertyMetadata(null));
        
        /// <summary>
        /// Identifies the Buttons dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsProperty =
                DependencyProperty.Register("Buttons", typeof(DialogButton), typeof(ContentDialog), new PropertyMetadata(DialogButton.OK));

        #endregion

        #region Methods

        /// <summary>
        /// Displays the dialog that has a message and that returns a Result.
        /// </summary>
        /// <returns>A <see cref="DialogResult"/> value that specifies which message dialog button
        /// is clicked by the user.</returns>
        public DialogResult Show()
        {
            hostWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                DataContext = this
            };

            foreach (Window window in Application.Current.Windows)
            {
                if (window.IsActive)
                {
                    hostWindow.Owner = window;
                    break;
                }
            }

            if (hostWindow.Owner is null)
                hostWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            hostWindow.ShowDialog();

            return hostWindow.Result;
        }

        #endregion
    }
}
