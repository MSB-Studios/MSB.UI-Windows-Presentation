﻿using System.Windows;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents a dialog box that displays a message and returns a value.
    /// </summary>
    public sealed class MessageDialog : FrameworkElement
    {
        #region Fields

        DialogWindow hostWindow;

        #endregion

        /// <summary>
        /// Initializes a new instance of the 'MessageDialog' class.
        /// </summary>
        public MessageDialog()
        {
            this.DefaultStyleKey = typeof(MessageDialog);
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
        /// Gets or sets the text to display.
        /// </summary>
        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
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
        /// Identifies the Caption dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
                DependencyProperty.Register(nameof(Title), typeof(string), typeof(MessageDialog), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Identifies the Content dependency property.
        /// </summary>
        public static readonly DependencyProperty MessageProperty =
                DependencyProperty.Register(nameof(Message), typeof(string), typeof(MessageDialog), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Identifies the Buttons dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsProperty =
                DependencyProperty.Register(nameof(Buttons), typeof(DialogButton), typeof(MessageDialog), new PropertyMetadata(DialogButton.OK));

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
