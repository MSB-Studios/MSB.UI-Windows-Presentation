using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows;
using MSB.UI.Controls;
using System;

namespace MSB.UI
{
    /// <summary>
    /// Represents a window with new functions, such as the ability to hide the icon,
    /// the title or cover the title bar with its contents.
    /// </summary>
    public class AeroWindow : Window
    {
        Button minButton, maxButton, closeButton;
        Rectangle titleBarRect;

        /// <summary>
        /// Initializes a new instance of the 'AeroWindow' class.
        /// </summary>
        public AeroWindow()
        {
            this.DefaultStyleKey = typeof(AeroWindow);
        }

        #region Properties

        /// <summary>
        /// Gets or sets a value that indicates whether the contents of the window
        /// should extend into the title bar.
        /// <para>Note: Changing the value to **true** will hide the draggable area of the window.</para>
        /// <para>The default is **<see langword="false"/>**.</para>
        /// </summary>
        public bool ExtendViewIntoTitleBar
        {
            get => (bool)GetValue(ExtendViewIntoTitleBarProperty);
            set => SetValue(ExtendViewIntoTitleBarProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the icon in the title bar should be displayed.
        /// <para>The default is **<see langword="true"/>**.</para>
        /// </summary>
        public bool IsIconVisible
        {
            get => (bool)GetValue(IsIconVisibleProperty);
            set => SetValue(IsIconVisibleProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the window title should be displayed or not.
        /// <para>The default is **<see langword="true"/>**.</para>
        /// </summary>
        public bool IsTitleVisible
        {
            get => (bool)GetValue(IsTitleVisibleProperty);
            set => SetValue(IsTitleVisibleProperty, value);
        }

        /// <summary>
        /// Gets the flyout of the window.
        /// </summary>
        [Obsolete]
        public Flyout Flyout
        {
            get => (Flyout)GetValue(FlyoutProperty);
            set => SetValue(FlyoutProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the flyout is open.
        /// </summary>
        [Obsolete]
        internal bool IsFlyoutOpen
        {
            get => (bool)GetValue(IsFlyoutOpenProperty);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the ExtendViewIntoTitleBar dependency property.
        /// </summary>
        public static readonly DependencyProperty ExtendViewIntoTitleBarProperty =
                DependencyProperty.Register(nameof(ExtendViewIntoTitleBar), typeof(bool), typeof(AeroWindow), new PropertyMetadata(false));

        /// <summary>
        /// Identifies the IsIconVisible dependency property.
        /// </summary>
        public static readonly DependencyProperty IsIconVisibleProperty =
                DependencyProperty.Register(nameof(IsIconVisible), typeof(bool), typeof(AeroWindow), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the IsTitleVisible dependency property.
        /// </summary>
        public static readonly DependencyProperty IsTitleVisibleProperty =
                DependencyProperty.Register(nameof(IsTitleVisible), typeof(bool), typeof(AeroWindow), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the FlyoutContent dependency property.
        /// </summary>
        [Obsolete]
        public static readonly DependencyProperty FlyoutProperty =
                DependencyProperty.Register(nameof(Flyout), typeof(Flyout), typeof(AeroWindow), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the IsFlyoutOpen dependency property.
        /// </summary>
        [Obsolete]
        public static readonly DependencyProperty IsFlyoutOpenProperty =
                DependencyProperty.Register(nameof(IsFlyoutOpen), typeof(bool), typeof(AeroWindow), new PropertyMetadata(false));

        #endregion

        #region Methods

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (titleBarRect is not null)
                titleBarRect.MouseDown -= TitleBar_MouseDown;

            if (minButton is not null)
                minButton.Click -= MinimizeButton_Click;
            if (maxButton is not null)
                maxButton.Click -= MaxResButton_Click;
            if (closeButton is not null)
                closeButton.Click -= CloseButton_Click;

            titleBarRect = (Rectangle)GetTemplateChild("TitleBarRect");
            minButton = (Button)GetTemplateChild("Minimize");
            maxButton = (Button)GetTemplateChild("MaxRest");
            closeButton = (Button)GetTemplateChild("Close");

            if (titleBarRect is not null)
                titleBarRect.MouseDown += TitleBar_MouseDown;

            if (minButton is not null)
                minButton.Click += MinimizeButton_Click;
            if (maxButton is not null)
                maxButton.Click += MaxResButton_Click;
            if (closeButton is not null)
                closeButton.Click += CloseButton_Click;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void MaxResButton_Click(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    SystemCommands.RestoreWindow(this);
                    break;
                case WindowState.Normal:
                    SystemCommands.MaximizeWindow(this);
                    break;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton is MouseButtonState.Pressed)
                this.DragMove();
        }

        #endregion
    }
}
