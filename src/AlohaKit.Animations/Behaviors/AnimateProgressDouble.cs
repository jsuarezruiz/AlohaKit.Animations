namespace AlohaKit.Animations
{
    /// <summary>
    /// The AnimateProgressDouble class interpolates a double property of a visual element, transitioning 
    /// from an initial value to a target value as the animation progresses. It allows scaling of the value 
    /// using a multiplier.
    /// </summary>
    public class AnimateProgressDouble : AnimationProgressBaseBehavior
    {
        /// <summary>
        /// Bindable property for specifying the starting value of the animation.
        /// </summary>
        public static readonly BindableProperty FromProperty =
            BindableProperty.Create(
                nameof(From),
                typeof(double),
                typeof(AnimationProgressBaseBehavior),
                default(double),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the starting value of the animation.
        /// </summary>
        public double From
        {
            get { return (double)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        /// <summary>
        /// Bindable property for specifying the target value of the animation.
        /// </summary>
        public static readonly BindableProperty ToProperty =
            BindableProperty.Create(
                nameof(To),
                typeof(double),
                typeof(AnimationProgressBaseBehavior),
                default(double),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the target value of the animation.
        /// </summary>
        public double To
        {
            get { return (double)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        /// <summary>
        /// Bindable property for specifying a multiplier to scale the interpolated value.
        /// </summary>
        public static readonly BindableProperty MultiplyValueProperty =
            BindableProperty.Create(
                nameof(MultiplyValue),
                typeof(double),
                typeof(AnimateProgressDouble),
                1.0d,
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets a multiplier value used to scale the interpolated result.
        /// </summary>
        public double MultiplyValue
        {
            get { return (double)GetValue(MultiplyValueProperty); }
            set { SetValue(MultiplyValueProperty, value); }
        }

        /// <summary>
        /// Updates the target double property based on the current progress of the animation.
        /// Performs interpolation and applies the multiplier to calculate the value.
        /// </summary>
        protected override void OnUpdate()
        {
            if (Progress < Minimum)
            {
                Target.SetValue(TargetProperty, From * MultiplyValue);
                return;
            }

            if (Progress >= Maximum)
            {
                Target.SetValue(TargetProperty, To * MultiplyValue);
                return;
            }

            // Interpolates the value based on the animation progress.
            double? value = ((Progress - Minimum) * (To - From) / (Maximum - Minimum)) + From;

            // Scales the interpolated value using the multiplier and sets it to the target property.
            Target.SetValue(TargetProperty, value.GetValueOrDefault() * MultiplyValue);
        }
    }
}
