using MSB.UI.Controls.Primitives;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System;

namespace MSB.UI.Controls
{
    /// <summary>
    /// A control that provides contextual information in a compact way.
    /// </summary>
    public sealed class TeachingTip : Control
    {
        private Button btnHide = null;
        private Button btnClose = null;
        private Button btnAction = null;
        internal Popup popup = null;

        /// <summary>
        /// Initializes a new instance of the 'TeachingTip' class.
        /// </summary>
        public TeachingTip()
        {
            this.DefaultStyleKey = typeof(TeachingTip);

            SetValue(TemplateSettingsProperty, new TeachingTipTemplateSettings(this));
        }

        #region Properties

        /// <summary>
        /// Gets or sets the content of the action button.
        /// <para>The default is **null**.</para>
        /// </summary>
        public object ActionButtonContent
        {
            get => GetValue(ActionButtonContentProperty);
            set => SetValue(ActionButtonContentProperty, value);
        }

        /// <summary>
        /// Gets or sets the content of the close button.
        /// <para>The default is **null**.</para>
        /// </summary>
        public object CloseButtonContent
        {
            get => GetValue(CloseButtonContentProperty);
            set => SetValue(CloseButtonContentProperty, value);
        }

        /// <summary>
        /// Gets or sets the content of the hero.
        /// <para>The default is **null**.</para>
        /// </summary>
        public UIElement HeroContent
        {
            get => (UIElement)GetValue(HeroContentProperty);
            set => SetValue(HeroContentProperty, value);
        }

        /// <summary>
        /// Gets or sets the placement of the hero content.
        /// <para>The default is **Top**.</para>
        /// </summary>
        public HeroContentPlacement HeroContentPlacement
        {
            get => (HeroContentPlacement)GetValue(HeroContentPlacementProperty);
            set => SetValue(HeroContentPlacementProperty, value);
        }

