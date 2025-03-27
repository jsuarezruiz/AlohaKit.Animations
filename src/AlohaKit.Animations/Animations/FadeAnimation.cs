namespace AlohaKit.Animations
{
    using Helpers;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The FadeToAnimation class adjusts the opacity of a target element over a specified duration.
    /// </summary>
    public class FadeToAnimation : AnimationBase
    {
        /// <summary>
        /// Bindable property for specifying the target opacity value of the animation.
        /// </summary>
        public static readonly BindableProperty OpacityProperty =
            BindableProperty.Create(
                nameof(Opacity),
                typeof(double),
                typeof(FadeToAnimation),
                default(double),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the target opacity for the animation.
        /// </summary>
        public double Opacity
        {
            get { return (double)GetValue(OpacityProperty); }
            set { SetValue(OpacityProperty, value); }
        }

        /// <summary>
        /// Begins the fade-to animation, adjusting the opacity of the target element.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <exception cref="NullReferenceException">Thrown if the Target property is null.</exception>
        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.FadeTo(Opacity, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }

    /// <summary>
    /// Represents an animation that fades in a visual element while translating it along the Y-axis.
    /// </summary>
    public class FadeInAnimation : AnimationBase
    {
        /// <summary>
        /// Defines the direction of the fade-in animation (Up or Down).
        /// </summary>
        public enum FadeDirection
        {
            Up,
            Down
        }

        /// <summary>
        /// Bindable property for specifying the fade direction of the animation.
        /// </summary>
        public static readonly BindableProperty DirectionProperty =
            BindableProperty.Create(
                nameof(Direction),
                typeof(FadeDirection),
                typeof(FadeInAnimation),
                FadeDirection.Up,
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the direction of the fade-in animation.
        /// </summary>
        public FadeDirection Direction
        {
            get { return (FadeDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        /// <summary>
        /// Begins the fade-in animation, adjusting the opacity and Y-axis translation of the target element.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <exception cref="NullReferenceException">Thrown if the Target property is null.</exception>
        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Task.Run(() =>
            {
#pragma warning disable CS0612 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
                Device.BeginInvokeOnMainThread(() =>
                {
                    Target.Animate("FadeIn", FadeIn(), 16, Convert.ToUInt32(Duration));
                });
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete
            });
        }

        /// <summary>
        /// Creates the fade-in animation sequence with concurrent opacity and translation changes.
        /// </summary>
        /// <returns>An Animation object defining the fade-in effect.</returns>
        internal Animation FadeIn()
        {
            var animation = new Animation();

            animation.WithConcurrent(
                (f) => Target.Opacity = f,
                0, 1, Microsoft.Maui.Easing.CubicOut);

            animation.WithConcurrent(
                (f) => Target.TranslationY = f,
                Target.TranslationY + ((Direction == FadeDirection.Up) ? 50 : -50), Target.TranslationY,
                Microsoft.Maui.Easing.CubicOut, 0, 1);

            return animation;
        }
    }

    /// <summary>
    /// Represents an animation that fades out a visual element while translating it along the Y-axis.
    /// </summary>
    public class FadeOutAnimation : AnimationBase
    {
        /// <summary>
        /// Defines the direction of the fade-out animation (Up or Down).
        /// </summary>
        public enum FadeDirection
        {
            Up,
            Down
        }

        /// <summary>
        /// Bindable property for specifying the fade direction of the animation.
        /// </summary>
        public static readonly BindableProperty DirectionProperty =
            BindableProperty.Create(
                nameof(Direction),
                typeof(FadeDirection),
                typeof(FadeOutAnimation),
                FadeDirection.Up,
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the direction of the fade-out animation.
        /// </summary>
        public FadeDirection Direction
        {
            get { return (FadeDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        /// <summary>
        /// Begins the fade-out animation, reducing the opacity and adjusting the Y-axis translation of the target element.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <exception cref="NullReferenceException">Thrown if the Target property is null.</exception>
        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Task.Run(() =>
            {
#pragma warning disable CS0612 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
                Device.BeginInvokeOnMainThread(() =>
                {
                    Target.Animate("FadeOut", FadeOut(), 16, Convert.ToUInt32(Duration));
                });
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete
            });
        }

        /// <summary>
        /// Creates the fade-out animation sequence with concurrent opacity and translation changes.
        /// </summary>
        /// <returns>An Animation object defining the fade-out effect.</returns>
        internal Animation FadeOut()
        {
            var animation = new Animation();

            animation.WithConcurrent(
                (f) => Target.Opacity = f,
                1, 0);

            animation.WithConcurrent(
                (f) => Target.TranslationY = f,
                Target.TranslationY, Target.TranslationY + ((Direction == FadeDirection.Up) ? 50 : -50));

            return animation;
        }
    }
}
