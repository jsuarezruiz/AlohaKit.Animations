namespace AlohaKit.Animations
{
    /// <summary>
    /// The AnimateProgressThickness class interpolates the thickness property of a visual element,
    /// transitioning from an initial value to a target value as the animation progresses.
    /// </summary>
    public class AnimateProgressThickness : AnimationProgressBaseBehavior
    {
        /// <summary>
        /// Bindable property for specifying the starting thickness value of the animation.
        /// </summary>
        public static readonly BindableProperty FromProperty =
            BindableProperty.Create(
                nameof(From),
                typeof(Thickness),
                typeof(AnimationProgressBaseBehavior),
                default(Thickness),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the starting thickness value of the animation.
        /// </summary>
        public Thickness From
        {
            get { return (Thickness)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        /// <summary>
        /// Bindable property for specifying the target thickness value of the animation.
        /// </summary>
        public static readonly BindableProperty ToProperty =
            BindableProperty.Create(
                nameof(To),
                typeof(Thickness),
                typeof(AnimationProgressBaseBehavior),
                default(Thickness),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the target thickness value of the animation.
        /// </summary>
        public Thickness To
        {
            get { return (Thickness)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        /// <summary>
        /// Updates the target thickness property value based on the current progress of the animation.
        /// Calculates intermediate values using linear interpolation for each thickness dimension.
        /// </summary>
        protected override void OnUpdate()
        {
            if (Progress < Minimum)
                return;

            if (Progress >= Maximum)
                return;

            // Interpolates each dimension of the thickness property based on animation progress.
            double? left = ((Progress - Minimum) * (To.Left - From.Left) / (Maximum - Minimum)) + From.Left;
            double? top = ((Progress - Minimum) * (To.Top - From.Top) / (Maximum - Minimum)) + From.Top;
            double? right = ((Progress - Minimum) * (To.Right - From.Right) / (Maximum - Minimum)) + From.Right;
            double? bottom = ((Progress - Minimum) * (To.Bottom - From.Bottom) / (Maximum - Minimum)) + From.Bottom;

            Thickness value = new Thickness(left.Value, top.Value, right.Value, bottom.Value);

            // Applies the interpolated thickness value to the target property.
            Target.SetValue(TargetProperty, value);
        }
    }
}
