using ItemCollection = MSB.Collections.ItemCollection;
using MSB.UI.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows;
using System;
using System.Runtime.CompilerServices;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents a control that provides a user interface for navigating within an application.
    /// </summary>
    public sealed class NavigationView : ContentControl
    {
        Rectangle _contentDrawableRectangle;
        Rectangle _paneDrawableRectangle;
        NavigationViewList _menuItems, _footerItems;
        Button _backButton, _paneToggleButton;
        StackPanel _panelButtons;

        NavigationViewDisplayMode displayMode;
        bool isClosedByUser = false;

        /// <summary>
        /// Initializes a new instance of the 'NavigationView' class.
        /// </summary>
        public NavigationView()
        {
            this.DefaultStyleKey = typeof(NavigationView);

            SetCurrentValue(TemplateSettingsProperty, new NavigationViewTemplateSettings(this));
        }

        #region Properties

        /// <summary>
        /// Gets the collection of menu items displayed in the NavigationView menu.
        /// <para>The default is an empty collection.</para>
        /// </summary>
        public ItemCollection MenuItems
        {
            get => (ItemCollection)GetValue(MenuItemsProperty);
        }

        /// <summary>
        /// Gets the collection of menu items displayed in the NavigationView footer.
        /// <para>The default is an empty collection.</para>
        /// </summary>
        public ItemCollection FooterItems
        {
            get => (ItemCollection)GetValue(FooterItemsProperty);
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// <para>The default is **<see langword="null"/>**.</para>
        /// </summary>
        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Gets or sets the header content.
        /// <para>The default is **<see langword="null"/>**.</para>
        /// </summary>
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Gets or sets the content for the pane header.
        /// <para>The default is **<see langword="null"/>**.</para>
        /// </summary>
        public object PaneHeader
        {
            get => GetValue(PaneHeaderProperty);
            set => SetValue(PaneHeaderProperty, value);
        }

        /// <summary>
        /// Gets or sets the custom content in the pane.
        /// <para>The default is **<see langword="null"/>**.</para>
        /// </summary>
        public object PaneCustomContent
        {
            get => GetValue(PaneCustomContentProperty);
            set => SetValue(PaneCustomContentProperty, value);
        }

        /// <summary>
        /// Gets or sets the custom content placement in the pane.
        /// </summary>
        [Obsolete]
        public PaneCustomContentPlacement CustomContentPlacement
        {
            get => (PaneCustomContentPlacement)GetValue(CustomContentPlacementProperty);
            set => SetValue(CustomContentPlacementProperty, value);
        }

        /// <summary>
        /// Gets or sets the width of the NavigationView pane in its compact display mode.
        /// <para>The default is 48 pixels.</para>
        /// </summary>
        public double CompactPaneLength
        {
            get => (double)GetValue(CompactPaneLengthProperty);
            set => SetValue(CompactPaneLengthProperty, value);
        }

        /// <summary>
        /// Gets or sets the width of the NavigationView pane when it's fully expanded.
        /// <para>The default is 320 pixels.</para>
        /// </summary>
        public double OpenPaneLength
        {
            get => (double)GetValue(OpenPaneLengthProperty);
            set => SetValue(OpenPaneLengthProperty, value);
        }

        /// <summary>
        /// Gets or sets the minimum window width at which the NavigationView enters **Compact** display mode.
        /// <para>The default is 641 pixels.</para>
        /// </summary>
        public double CompactModeThresholdWidth
        {
            get => (double)GetValue(CompactModeThresholdWidthProperty);
            set => SetValue(CompactModeThresholdWidthProperty, value);
        }

        /// <summary>
        /// Gets or sets the minimum window width at which the NavigationView enters **Expanded** display mode.
        /// <para>The default is 1008 pixels.</para>
        /// </summary>
        public double ExpandedModeThresholdWidth
        {
            get => (double)GetValue(ExpandedModeThresholdWidthProperty);
            set => SetValue(ExpandedModeThresholdWidthProperty, value);
        }

        /// <summary>
        /// Gets or sets a value that specifies whether the NavigationView pane is expanded to its full width.
        /// <para>The default is **<see langword="false"/>**.</para>
        /// </summary>
        public bool IsPaneOpen
        {
            get => (bool)GetValue(IsPaneOpenProperty);
            set => SetValue(IsPaneOpenProperty, value);
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the back button is enabled or disabled.
        /// <para>The default is **<see langword="false"/>**.</para>
        /// </summary>
        public bool IsBackButtonEnabled
        {
            get => (bool)GetValue(IsBackButtonEnabledProperty);
            set => SetValue(IsBackButtonEnabledProperty, value);
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the back button is shown.
        /// <para>The default is **<see langword="true"/>**.</para>
        /// </summary>
        public bool IsBackButtonVisible
        {
            get => (bool)GetValue(IsBackButtonVisibleProperty);
            set => SetValue(IsBackButtonVisibleProperty, value);
        }

        /// <summary>
        /// Gets of sets a value that specifies how the pane and content areas of a NavigationView are shown.
        /// <para>The default is **<see cref="NavigationViewDisplayMode.Auto"/>**.</para>
        /// </summary>
        public NavigationViewDisplayMode DisplayMode
        {
            get => (NavigationViewDisplayMode)GetValue(DisplayModeProperty);
            set => SetValue(DisplayModeProperty, value);
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the top padding of the pane is shown.
        /// <para>The default is **<see langword="false"/>**.</para>
        /// </summary>
        [Obsolete("You can use **NavigationViewPanePadding** and **NavigationViewContentPadding** resources to apply margins as you like.")]
        public bool IsTitleBarPaddingEnabled
        {
            get => (bool)GetValue(IsTitleBarPaddingEnabledProperty);
            set => SetValue(IsTitleBarPaddingEnabledProperty, value);
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the NavigationView is acting as a title bar.
        /// <para>The default is **<see langword="false"/>**.</para>
        /// </summary>
        [Obsolete("It has no effect on the control anymore.")]
        public bool IsActingAsTitleBar
        {
            get => (bool)GetValue(IsActingAsTitleBarProperty);
            set => SetValue(IsActingAsTitleBarProperty, value);
        }

        /// <summary>
        /// Gets an object that provides calculated values that can be referenced as **TemplateBinding** sources when defining
        /// templates for a NavigationView control.
        /// </summary>
        public NavigationViewTemplateSettings TemplateSettings
        {
            get => (NavigationViewTemplateSettings)GetValue(TemplateSettingsProperty);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Items dependency property.
        /// </summary>
        public static readonly DependencyProperty MenuItemsProperty =
                DependencyProperty.Register(nameof(MenuItems), typeof(ItemCollection), typeof(NavigationView), new PropertyMetadata(new ItemCollection()));

        /// <summary>
        /// Identifies the FooterItems dependency property.
        /// </summary>
        public static readonly DependencyProperty FooterItemsProperty =
                DependencyProperty.Register(nameof(FooterItems), typeof(ItemCollection), typeof(NavigationView), new PropertyMetadata(new ItemCollection()));

        /// <summary>
        /// Identifies the SelectedItem dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty =
                DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(NavigationView), new PropertyMetadata(null, SelectedItemChanged_Callback));

        /// <summary>
        /// Identifies the Header dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
                DependencyProperty.Register(nameof(Header), typeof(object), typeof(NavigationView), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the PaneHeader dependency property.
        /// </summary>
        public static readonly DependencyProperty PaneHeaderProperty =
                DependencyProperty.Register(nameof(PaneHeader), typeof(object), typeof(NavigationView), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the PaneCustomContent dependency property.
        /// </summary>
        public static readonly DependencyProperty PaneCustomContentProperty =
                DependencyProperty.Register(nameof(PaneCustomContent), typeof(object), typeof(NavigationView), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the CustomContentPlacement dependency property.
        /// </summary>
        [Obsolete]
        public static readonly DependencyProperty CustomContentPlacementProperty =
                DependencyProperty.Register(nameof(CustomContentPlacement), typeof(PaneCustomContentPlacement), typeof(NavigationView), new PropertyMetadata(PaneCustomContentPlacement.Top));

        /// <summary>
        /// Identifies the CompactPaneLength dependency property.
        /// </summary>
        public static readonly DependencyProperty CompactPaneLengthProperty =
                DependencyProperty.Register(nameof(CompactPaneLength), typeof(double), typeof(NavigationView), new PropertyMetadata(48d));

        /// <summary>
        /// Identifies the OpenPaneLength dependency property.
        /// </summary>
        public static readonly DependencyProperty OpenPaneLengthProperty =
                DependencyProperty.Register(nameof(OpenPaneLength), typeof(double), typeof(NavigationView), new PropertyMetadata(320d));

        /// <summary>
        /// Identifies the CompactModeThresholdWidth dependency property.
        /// </summary>
        public static readonly DependencyProperty CompactModeThresholdWidthProperty =
                DependencyProperty.Register(nameof(CompactModeThresholdWidth), typeof(double), typeof(NavigationView), new PropertyMetadata(641d, CompactModeThresholdWidthChanged_Callback));

        /// <summary>
        /// Identifies the ExpandedModeThresholdWidth dependency property.
        /// </summary>
        public static readonly DependencyProperty ExpandedModeThresholdWidthProperty =
                DependencyProperty.Register(nameof(ExpandedModeThresholdWidth), typeof(double), typeof(NavigationView), new PropertyMetadata(1008d, ExpandedModeThresholdWidthChanged_Callback));

        /// <summary>
        /// Identifies the IsPaneOpen dependency property.
        /// </summary>
        public static readonly DependencyProperty IsPaneOpenProperty =
                DependencyProperty.Register(nameof(IsPaneOpen), typeof(bool), typeof(NavigationView), new PropertyMetadata(false, IsPaneOpenChanged_Callback));

        /// <summary>
        /// Identifies the IsBackButtonEnabled dependency property.
        /// </summary>
        public static readonly DependencyProperty IsBackButtonEnabledProperty =
                DependencyProperty.Register(nameof(IsBackButtonEnabled), typeof(bool), typeof(NavigationView), new PropertyMetadata(false));

        /// <summary>
        /// Identifies the IsBackButtonVisible dependency property.
        /// </summary>
        public static readonly DependencyProperty IsBackButtonVisibleProperty =
                DependencyProperty.Register(nameof(IsBackButtonVisible), typeof(bool), typeof(NavigationView), new PropertyMetadata(true, IsBackButtonVisibleChanged_Callback));

        /// <summary>
        /// Identifies the DisplayMode dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayModeProperty =
                DependencyProperty.Register(nameof(DisplayMode), typeof(NavigationViewDisplayMode), typeof(NavigationView), new PropertyMetadata(NavigationViewDisplayMode.Auto, DisplayModeChanged_Callback));

        /// <summary>
        /// Identifies the IsTitleBarPaddingEnabled dependency property.
        /// </summary>
        [Obsolete]
        public static readonly DependencyProperty IsTitleBarPaddingEnabledProperty =
                DependencyProperty.Register(nameof(IsTitleBarPaddingEnabled), typeof(bool), typeof(NavigationView), new PropertyMetadata(false));

        /// <summary>
        /// Identifies the IsActingAsTitleBar dependency property.
        /// </summary>
        [Obsolete]
        public static readonly DependencyProperty IsActingAsTitleBarProperty =
                DependencyProperty.Register(nameof(IsActingAsTitleBar), typeof(bool), typeof(NavigationView), new PropertyMetadata(false));

        /// <summary>
        /// Identifies the TemplateSettings dependency property.
        /// </summary>
        public static readonly DependencyProperty TemplateSettingsProperty =
                DependencyProperty.Register(nameof(TemplateSettings), typeof(NavigationViewTemplateSettings), typeof(NavigationView), new PropertyMetadata(null));

        #endregion

        #region Callbacks

        private static void SelectedItemChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is NavigationView nav)
            {
                if (e.NewValue is null)
                {
                    nav._menuItems.SelectedItem = null;
                    nav._footerItems.SelectedItem = null;

                    nav.SelectionChanged?.Invoke(nav, new RoutedEventArgs());
                }
                else
                {
                    if (nav._menuItems.Items.Contains(e.NewValue))
                    {
                        nav._menuItems.SelectedItem = e.NewValue;
                        nav._footerItems.SelectedItem = null;

                        nav.ItemInvoked?.Invoke(nav, new RoutedEventArgs());
                        nav.SelectionChanged?.Invoke(nav, new RoutedEventArgs());
                    }
                    else if (nav._footerItems.Items.Contains(e.NewValue))
                    {
                        nav._menuItems.SelectedItem = null;
                        nav._footerItems.SelectedItem = e.NewValue;

                        nav.ItemInvoked?.Invoke(nav, new RoutedEventArgs());
                        nav.SelectionChanged?.Invoke(nav, new RoutedEventArgs());
                    }

                    if (nav.displayMode != NavigationViewDisplayMode.Expanded)
                        nav.IsPaneOpen = false;
                }
            }
        }

        private static void CompactModeThresholdWidthChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is NavigationView nav)
            {
                if ((double)e.NewValue >= nav.ExpandedModeThresholdWidth)
                {
                    throw new ArgumentOutOfRangeException("CompactModeThresholdWidth",
                                                          "The CompactModeThresholdWidth property cannot be greater than the ExpandedModeThresholdWidth property.");
                }
            }
        }

        private static void ExpandedModeThresholdWidthChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is NavigationView nav)
            {
                if ((double)e.NewValue <= nav.CompactModeThresholdWidth)
                {
                    throw new ArgumentOutOfRangeException("ExpandedModeThresholdWidth",
                                                          "The ExpandedModeThresholdWidth property cannot be less than the CompactModeThresholdWidth property.");
                }
            }
        }

        private static void IsPaneOpenChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is NavigationView nav)
            {
                nav.TemplateSettings?.Update();
            }
        }

        private static void IsBackButtonVisibleChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is NavigationView nav)
                nav.TemplateSettings?.Update();
        }

        private static void DisplayModeChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is NavigationView nav)
            {
                nav.displayMode = (NavigationViewDisplayMode)e.NewValue;
                nav.UpdateVisualState();
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this._backButton != null)
                this._backButton.Click -= BackButton_Click;

            if (this._paneToggleButton != null)
                this._paneToggleButton.Click -= PaneToggleButton_Click;

            if (this._menuItems != null)
                this._menuItems.SelectionChanged -= MenuItems_SelectionChanged;

            if (this._footerItems != null)
                this._footerItems.SelectionChanged -= FooterItems_SelectionChanged;

            if (this._paneDrawableRectangle != null)
                this._paneDrawableRectangle.MouseDown -= OnTitleBarDragging;

            if (this._contentDrawableRectangle != null)
                this._contentDrawableRectangle.MouseDown -= OnTitleBarDragging;

            this._backButton = (Button)GetTemplateChild("BackButton");
            this._paneToggleButton = (Button)GetTemplateChild("ToggleButton");
            this._paneDrawableRectangle = (Rectangle)GetTemplateChild("TitleBarPaneRectangle");
            this._contentDrawableRectangle = (Rectangle)GetTemplateChild("TitleBarContentRectangle");
            this._menuItems = (NavigationViewList)GetTemplateChild("MenuItems");
            this._footerItems = (NavigationViewList)GetTemplateChild("FooterItems");
            this._panelButtons = (StackPanel)GetTemplateChild("PART_Buttons");

            if (this._backButton != null)
                this._backButton.Click += BackButton_Click;

            if (this._paneToggleButton != null)
                this._paneToggleButton.Click += PaneToggleButton_Click;

            if (this._menuItems != null)
                this._menuItems.SelectionChanged += MenuItems_SelectionChanged;

            if (this._footerItems != null)
                this._footerItems.SelectionChanged += FooterItems_SelectionChanged;

            if (this._paneDrawableRectangle != null)
                this._paneDrawableRectangle.MouseDown += OnTitleBarDragging;

            if (this._contentDrawableRectangle != null)
                this._contentDrawableRectangle.MouseDown += OnTitleBarDragging;

            if (this._panelButtons != null)
                this._panelButtons.SizeChanged += PanelButtons_SizeChanged;

            if (this.DisplayMode is NavigationViewDisplayMode.Auto)
                Render();
            else
                UpdateVisualState();
        }

        /// <inheritdoc />
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            if (this.DisplayMode is NavigationViewDisplayMode.Auto)
                if (sizeInfo.WidthChanged)
                    Render();
        }

        /// <inheritdoc/>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.Loaded += (s, e) =>
            {
                if (Window.GetWindow(this) is AeroWindow window && window.ExtendViewIntoTitleBar)
                {
                    _contentDrawableRectangle.Visibility = Visibility.Visible;
                    _paneDrawableRectangle.Visibility = Visibility.Visible;
                }
            };
        }

        private void UpdateVisualState()
        {
            if (this.displayMode is NavigationViewDisplayMode.Auto)
                return;

            VisualStateManager.GoToState(this, this.displayMode.ToString(), false);

            if (this.displayMode is not NavigationViewDisplayMode.Expanded)
                SetValue(IsPaneOpenProperty, false);
            else
                if (!this.isClosedByUser)
                    SetValue(IsPaneOpenProperty, true);
        }

        private void PanelButtons_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.TemplateSettings?.SetValue(NavigationViewTemplateSettings.PaneHeaderMarginProperty,
                this.displayMode is NavigationViewDisplayMode.Minimal
                ? new Thickness(0, e.NewSize.Height, 0, 0)
                : new Thickness(e.NewSize.Width, 0, 0, 0));
        }

        private void MenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this._menuItems.SelectedItem is null)
            {
                if (this._footerItems.SelectedItem is null)
                    this.SelectedItem = null;
                return;
            }

            this._footerItems.SelectedItem = null;
            this.SelectedItem = this._menuItems.SelectedItem;
        }

        private void FooterItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this._footerItems.SelectedItem is null)
            {
                if (this._menuItems.SelectedItem is null)
                    this.SelectedItem = null;

                return;
            }

            this._menuItems.SelectedItem = null;
            this.SelectedItem = this._footerItems.SelectedItem;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.BackRequested?.Invoke(this, e);
        }

        private void PaneToggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.isClosedByUser = this.IsPaneOpen;
            SetValue(IsPaneOpenProperty, !this.IsPaneOpen);
        }

        private void OnTitleBarDragging(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton is MouseButtonState.Pressed)
                Window.GetWindow(this).DragMove();
        }

        private void Render()
        {
            if (this.ActualWidth < this.CompactModeThresholdWidth)
            {
                this.displayMode = NavigationViewDisplayMode.Minimal;
            }
            else if (this.ActualWidth >= this.CompactModeThresholdWidth
                && this.ActualWidth < this.ExpandedModeThresholdWidth)
            {
                this.displayMode = NavigationViewDisplayMode.Compact;
            }
            else
            {
                this.displayMode = NavigationViewDisplayMode.Expanded;
            }

            this.UpdateVisualState();
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the currently selected item changes.
        /// </summary>
        public event TypedEventHandler<object, RoutedEventArgs> SelectionChanged;

        /// <summary>
        /// Occurs when an item in the menu receives an interaction such a a click or tap.
        /// </summary>
        public event TypedEventHandler<object, RoutedEventArgs> ItemInvoked;

        /// <summary>
        /// Occurs when the back button receives an interaction such as a click or tap.
        /// </summary>
        public event TypedEventHandler<object, RoutedEventArgs> BackRequested;

        #endregion
    }
}
