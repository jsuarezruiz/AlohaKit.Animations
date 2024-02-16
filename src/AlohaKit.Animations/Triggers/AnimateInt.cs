namespace AlohaKit.Animations.Triggers
{
    using System;
    using System.Threading.Tasks;
    using AlohaKit.Animations.Helpers;

    public class AnimateInt : AnimationBaseTrigger<int>
    {
        protected override async void Invoke(VisualElement sender)
        {
            if (TargetProperty == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            if (Delay > 0)
                await Task.Delay(Delay);

            SetDefaultFrom((int)sender.GetValue(TargetProperty));

            sender.Animate($"AnimateInt{TargetProperty.PropertyName}", new Animation((progress) =>
            {
                sender.SetValue(TargetProperty, AnimationHelper.GetIntValue(From, To, progress));
            }),
            length: Duration,
            easing: EasingHelper.GetEasing(Easing));
        }
    }
}