        /// <summary>
        /// Gets or sets the source of the icon.
        /// <para>The default is **null**.</para>
        /// </summary>
        public IconElement Icon
        {
            get => (IconElement)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the light dismiss is enabled.
        /// <para>The default is **true**.</para>
        /// </summary>
        public bool IsLightDismissEnabled
        {
            get => (bool)GetValue(IsLightDismissEnabledProperty);
            set => SetValue(IsLightDismissEnabledProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control is open.
        /// <para>The default is **false**.</para>
        /// </summary>
        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        /// <summary>
        /// Gets or sets the margin of the placement.
        /// <para>The default is 0 on all sides.</para>
        /// </summary>
        public Thickness PlacementMargin
        {
            get => (Thickness)GetValue(PlacementMarginProperty);
            set => SetValue(PlacementMarginProperty, value);
        }

        /// <summary>
        /// Gets or sets the preferred placement of the control.
        /// <para>The default is **Auto**.</para>
        /// </summary>
        public TeachingTipPlacementMode PreferredPlacement
        {
            get => (TeachingTipPlacementMode)GetValue(PreferredPlacementProperty);
            set => SetValue(PreferredPlacementProperty, value);
        }

        /// <summary>
        /// Gets or sets the horizontal offset of the control.
        /// </summary>
        public double HorizontalOffset
        {
            get => (double)GetValue(HorizontalOffsetProperty);
            set => SetValue(HorizontalOffsetProperty, value);
        }

        /// <summary>
        /// Gets or sets the vertical offset of the control.
        /// </summary>
        public double VerticalOffset
        {
            get => (double)GetValue(VerticalOffsetProperty);
            set => SetValue(VerticalOffsetProperty, value);
        }

        /// <summary>
        /// Gets or sets the title of the control.
        /// <para>The default is an empty string.</para>
        /// </summary>
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// Gets or sets the subtitle of the control.
        /// <para>The default is an empty string.</para>
        /// </summary>
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        /*
        /// <summary>
        /// Gets or sets the target of the control.
        /// <para>The default is **null**.</para>
        /// </summary>
        public UIElement Target
        {
            get => (UIElement)GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }
        */

        /// <summary>
        /// Gets or sets a value indicating whether the tail is visible.
        /// <para>The default is **false**.</para>
        /// </summary>
        public TailVisibility TailVisibility
        {
            get => (TailVisibility)GetValue(TailVisibilityProperty);
            set => SetValue(TailVisibilityProperty, value);
        }

        /// <summary>
        /// Gets an object that provides calculated values that can be referenced as **TemplateBinding** sources when defining
        /// templates for a TeachingTip control.
        /// </summary>
        public TeachingTipTemplateSettings TemplateSettings
        {
            get => (TeachingTipTemplateSettings)GetValue(TemplateSettingsProperty);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the ActionButtonContent dependency property.
        /// </summary>
        public static readonly DependencyProperty ActionButtonContentProperty =
                DependencyProperty.Register(nameof(ActionButtonContent), typeof(object), typeof(TeachingTip), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the CloseButtonContent dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonContentProperty =
                DependencyProperty.Register(nameof(CloseButtonContent), typeof(object), typeof(TeachingTip), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the HeroContent dependency property.
        /// </summary>
        public static readonly DependencyProperty HeroContentProperty =
                DependencyProperty.Register(nameof(HeroContent), typeof(UIElement), typeof(TeachingTip), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the HeroContentPlacement dependency property.
        /// </summary>
        public static readonly DependencyProperty HeroContentPlacementProperty =
                DependencyProperty.Register(nameof(HeroContentPlacement), typeof(HeroContentPlacement), typeof(TeachingTip), new PropertyMetadata(HeroContentPlacement.Top));

        /// <summary>
        /// Identifies the Icon dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
                DependencyProperty.Register(nameof(Icon), typeof(IconElement), typeof(TeachingTip), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the IsLightDismissEnabled dependency property.
        /// </summary>
        public static readonly DependencyProperty IsLightDismissEnabledProperty =
                DependencyProperty.Register(nameof(IsLightDismissEnabled), typeof(bool), typeof(TeachingTip), new PropertyMetadata(true, IsLigthDismissEnabledChanged));

        /// <summary>
        /// Identifies the IsOpen dependency property.
        /// </summary>
        public static readonly DependencyProperty IsOpenProperty =
                DependencyProperty.Register(nameof(IsOpen), typeof(bool), typeof(TeachingTip), new PropertyMetadata(false, IsOpenChanged));

        /// <summary>
        /// Identifies the PlacementMargin dependency property.
        /// </summary>
        public static readonly DependencyProperty PlacementMarginProperty =
                DependencyProperty.Register(nameof(PlacementMargin), typeof(Thickness), typeof(TeachingTip), new PropertyMetadata(new Thickness(0)));

        /// <summary>
        /// Identifies the PreferredPlacement dependency property.
        /// </summary>
        public static readonly DependencyProperty PreferredPlacementProperty =
                DependencyProperty.Register(nameof(PreferredPlacement), typeof(TeachingTipPlacementMode), typeof(TeachingTip), new PropertyMetadata(TeachingTipPlacementMode.Bottom));

        /// <summary>
        /// Identifies the HorizontalOffset dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalOffsetProperty =
                DependencyProperty.Register(nameof(HorizontalOffset), typeof(double), typeof(TeachingTip), new PropertyMetadata(0d));

        /// <summary>
        /// Identifies the VerticalOffset dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalOffsetProperty =
                DependencyProperty.Register(nameof(VerticalOffset), typeof(double), typeof(TeachingTip), new PropertyMetadata(0d));

        /// <summary>
        /// Identifies the Title dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
                DependencyProperty.Register(nameof(Title), typeof(string), typeof(TeachingTip), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Identifies the Description dependency property.
        /// </summary>
        public static readonly DependencyProperty DescriptionProperty =
                DependencyProperty.Register(nameof(Description), typeof(string), typeof(TeachingTip), new PropertyMetadata(string.Empty));

        /*
        /// <summary>
        /// Identifies the Target dependency property.
        /// </summary>
        public static readonly DependencyProperty TargetProperty =
                DependencyProperty.Register(nameof(Target), typeof(UIElement), typeof(TeachingTip), new PropertyMetadata(null));
        */

        /// <summary>
        /// Identifies the TailVisibility dependency property.
        /// </summary>
        public static readonly DependencyProperty TailVisibilityProperty =
                DependencyProperty.Register(nameof(TailVisibility), typeof(TailVisibility), typeof(TeachingTip), new PropertyMetadata(TailVisibility.Auto));

        /// <summary>
        /// Identifies the TemplateSettings dependency property.
        /// </summary>
        public static readonly DependencyProperty TemplateSettingsProperty =
                DependencyProperty.Register(nameof(TemplateSettings), typeof(TeachingTipTemplateSettings), typeof(TeachingTip), new PropertyMetadata(null));

        #endregion

        #region Callbacks

        private static void IsLigthDismissEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is TeachingTip tip)
            {
                if (tip.popup is null)
                    return;

                tip.popup.StaysOpen = !(bool)e.NewValue;
            }
        }

        private static void IsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is TeachingTip tip)
            {
                if ((bool)e.NewValue)
                    tip.Opened?.Invoke(tip, EventArgs.Empty);
                else
                    tip.Closed?.Invoke(tip, EventArgs.Empty);

                tip.UpdateVisualState();
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (popup is not null)
            {
                popup.Opened -= OnPopupOpened;
                popup.Closed -= OnPopupClosed;
            }

            if (btnHide is not null)
                btnHide.Click -= OnHideButtonClick;
            if (btnClose is not null)
                btnClose.Click -= OnCloseButtonClick;
            if (btnAction is not null)
                btnAction.Click -= OnActionButtonClick;

            popup = (Popup)GetTemplateChild("PART_Popup");
            btnHide = (Button)GetTemplateChild("HideButton");
            btnClose = (Button)GetTemplateChild("CloseButton");
            btnAction = (Button)GetTemplateChild("ActionButton");

            if (popup is not null)
            {
                popup.Opened += OnPopupOpened;
                popup.Closed += OnPopupClosed;
            }

            if (btnHide is not null)
                btnHide.Click += OnHideButtonClick;
            if (btnClose is not null)
                btnClose.Click += OnCloseButtonClick;
            if (btnAction is not null)
                btnAction.Click += OnActionButtonClick;

            UpdateVisualState();
            this.TemplateSettings?.Update();
        }

        private void UpdateVisualState()
        {
            VisualStateManager.GoToState(this, IsOpen ? "Open" : "Closed", true);
        }

        private void OnWindowActivated(object sender, EventArgs e)
        {
            if (this.IsOpen)
                VisualStateManager.GoToState(this, "Open", false);
        }

        private void OnWindowDeactivated(object sender, EventArgs e)
        {
            VisualStateManager.GoToState(this, "Closed", false);
        }

        private void OnWindowLocationChanged(object sender, EventArgs e)
        {
            if (!this.IsLightDismissEnabled)
                this.TemplateSettings?.Update();
        }

        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!this.IsLightDismissEnabled)
                this.TemplateSettings?.Update();
        }

        private void OnPopupOpened(object sender, EventArgs e)
        {
            var window = Window.GetWindow(this);

            if (window is null)
                return;

            window.Activated += OnWindowActivated;
            window.Deactivated += OnWindowDeactivated;
            window.LocationChanged += OnWindowLocationChanged;
            window.SizeChanged += OnWindowSizeChanged;

            this.TemplateSettings?.Update();
        }

        private void OnPopupClosed(object sender, EventArgs e)
        {
            var window = Window.GetWindow(this);

            if (window is null)
                return;

            window.Activated -= OnWindowActivated;
            window.Deactivated -= OnWindowDeactivated;
            window.LocationChanged -= OnWindowLocationChanged;
            window.SizeChanged -= OnWindowSizeChanged;
        }

        private void OnHideButtonClick(object sender, RoutedEventArgs e)
        {
            this.IsOpen = false;
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.CloseButtonClick?.Invoke(this, e);
        }

        private void OnActionButtonClick(object sender, RoutedEventArgs e)
        {
            this.ActionButtonClick?.Invoke(this, e);
        }

        internal object GetChild(string name)
        {
            return GetTemplateChild(name);
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the action button is clicked.
        /// </summary>
        public event TypedEventHandler<object, RoutedEventArgs> ActionButtonClick;

        /// <summary>
        /// Occurs when the close button is clicked.
        /// </summary>
        public event TypedEventHandler<object, RoutedEventArgs> CloseButtonClick;

        /// <summary>
        /// Occurs when the control is closed.
        /// </summary>
        public event TypedEventHandler<object, EventArgs> Closed;

        /// <summary>
        /// Occurs when the control is opened.
        /// </summary>
        public event TypedEventHandler<object, EventArgs> Opened;

        #endregion
    }
}
