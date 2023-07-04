using MSB.UI.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Input;
using System;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents a container with two views; one view for the main content and another view that is typically used for navigation commands.
    /// </summary>
    public sealed class SplitView : ContentControl
    {
        /// <summary>
        /// Initializes a new instance of the SplitView class.
        /// </summary>
        public SplitView()
        {
            this.DefaultStyleKey = typeof(SplitView);

            SetCurrentValue(TemplateSettingsProperty, new SplitViewTemplateSettings(this));
        }

        #region Properties

        /// <summary>
        /// Gets or sets the contents of the pane of a SplitView.
        /// <para>The default is **null**.</para>
        /// </summary>
        public UIElement Pane
        {
            get => (UIElement)GetValue(PaneProperty);
            set => SetValue(PaneProperty, value);
        }

        /// <summary>
        /// Gets or sets the Brush to apply to the background of the Pane area of the control.
        /// <para>The default is a transparent brush</para>
        /// </summary>
        public Brush PaneBackground
        {
            get => (Brush)GetValue(PaneBackgroundProperty);
            set => SetValue(PaneBackgroundProperty, value);
        }

        /// <summary>
        /// Gets or sets a value that specifies whether the pane is shown on the right or left side of the SplitView.
        /// <para>The default is **Left**.</para>
        /// </summary>
        public SplitViewPanePlacement PanePlacement
        {
            get => (SplitViewPanePlacement)GetValue(PanePlacementProperty);
            set => SetValue(PanePlacementProperty, value);
        }

        /// <summary>
        /// Gets or sets the width of the SplitView pane when it's fully expanded.
        /// <para>The default is 320 pixels.</para>
        /// </summary>
        public double OpenPaneLength
        {
            get => (double)GetValue(OpenPaneLengthProperty);
            set => SetValue(OpenPaneLengthProperty, value);
        }

        /// <summary>
        /// Gets or sets the width of the SplitView pane in its compact display mode.
        /// <para>The default is 48 pixels</para>
        /// </summary>
        public double CompactPaneLength
        {
            get => (double)GetValue(CompactPaneLengthProperty);
            set => SetValue(CompactPaneLengthProperty, value);
        }

        /// <summary>
        /// Gets or sets a value that specifies whether the SplitView pane is expanded to its full width.
        /// <para>The default is **false**.</para>
        /// </summary>
        public bool IsPaneOpen
        {
            get => (bool)GetValue(IsPaneOpenProperty);
            set
            {
                if (value)
                {
                    this.PaneOpening?.Invoke(this, EventArgs.Empty);
                }
                SetValue(IsPaneOpenProperty, value);
            }
        }

        /// <summary>
        /// Gets of sets a value that specifies how the pane and content areas of a SplitView are shown.
        /// <para>The default is **Overlay**.</para>
        /// </summary>
        public SplitViewDisplayMode DisplayMode
        {
            get => (SplitViewDisplayMode)GetValue(DisplayModeProperty);
            set => SetValue(DisplayModeProperty, value);
        }

        /// <summary>
        /// Gets or sets a value that specifies whether the area outside of a *light-dismiss* UI is darkened.
        /// <para>The default is **On**.</para>
        /// </summary>
        public LightDismissOverlayMode LightDismissOverlayMode
        {
            get => (LightDismissOverlayMode)GetValue(LightDismissOverlayModeProperty);
            set => SetValue(LightDismissOverlayModeProperty, value);
        }

        /// <summary>
        /// Gets an object that provides calculated values that can be referenced as **TemplateBinding** sources when defining
        /// templates for a SplitView control.
        /// </summary>
        public SplitViewTemplateSettings TemplateSettings
        {
            get => (SplitViewTemplateSettings)GetValue(TemplateSettingsProperty);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Pane dependency property.
        /// </summary>
        public static readonly DependencyProperty PaneProperty =
                DependencyProperty.Register(nameof(Pane), typeof(UIElement), typeof(SplitView), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the PaneBackground dependency property.
        /// </summary>
        public static readonly DependencyProperty PaneBackgroundProperty =
                DependencyProperty.Register(nameof(PaneBackground), typeof(Brush), typeof(SplitView), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        /// <summary>
        /// Identifies the PanePlacement dependency property.
        /// </summary>
        public static readonly DependencyProperty PanePlacementProperty =
                DependencyProperty.Register(nameof(PanePlacement), typeof(SplitViewPanePlacement), typeof(SplitView), new PropertyMetadata(SplitViewPanePlacement.Left, PanePlacementChanged));

        /// <summary>
        /// Identifies the OpenPaneLength dependency property.
        /// </summary>
        public static readonly DependencyProperty OpenPaneLengthProperty =
                DependencyProperty.Register(nameof(OpenPaneLength), typeof(double), typeof(SplitView), new PropertyMetadata(320d, OpenPaneLengthChanged));

        /// <summary>
        /// Identifies the CompactPaneLength dependency property.
        /// </summary>
        public static readonly DependencyProperty CompactPaneLengthProperty =
                DependencyProperty.Register(nameof(CompactPaneLength), typeof(double), typeof(SplitView), new PropertyMetadata(48d, CompactPaneLengthChanged));

        /// <summary>
        /// Identifies the IsPaneOpen dependency property.
        /// </summary>
        public static readonly DependencyProperty IsPaneOpenProperty =
                DependencyProperty.Register(nameof(IsPaneOpen), typeof(bool), typeof(SplitView), new PropertyMetadata(false, IsPaneOpenChanged));

        /// <summary>
        /// Identifies the DisplayMode dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayModeProperty =
                DependencyProperty.Register(nameof(DisplayMode), typeof(SplitViewDisplayMode), typeof(SplitView), new PropertyMetadata(SplitViewDisplayMode.Overlay, DisplayModeChanged));

        /// <summary>
        /// Identifies the LightDismissOverlayMode dependency property.
        /// </summary>
        public static readonly DependencyProperty LightDismissOverlayModeProperty =
                DependencyProperty.Register(nameof(LightDismissOverlayMode), typeof(LightDismissOverlayMode), typeof(SplitView), new PropertyMetadata(LightDismissOverlayMode.Off, LightDismissOverlayModeChanged));

        /// <summary>
        /// Identifies the TemplateSettings dependency property.
        /// </summary>
        public static readonly DependencyProperty TemplateSettingsProperty =
                DependencyProperty.Register(nameof(TemplateSettings), typeof(SplitViewTemplateSettings), typeof(SplitView), new PropertyMetadata(null));

        #endregion

        #region Callbacks

        private static void PanePlacementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is SplitView splitView)
            {
                splitView.UpdateVisualState(true, false);
            }
        }

        private static void OpenPaneLengthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is SplitView splitView)
            {
                if ((double)e.NewValue < splitView.TemplateSettings?.MinOpenPaneLength)
                {
                    throw new ArgumentOutOfRangeException(e.Property.Name);
                }

                splitView.TemplateSettings?.Update();
                splitView.UpdateVisualState(true, true);
            }
        }

        private static void CompactPaneLengthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is SplitView splitView)
            {
                if ((double)e.NewValue < splitView.TemplateSettings?.MinCompactPaneLength)
                {
                    throw new ArgumentOutOfRangeException(e.Property.Name);
                }

                splitView.TemplateSettings?.Update();
                splitView.UpdateVisualState(true, true);
            }
        }

        private static void IsPaneOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is SplitView splitView)
            {
                if ((bool)e.NewValue)
                {
                    splitView.UpdateVisualState(true, false);

                    splitView.PaneOpened?.Invoke(splitView, EventArgs.Empty);
                }
                else
                {
                    splitView.CheckCanClosePane();
                }
            }
        }

        private static void DisplayModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is SplitView splitView)
            {
                splitView.UpdateVisualState(true, false);
            }
        }

        private static void LightDismissOverlayModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is SplitView splitView)
            {
                splitView.UpdateVisualState(false, false);
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this.lightDismissLayer != null)
                this.lightDismissLayer.MouseDown -= OnLightDismissPressed;

            this.paneClipRectangle = (RectangleGeometry)GetTemplateChild("PaneClipRectangle");
            this.lightDismissLayer = (Rectangle)GetTemplateChild("LightDismissLayer");

            if (this.lightDismissLayer != null)
                this.lightDismissLayer.MouseDown += OnLightDismissPressed;

            this.TemplateSettings?.Update();

            UpdateVisualState(false, false);
        }

        /// <inheritdoc/>
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            if (this.paneClipRectangle != null)
                this.paneClipRectangle.Rect = new Rect(0, 0, this.OpenPaneLength, this.ActualHeight);
        }

        private void UpdateVisualState(bool animate, bool reset)
        {
            var state = "";

            if (this.IsPaneOpen)
            {
                state += "Open";

                state += this.DisplayMode switch
                {
                    SplitViewDisplayMode.CompactInline => "Inline",
                    _ => this.DisplayMode.ToString(),
                };
                state += this.PanePlacement.ToString();
            }
            else
            {
                state += "Closed";

                if (this.DisplayMode is SplitViewDisplayMode.CompactInline
                        || this.DisplayMode is SplitViewDisplayMode.CompactOverlay)
                {
                    state += "Compact";
                    state += this.PanePlacement.ToString();
                }
            }

            if (reset)
                VisualStateManager.GoToState(this, "None", animate);

            VisualStateManager.GoToState(this, state, animate);

            VisualStateManager.GoToState(this, this.LightDismissOverlayMode is LightDismissOverlayMode.On ? "OverlayVisible" : "OverlayNotVisible", false);
        }

        private void OnLightDismissPressed(object sender, MouseButtonEventArgs e)
        {
            SetCurrentValue(IsPaneOpenProperty, false);
        }

        private void CheckCanClosePane()
        {
            var cancel = false;

            if (this.PaneClosing != null)
            {
                var args = new SplitViewPaneClosingEventArgs();

                foreach (var closingDelegate in this.PaneClosing.GetInvocationList())
                {
                    if (closingDelegate is not TypedEventHandler<object, SplitViewPaneClosingEventArgs> handler)
                        continue;

                    handler(this, args);

                    if (args.Cancel)
                    {
                        cancel = true;
                        break;
                    }
                }
            }

            if (!cancel)
            {
                UpdateVisualState(true, false);

                this.PaneClosed?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                SetCurrentValue(IsPaneOpenProperty, true);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the SplitView pane is closed.
        /// </summary>
        public event TypedEventHandler<object, object> PaneClosed;

        /// <summary>
        /// Occurs when the SplitView pane is closing.
        /// </summary>
        public event TypedEventHandler<object, SplitViewPaneClosingEventArgs> PaneClosing;

        /// <summary>
        /// Occurs when the SplitView pane is opened.
        /// </summary>
        public event TypedEventHandler<object, object> PaneOpened;

        /// <summary>
        /// Occurs when the SplitView pane is opening.
        /// </summary>
        public event TypedEventHandler<object, object> PaneOpening;

        #endregion

        Rectangle lightDismissLayer = null;
        RectangleGeometry paneClipRectangle = null;
    }
}
