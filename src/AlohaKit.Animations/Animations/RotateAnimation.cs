namespace AlohaKit.Animations
{
    using Helpers;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The RotateToAnimation class animates the rotation of a target element to a specified angle.
    /// </summary>
    public class RotateToAnimation : AnimationBase
    {
        /// <summary>
        /// Bindable property for specifying the target rotation angle.
        /// </summary>
        public static readonly BindableProperty RotationProperty =
            BindableProperty.Create(
                nameof(Rotation),
                typeof(double),
                typeof(RotateToAnimation),
                default(double),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the target rotation angle for the animation.
        /// </summary>
        public double Rotation
        {
            get { return (double)GetValue(RotationProperty); }
            set { SetValue(RotationProperty, value); }
        }

        /// <summary>
        /// Begins the rotation animation, rotating the target element to the specified angle.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <exception cref="NullReferenceException">Thrown when the Target property is null.</exception>
        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.RotateTo(Rotation, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }

    /// <summary>
    /// Represents an animation that rotates the target element by a relative angle.
    /// </summary>
    public class RelRotateToAnimation : AnimationBase
    {
        /// <summary>
        /// Bindable property for specifying the relative rotation angle.
        /// </summary>
        public static readonly BindableProperty RotationProperty =
            BindableProperty.Create(
                nameof(Rotation),
                typeof(double),
                typeof(RelRotateToAnimation),
                default(double),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the relative rotation angle for the animation.
        /// </summary>
        public double Rotation
        {
            get { return (double)GetValue(RotationProperty); }
            set { SetValue(RotationProperty, value); }
        }

        /// <summary>
        /// Begins the relative rotation animation, rotating the target element by the specified angle.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <exception cref="NullReferenceException">Thrown when the Target property is null.</exception>
        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.RelRotateTo(Rotation, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }

    /// <summary>
    /// Represents an animation that rotates the target element around the X-axis to a specified angle.
    /// </summary>
    public class RotateXToAnimation : AnimationBase
    {
        /// <summary>
        /// Bindable property for specifying the target rotation angle around the X-axis.
        /// </summary>
        public static readonly BindableProperty RotationProperty =
            BindableProperty.Create(
                nameof(Rotation),
                typeof(double),
                typeof(RotateXToAnimation),
                default(double),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the target rotation angle around the X-axis.
        /// </summary>
        public double Rotation
        {
            get { return (double)GetValue(RotationProperty); }
            set { SetValue(RotationProperty, value); }
        }

        /// <summary>
        /// Begins the rotation animation around the X-axis.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <exception cref="NullReferenceException">Thrown when the Target property is null.</exception>
        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.RotateXTo(Rotation, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }

    /// <summary>
    /// Represents an animation that rotates the target element around the Y-axis to a specified angle.
    /// </summary>
    public class RotateYToAnimation : AnimationBase
    {
        /// <summary>
        /// Bindable property for specifying the target rotation angle around the Y-axis.
        /// </summary>
        public static readonly BindableProperty RotationProperty =
            BindableProperty.Create(
                nameof(Rotation),
                typeof(double),
                typeof(RotateYToAnimation),
                default(double),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the target rotation angle around the Y-axis.
        /// </summary>
        public double Rotation
        {
            get { return (double)GetValue(RotationProperty); }
            set { SetValue(RotationProperty, value); }
        }

        /// <summary>
        /// Begins the rotation animation around the Y-axis.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <exception cref="NullReferenceException">Thrown when the Target property is null.</exception>
        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.RotateYTo(Rotation, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }
}
