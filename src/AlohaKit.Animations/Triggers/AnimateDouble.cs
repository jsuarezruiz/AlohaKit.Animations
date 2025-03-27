namespace AlohaKit.Animations
{
    using System;
    using System.Threading.Tasks;
    using AlohaKit.Animations.Helpers;

    /// <summary>
    /// The AnimateDouble class provides a mechanism to animate the transition of a double value
    /// on a specified visual element, using interpolation based on animation progress.
    /// </summary>
    public class AnimateDouble : AnimationBaseTrigger<double>
    {
        /// <summary>
        /// Invokes the double property animation on the target visual element.
        /// Progress-based interpolation is applied to transition the property from the 
        /// initial value (From) to the target value (To).
        /// </summary>
        /// <param name="sender">The visual element on which the animation is applied.</param>
        /// <exception cref="NullReferenceException">Thrown if the TargetProperty is null.</exception>
        protected override async void Invoke(VisualElement sender)
        {
            if (TargetProperty == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            // Introduce a delay before starting the animation, if specified.
            if (Delay > 0)
                await Task.Delay(Delay);

            // Sets the default "From" value based on the current value of the target property.
            SetDefaultFrom((double)sender.GetValue(TargetProperty));

            // Animate the transition of the double property using progress-based interpolation.
            sender.Animate($"AnimateDouble{TargetProperty.PropertyName}", new Animation((progress) =>
            {
                sender.SetValue(TargetProperty, AnimationHelper.GetDoubleValue(From, To, progress));
            }),
            length: Duration,
            easing: EasingHelper.GetEasing(Easing));
        }
    }
}
