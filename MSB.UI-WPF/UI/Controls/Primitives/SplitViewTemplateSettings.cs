using System.Windows;

namespace MSB.UI.Controls.Primitives
{
    /// <summary>
    /// Provides calculated values that can be referenced as TemplateParent sources when difining templates for a SplitView.
    /// </summary>
    public sealed class SplitViewTemplateSettings : DependencyObject
    {
        internal SplitViewTemplateSettings(SplitView sv)
        {
            this._owner = sv;
        }

        #region Properties

        /// <summary>
        /// Gets the min value for the OpenPaneLength property.
        /// </summary>
        public double MinOpenPaneLength
        {
            get => (double)GetValue(MinOpenPaneLengthProperty);
        }

        /// <summary>
        /// Gets the min value for the CompactPaneLength property.
        /// </summary>
        public double MinCompactPaneLength
        {
            get => (double)GetValue(MinCompactPaneLengthProperty);
        }

        /// <summary>
        /// Gets the OpenPaneLength value as a GridLength.
        /// </summary>
        public GridLength OpenPaneGridLength
        {
            get => (GridLength)GetValue(OpenPaneGridLengthProperty);
        }

        /// <summary>
        /// Gets the CompactPaneLength value as a GridLength.
        /// </summary>
        public GridLength CompactPaneGridLength
        {
            get => (GridLength)GetValue(CompactPaneGridLengthProperty);
        }

        /// <summary>
        /// Gets a value calculated by subtracting the CompactPaneLength value from the OpenPaneLength value.
        /// </summary>
        public double OpenPaneLengthMinusCompactLength
        {
            get => (double)GetValue(OpenPaneLengthMinusCompactLengthProperty);
        }

        /// <summary>
        /// Gets the negative of the OpenPaneLength value.
        /// </summary>
        public double NegativeOpenPaneLength
        {
            get => (double)GetValue(NegativeOpenPaneLengthProperty);
        }

        /// <summary>
        /// Gets the negative of the value calculated by subtracting the CompactPaneLength value from
        /// the OpenPaneLength value.
        /// </summary>
        public double NegativeOpenPaneLengthMinusCompactLength
        {
            get => (double)GetValue(NegativeOpenPaneLengthMinusCompactLengthProperty);
        }

        #endregion

        #region Dependency properties

        internal static readonly DependencyProperty MinOpenPaneLengthProperty =
                DependencyProperty.Register(nameof(MinOpenPaneLength), typeof(double), typeof(SplitViewTemplateSettings), new PropertyMetadata(48d));

        internal static readonly DependencyProperty MinCompactPaneLengthProperty =
                DependencyProperty.Register(nameof(MinCompactPaneLength), typeof(double), typeof(SplitViewTemplateSettings), new PropertyMetadata(0d));

        internal static readonly DependencyProperty OpenPaneGridLengthProperty =
                DependencyProperty.Register(nameof(OpenPaneGridLength), typeof(GridLength), typeof(SplitViewTemplateSettings), new PropertyMetadata(null));

        internal static readonly DependencyProperty CompactPaneGridLengthProperty =
                DependencyProperty.Register(nameof(CompactPaneGridLength), typeof(GridLength), typeof(SplitViewTemplateSettings), new PropertyMetadata(null));

        internal static readonly DependencyProperty OpenPaneLengthMinusCompactLengthProperty =
                DependencyProperty.Register(nameof(OpenPaneLengthMinusCompactLength), typeof(double), typeof(SplitViewTemplateSettings), new PropertyMetadata(0d));

        internal static readonly DependencyProperty NegativeOpenPaneLengthProperty =
                DependencyProperty.Register(nameof(NegativeOpenPaneLength), typeof(double), typeof(SplitViewTemplateSettings), new PropertyMetadata(0d));

        internal static readonly DependencyProperty NegativeOpenPaneLengthMinusCompactLengthProperty =
                DependencyProperty.Register(nameof(NegativeOpenPaneLengthMinusCompactLength), typeof(double), typeof(SplitViewTemplateSettings), new PropertyMetadata(0d));

        #endregion

        #region Methods

        internal void Update()
        {
            SetValue(OpenPaneGridLengthProperty, new GridLength(this._owner.OpenPaneLength, GridUnitType.Pixel));
            SetValue(CompactPaneGridLengthProperty, new GridLength(this._owner.CompactPaneLength, GridUnitType.Pixel));

            SetValue(OpenPaneLengthMinusCompactLengthProperty, this._owner.OpenPaneLength - this._owner.CompactPaneLength);

            SetValue(NegativeOpenPaneLengthProperty, -this._owner.OpenPaneLength);
            SetValue(NegativeOpenPaneLengthMinusCompactLengthProperty, -this.OpenPaneLengthMinusCompactLength);
        }

        #endregion

        readonly SplitView _owner;
    }
}
