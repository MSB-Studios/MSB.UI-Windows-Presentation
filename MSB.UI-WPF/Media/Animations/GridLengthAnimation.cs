using System.Windows.Media.Animation;
using System.Windows;
using System;

namespace MSB.Media.Animations
{
    /// <summary>
    /// A special animation used to animates the length of a Grid.
    /// </summary>
    public sealed class GridLengthAnimation : AnimationTimeline
    {
        #region Properties

        /// <inheritdoc />
        public override Type TargetPropertyType
        {
            get => typeof(GridLength);
        }

        /// <summary>
        /// Gets or sets the animation's starting value.
        /// <para>The default is **null**.</para>
        /// </summary>
        public GridLength From
        {
            get => (GridLength)GetValue(FromProperty);
            set => SetValue(FromProperty, value);
        }

        /// <summary>
        /// Gets or sets the animation's ending value.
        /// <para>The default is **null**.</para>
        /// </summary>
        public GridLength To
        {
            get => (GridLength)GetValue(ToProperty);
            set => SetValue(ToProperty, value);
        }

        #endregion

        #region Dependency property

        /// <summary>
        /// Identifies the From dependency property.
        /// </summary>
        public static readonly DependencyProperty FromProperty =
                    DependencyProperty.Register(nameof(From), typeof(GridLength), typeof(GridLengthAnimation));

        /// <summary>
        /// Identifies the To dependency property.
        /// </summary>
        public static readonly DependencyProperty ToProperty =
                    DependencyProperty.Register(nameof(To), typeof(GridLength), typeof(GridLengthAnimation));

        #endregion

        #region Methods

        /// <inheritdoc />
        protected override Freezable CreateInstanceCore()
        {
            return new GridLengthAnimation();
        }

        /// <inheritdoc />
        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
            var from = ((GridLength)GetValue(FromProperty));
            var to = ((GridLength)GetValue(ToProperty));

            if (from.GridUnitType != to.GridUnitType)
                return to;

            var fromVal = from.Value;
            var toVal = to.Value;

            if (fromVal > toVal)
                return new GridLength((1 - animationClock.CurrentProgress.GetValueOrDefault()) * (fromVal - toVal) + toVal, this.To.IsStar ? GridUnitType.Star : GridUnitType.Pixel);

            return new GridLength((animationClock.CurrentProgress.GetValueOrDefault()) * (toVal - fromVal) + fromVal, this.To.IsStar ? GridUnitType.Star : GridUnitType.Pixel);
        }

        #endregion
    }
}
