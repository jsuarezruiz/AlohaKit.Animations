namespace AlohaKit.Animations
{
    using Helpers;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents an animation that translates (moves) the target element to a specified position.
    /// </summary>
    public class TranslateToAnimation : AnimationBase
    {
        /// <summary>
        /// Bindable property for specifying the target X-coordinate of the animation.
        /// </summary>
        public static readonly BindableProperty TranslateXProperty =
            BindableProperty.Create(nameof(TranslateX), typeof(double), typeof(TranslateToAnimation), default(double),
                BindingMode.TwoWay, null);

        /// <summary>
        /// Gets or sets the target X-coordinate to move the element to.
        /// </summary>
        public double TranslateX
        {
            get { return (double)GetValue(TranslateXProperty); }
            set { SetValue(TranslateXProperty, value); }
        }

        /// <summary>
        /// Bindable property for specifying the target Y-coordinate of the animation.
        /// </summary>
        public static readonly BindableProperty TranslateYProperty =
            BindableProperty.Create(nameof(TranslateY), typeof(double), typeof(TranslateToAnimation), default(double),
                BindingMode.TwoWay, null);

        /// <summary>
        /// Gets or sets the target Y-coordinate to move the element to.
        /// </summary>
        public double TranslateY
        {
            get { return (double)GetValue(TranslateYProperty); }
            set { SetValue(TranslateYProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.TranslateTo(TranslateX, TranslateY, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }
}
