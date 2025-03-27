namespace AlohaKit.Animations
{
    using System;
    using System.Threading.Tasks;
    using AlohaKit.Animations.Helpers;

    /// <summary>
    /// The AnimateColor class defines a mechanism to smoothly animate the color property of 
    /// a target visual element using progress-based interpolation.
    /// </summary>
    public class AnimateColor : AnimationBaseTrigger<Color>
    {
        /// <summary>
        /// Invokes the color animation on the target visual element.
        /// Uses interpolation to transition the specified property from the starting value 
        /// (From) to the target value (To).
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

            // Sets the default "From" color based on the current value of the target property.
            SetDefaultFrom((Color)sender.GetValue(TargetProperty));

            // Animate the transition of the color property using interpolation.
            sender.Animate($"AnimateColor{TargetProperty.PropertyName}", new Animation((progress) =>
            {
                sender.SetValue(TargetProperty, AnimationHelper.GetColorValue(From, To, progress));
            }),
            length: Duration,
            easing: EasingHelper.GetEasing(Easing));
        }
    }
}
