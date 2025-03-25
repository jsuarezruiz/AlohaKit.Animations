namespace AlohaKit.Animations
{
    /// <summary>
    /// The AnimateProgressCornerRadius class interpolates the corner radius property of a visual element,
    /// transitioning from an initial value to a target value as the animation progresses.
    /// </summary>
    public class AnimateProgressCornerRadius : AnimationProgressBaseBehavior
    {
        /// <summary>
        /// Bindable property for specifying the starting corner radius of the animation.
        /// </summary>
        public static readonly BindableProperty FromProperty =
            BindableProperty.Create(
                nameof(From),
                typeof(CornerRadius),
                typeof(AnimationProgressBaseBehavior),
                default(CornerRadius),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the starting corner radius of the animation.
        /// </summary>
        public CornerRadius From
        {
            get { return (CornerRadius)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        /// <summary>
        /// Bindable property for specifying the target corner radius of the animation.
        /// </summary>
        public static readonly BindableProperty ToProperty =
            BindableProperty.Create(
                nameof(To),
                typeof(CornerRadius),
                typeof(AnimationProgressBaseBehavior),
                default(CornerRadius),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the target corner radius of the animation.
        /// </summary>
        public CornerRadius To
        {
            get { return (CornerRadius)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        /// <summary>
        /// Updates the target corner radius property value based on the current progress of the animation.
        /// Calculates intermediate values using linear interpolation for each corner.
        /// </summary>
        protected override void OnUpdate()
        {
            if (Progress < Minimum)
                return;

            if (Progress >= Maximum)
                return;

            // Interpolate the corner radius values based on the progress.
            double? topLeft = ((Progress - Minimum) * (To.TopLeft - From.TopLeft) / (Maximum - Minimum)) + From.TopLeft;
            double? topRight = ((Progress - Minimum) * (To.TopRight - From.TopRight) / (Maximum - Minimum)) + From.TopRight;
            double? bottomLeft = ((Progress - Minimum) * (To.BottomLeft - From.BottomLeft) / (Maximum - Minimum)) + From.BottomLeft;
            double? bottomRight = ((Progress - Minimum) * (To.BottomRight - From.BottomRight) / (Maximum - Minimum)) + From.BottomRight;

            CornerRadius value = new CornerRadius(topLeft.Value, topRight.Value, bottomLeft.Value, bottomRight.Value);

            // Apply the interpolated corner radius to the target property.
            Target.SetValue(TargetProperty, value);
        }
    }
}
