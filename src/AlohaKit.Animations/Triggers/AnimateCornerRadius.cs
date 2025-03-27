namespace AlohaKit.Animations
{
    using System;
    using System.Threading.Tasks;
    using AlohaKit.Animations.Helpers;

    /// <summary>
    /// The AnimateCornerRadius class animates the corner radius property of a visual element,
    /// providing a smooth transition from an initial value to a target value.
    /// </summary>
    public class AnimateCornerRadius : AnimationBaseTrigger<CornerRadius>
    {
        /// <summary>
        /// Invokes the corner radius animation on the specified visual element.
        /// Uses progress-based interpolation to transition the corner radius property
        /// from the starting value (From) to the target value (To).
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
            SetDefaultFrom((CornerRadius)sender.GetValue(TargetProperty));

            // Animate the transition of the corner radius property using interpolation.
            sender.Animate($"AnimateCornerRadius{TargetProperty.PropertyName}", new Animation((progress) =>
            {
                sender.SetValue(TargetProperty, AnimationHelper.GetCornerRadiusValue(From, To, progress));
            }),
            length: Duration,
            easing: EasingHelper.GetEasing(Easing));
        }
    }
}
