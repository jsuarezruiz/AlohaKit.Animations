namespace AlohaKit.Animations
{
    using System;
    using System.Threading.Tasks;

    public class JumpAnimation : AnimationBase
    {
        private const int Movement = -25;

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
                    Target.Animate("Jump", Jump(), 16, Convert.ToUInt32(Duration));
                });
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete
            });
        }

        internal Animation Jump()
        {
            var animation = new Animation();

            animation.WithConcurrent(
              (f) => Target.TranslationY = f,
              Target.TranslationY, Target.TranslationX,
              Microsoft.Maui.Easing.Linear, 0, 0.2);

            animation.WithConcurrent(
              (f) => Target.TranslationY = f,
              Target.TranslationY + Movement, Target.TranslationX,
              Microsoft.Maui.Easing.Linear, 0.2, 0.4);

            animation.WithConcurrent(
             (f) => Target.TranslationY = f,
             Target.TranslationY, Target.TranslationX,
             Microsoft.Maui.Easing.Linear, 0.5, 1.0);

            return animation;
        }
    }
}
