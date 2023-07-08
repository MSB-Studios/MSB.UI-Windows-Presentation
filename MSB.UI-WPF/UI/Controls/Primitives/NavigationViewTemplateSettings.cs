using System.Windows;

namespace MSB.UI.Controls.Primitives
{
    /// <summary>
    /// Provides calculated values that can be referenced as TemplatedParent sources when defining templates for a NavigationView.
    /// </summary>
    public sealed class NavigationViewTemplateSettings : DependencyObject
    {
        internal NavigationViewTemplateSettings(NavigationView nav)
        {
            this.owner = nav;
        }

        #region Properties

        /// <summary>
        /// Gets the visibility of the back button.
        /// </summary>
        public Visibility BackButtonVisibility
        {
            get => (Visibility)GetValue(BackButtonVisibilityProperty);
        }

        /// <summary>
        /// Gets the visibility of the pane toggle button.
        /// </summary>
        public Visibility PaneToggleButtonVisibility
        {
            get => (Visibility)GetValue(PaneToggleButtonVisibilityProperty);
        }

        /// <summary>
        /// Gets the visibility of the left pane.
        /// </summary>
        public Visibility LeftPaneVisibility
        {
            get => (Visibility)GetValue(LeftPaneVisibilityProperty);
        }

        /// <summary>
        /// Gets the margin value that contains in the upper side the TitleBar length. 
        /// </summary>
        public Thickness TitleBarMargin
        {
            get => (Thickness)GetValue(TitleBarMarginProperty);
        }

        /// <summary>
        /// Gets the length of the buttons panel.
        /// </summary>
        public GridLength ButtonsPanelGridLength
        {
            get => (GridLength)GetValue(ButtonsPanelGridLengthProperty);
        }

        #endregion

        #region Dependency properties

        internal static readonly DependencyProperty BackButtonVisibilityProperty =
                DependencyProperty.Register(nameof(BackButtonVisibility), typeof(Visibility), typeof(NavigationViewTemplateSettings), new PropertyMetadata(Visibility.Visible));

        internal static readonly DependencyProperty PaneToggleButtonVisibilityProperty =
                DependencyProperty.Register(nameof(PaneToggleButtonVisibility), typeof(Visibility), typeof(NavigationViewTemplateSettings), new PropertyMetadata(Visibility.Visible));

        internal static readonly DependencyProperty LeftPaneVisibilityProperty =
                DependencyProperty.Register(nameof(LeftPaneVisibility), typeof(Visibility), typeof(NavigationViewTemplateSettings), new PropertyMetadata(Visibility.Collapsed));

        internal static readonly DependencyProperty TitleBarMarginProperty =
                DependencyProperty.Register(nameof(TitleBarMargin), typeof(Thickness), typeof(NavigationViewTemplateSettings), new PropertyMetadata(new Thickness(0, 32, 0, 0)));

        internal static readonly DependencyProperty ButtonsPanelGridLengthProperty =
                DependencyProperty.Register(nameof(ButtonsPanelGridLength), typeof(GridLength), typeof(NavigationViewTemplateSettings), new PropertyMetadata(new GridLength(48d)));

        #endregion

        #region Methods

        internal void Update()
        {
            if (this.owner.DisplayMode is NavigationViewDisplayMode.Minimal && !this.owner.IsPaneOpen)
                SetValue(LeftPaneVisibilityProperty, Visibility.Collapsed);
            else
                SetValue(LeftPaneVisibilityProperty, Visibility.Visible);

            SetValue(BackButtonVisibilityProperty, this.owner.IsBackButtonVisible ? Visibility.Visible : Visibility.Collapsed);
        }

        internal void UpdateButtonsPanelLength(double length)
        {
            SetValue(ButtonsPanelGridLengthProperty, new GridLength(length));
        }

        #endregion

        readonly NavigationView owner;
    }
}

