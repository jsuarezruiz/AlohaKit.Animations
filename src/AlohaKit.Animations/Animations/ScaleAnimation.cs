namespace AlohaKit.Animations
{
    using Helpers;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents an animation that scales the target element to a specified size.
    /// </summary>
    public class ScaleToAnimation : AnimationBase
    {
        /// <summary>
        /// Bindable property for specifying the target scale value.
        /// </summary>
        public static readonly BindableProperty ScaleProperty =
            BindableProperty.Create(nameof(Scale), typeof(double), typeof(ScaleToAnimation), default(double),
                BindingMode.TwoWay, null);

        /// <summary>
        /// Gets or sets the target scale value for the animation.
        /// </summary>
        public double Scale
        {
            get { return (double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.ScaleTo(Scale, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }

    /// <summary>
    /// Represents an animation that scales the target element relative to its current size.
    /// </summary>
    public class RelScaleToAnimation : AnimationBase
    {
        /// <summary>
        /// Bindable property for specifying the relative scale value.
        /// </summary>
        public static readonly BindableProperty ScaleProperty =
            BindableProperty.Create(nameof(Scale), typeof(double), typeof(RelScaleToAnimation), default(double),
                BindingMode.TwoWay, null);

        /// <summary>
        /// Gets or sets the relative scale value for the animation.
        /// </summary>
        public double Scale
        {
            get { return (double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.RelScaleTo(Scale, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }
}