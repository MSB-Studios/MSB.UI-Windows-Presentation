using MSB.Extensions;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System;

namespace MSB.UI.Controls.Primitives
{
    /// <summary>
    /// Provides calculated values that can be referenced as TemplateParent sources when defining templates for a TeachingTip.
    /// </summary>
    public sealed class TeachingTipTemplateSettings : DependencyObject
    {
        readonly TeachingTip _owner = null;
        private Window _window = null;
        private Border _mask = null;
        private Grid _container = null;
        
        internal TeachingTipTemplateSettings(TeachingTip tip)
        {
            this._owner = tip;
        }

        #region Properties

        /// <summary>
        /// Gets the placement target value.
        /// </summary>
        public UIElement PlacementTarget
        {
            get => (UIElement)GetValue(PlacementTargetProperty);
        }

        /// <summary>
        /// Gets the placement value.
        /// </summary>
        public PlacementMode Placement
        {
            get => (PlacementMode)GetValue(PlacementProperty);
        }

        /// <summary>
        /// Gets the corner radius of the hero content.
        /// </summary>
        public CornerRadius HeroContentCornerRadius
        {
            get => (CornerRadius)GetValue(HeroContentCornerRadiusProperty);
        }

        #endregion

        #region Dependency properties

        internal static readonly DependencyProperty PlacementTargetProperty =
                DependencyProperty.Register(nameof(PlacementTarget), typeof(UIElement), typeof(TeachingTipTemplateSettings), new PropertyMetadata(null));

        internal static readonly DependencyProperty PlacementProperty =
                DependencyProperty.Register(nameof(Placement), typeof(PlacementMode), typeof(TeachingTipTemplateSettings), new PropertyMetadata(PlacementMode.Custom));

        internal static readonly DependencyProperty HeroContentCornerRadiusProperty =
                DependencyProperty.Register(nameof(HeroContentCornerRadius), typeof(CornerRadius), typeof(TeachingTipTemplateSettings), new PropertyMetadata(new CornerRadius(0)));

        #endregion

        #region Methods

        internal void Update()
        {
            this._window ??= Window.GetWindow(this._owner);
            this._mask ??= (Border)this._owner.GetChild("BorderMask");
            this._container ??= (Grid)this._owner.GetChild("GridRoot");

            if (this._owner.popup is null)
                return;

            var radius = this._mask?.CornerRadius;

            SetValue(PlacementTargetProperty, this._window);

            if (radius is null)
            {
                SetValue(HeroContentCornerRadiusProperty, radius is null ? 0 : new CornerRadius(0));
            }
            else
            {
                if (this._owner.HeroContentPlacement is HeroContentPlacement.Top)
                    SetValue(HeroContentCornerRadiusProperty, new CornerRadius((double)radius?.TopLeft, (double)radius?.TopRight, 0, 0));
                else
                    SetValue(HeroContentCornerRadiusProperty, new CornerRadius(0, 0, (double)radius?.BottomRight, (double)radius?.BottomLeft));
            }

            var offset = this._owner.popup.HorizontalOffset;
            this._owner.popup.HorizontalOffset = offset + 1;
            this._owner.popup.HorizontalOffset = offset;

            this._owner.popup.CustomPopupPlacementCallback ??= PlacePopup;
        }

        private CustomPopupPlacement[] PlacePopup(Size popupSize, Size targetSize, Point offset)
        {
            var containerSize = this._container?.GetPhysicalSize();

            var targetWidthMinusBorderWidth = targetSize.Width - containerSize?.Width;
            var targetHeightMinusBorderHeight = targetSize.Height - containerSize?.Height;

            var point = new Point(0, 0);

            switch (this._owner.PreferredPlacement)
            {
                case TeachingTipPlacementMode.Top:
                    point.X = (double)(targetWidthMinusBorderWidth / 2);
                    point.Y = (double)(0 - this._container?.Margin.Top);
                    break;
                case TeachingTipPlacementMode.Left:
                    point.X = (double)(0 - this._container.Margin.Left);
                    point.Y = (double)(targetHeightMinusBorderHeight / 2);
                    break;
                case TeachingTipPlacementMode.Right:
                    point.X = (double)(targetWidthMinusBorderWidth - this._container?.Margin.Right);
                    point.Y = (double)(targetHeightMinusBorderHeight / 2);
                    break;
                default:
                    point.X = (double)(targetWidthMinusBorderWidth / 2);
                    point.Y = (double)(targetHeightMinusBorderHeight - this._container?.Margin.Bottom);

                    if (this._window?.WindowState is WindowState.Maximized)
                        point.Y -= 8 + 5;

                    break;
            }

            point.X += this._owner.HorizontalOffset;
            point.Y += this._owner.VerticalOffset;

            return [new(point, PopupPrimaryAxis.None)];
        }
    }

    #endregion
}