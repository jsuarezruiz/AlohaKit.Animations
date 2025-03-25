namespace AlohaKit.Animations
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// An animation that allow an element to rotate around the Y-axis 
    /// while transitioning its opacity.
    /// </summary>
    public class FlipAnimation : AnimationBase
    {
        /// <summary>
        /// Specifies the direction for a flip animation or effect.
        /// </summary>
        public enum FlipDirection
        {
            /// <summary>
            /// Indicates a flip animation or effect directed to the left.
            /// </summary>
            Left,

            /// <summary>
            /// Indicates a flip animation or effect directed to the right.
            /// </summary>
            Right
        }

        /// <summary>
        /// Bindable property for specifying the direction of the flip animation.
        /// </summary>
        public static readonly BindableProperty DirectionProperty =
            BindableProperty.Create(
                nameof(Direction),
                typeof(FlipDirection),
                typeof(FlipAnimation),
                FlipDirection.Right,
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the direction of the flip animation.
        /// The direction can be either <see cref="FlipDirection.Left"/> or <see cref="FlipDirection.Right"/>.
        /// </summary>
        public FlipDirection Direction
        {
            get { return (FlipDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

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
                    Target.Animate("Flip", Flip(), 16, Convert.ToUInt32(Duration));
                });
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete
            });
        }

        internal Animation Flip()
        {
            var animation = new Animation();

            animation.WithConcurrent((f) => Target.Opacity = f, 0.5, 1);
            animation.WithConcurrent((f) => Target.RotationY = f, (Direction == FlipDirection.Left) ? 90 : -90, 0, Microsoft.Maui.Easing.Linear);

            return animation;
        }
    }
}