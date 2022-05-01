namespace MauiAnimation
{
    using System;
    using System.Threading.Tasks;

    public class HeartAnimation : AnimationBase
    {
        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Target.Animate("Hearth", Hearth(), 16, Convert.ToUInt32(Duration));
                });
            });
        }

        internal Animation Hearth()
        {
            var animation = new Animation();

            animation.WithConcurrent(
               (f) => Target.Scale = f,
               Target.Scale, Target.Scale,
               Microsoft.Maui.Easing.Linear, 0, 0.1);

            animation.WithConcurrent(
               (f) => Target.Scale = f,
               Target.Scale, Target.Scale * 1.1,
               Microsoft.Maui.Easing.Linear, 0.1, 0.4);

            animation.WithConcurrent(
               (f) => Target.Scale = f,
               Target.Scale * 1.1, Target.Scale,
               Microsoft.Maui.Easing.Linear, 0.4, 0.5);

            animation.WithConcurrent(         
                (f) => Target.Scale = f,
                Target.Scale, Target.Scale * 1.1,
                Microsoft.Maui.Easing.Linear, 0.5, 0.8);

            animation.WithConcurrent(
               (f) => Target.Scale = f,
               Target.Scale * 1.1, Target.Scale,
               Microsoft.Maui.Easing.Linear, 0.8, 1);

            return animation;
        }
    }
}
