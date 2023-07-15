using System.ComponentModel;
using System.Windows;
using MSB.Collections;

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

            nav.MenuItems.PropertyChanged += OnMenuPropertyChanged;
            nav.FooterItems.PropertyChanged += OnFooterPropertyChanged;
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
        public double ButtonsPanelLength
        {
            get => (double)GetValue(ButtonsPanelLengthProperty);
        }

        /// <summary>
        /// Gets the visibility of the menu items.
        /// </summary>
        public Visibility MenuItemsVisibility
        {
            get => (Visibility)GetValue(MenuItemsVisibilityProperty);
        }

        /// <summary>
        /// Gets the visibility of the footer items.
        /// </summary>
        public Visibility FooterItemsVisibility
        {
            get => (Visibility)GetValue(FooterItemsVisibilityProperty);
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

        internal static readonly DependencyProperty ButtonsPanelLengthProperty =
                DependencyProperty.Register(nameof(ButtonsPanelLength), typeof(double), typeof(NavigationViewTemplateSettings), new PropertyMetadata(48d));

        internal static readonly DependencyProperty MenuItemsVisibilityProperty =
                DependencyProperty.Register(nameof(MenuItemsVisibility), typeof(Visibility), typeof(NavigationViewTemplateSettings), new PropertyMetadata(Visibility.Collapsed));

        internal static readonly DependencyProperty FooterItemsVisibilityProperty =
               DependencyProperty.Register(nameof(FooterItemsVisibility), typeof(Visibility), typeof(NavigationViewTemplateSettings), new PropertyMetadata(Visibility.Collapsed));

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
            SetValue(ButtonsPanelLengthProperty, length);
        }

        private void OnMenuPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is not ItemCollection collection)
                return;

            SetValue(MenuItemsVisibilityProperty, collection.Count > 0 ? Visibility.Visible : Visibility.Collapsed);
        }

        private void OnFooterPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is not ItemCollection collection)
                return;

            SetValue(FooterItemsVisibilityProperty, collection.Count > 0 ? Visibility.Visible : Visibility.Collapsed);
        }

        #endregion

        readonly NavigationView owner;
    }
}

