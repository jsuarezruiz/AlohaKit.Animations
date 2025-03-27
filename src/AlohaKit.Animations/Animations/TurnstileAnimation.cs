namespace AlohaKit.Animations
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents an animation that performs a "turnstile-in" effect by rotating and translating 
    /// the target element as it enters.
    /// </summary>
    public class TurnstileInAnimation : AnimationBase
    {
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
                    Target.Animate("TurnstileIn", TurnstileIn(), 16, Convert.ToUInt32(Duration));
                });
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete
            });
        }

        internal Animation TurnstileIn()
        {
            var animation = new Animation();

            animation.WithConcurrent((f) => Target.RotationY = f, 75, 0, Microsoft.Maui.Easing.CubicOut);
            animation.WithConcurrent((f) => Target.Opacity = f, 0, 1, null, 0, 0.01);

            return animation;
        }
    }

    public class TurnstileOutAnimation : AnimationBase
    {
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
                    Target.Animate("TurnstileOut", TurnstileOut(), 16, Convert.ToUInt32(Duration));
                });
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete
            });
        }

        internal Animation TurnstileOut()
        {
            var animation = new Animation();

            animation.WithConcurrent((f) => Target.RotationY = f, 0, -75, Microsoft.Maui.Easing.CubicOut);
            animation.WithConcurrent((f) => Target.Opacity = f, 1, 0, null, 0.9, 1);

            return animation;
        }
    }
}
