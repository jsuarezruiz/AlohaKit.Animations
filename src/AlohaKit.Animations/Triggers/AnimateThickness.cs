namespace AlohaKit.Animations
{
    using System;
    using System.Threading.Tasks;
    using AlohaKit.Animations.Helpers;

    /// <summary>
    /// The AnimateThickness class provides functionality to animate the transition of a thickness property
    /// on a visual element, using interpolation based on animation progress.
    /// </summary>
    public class AnimateThickness : AnimationBaseTrigger<Thickness>
    {
        /// <summary>
        /// Invokes the thickness animation on the specified visual element.
        /// Uses progress-based interpolation to transition the thickness property 
        /// from the initial value (From) to the target value (To).
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
            SetDefaultFrom((Thickness)sender.GetValue(TargetProperty));

            // Animate the transition of the thickness property using progress-based interpolation.
            sender.Animate($"AnimateThickness{TargetProperty.PropertyName}", new Animation((progress) =>
            {
                sender.SetValue(TargetProperty, AnimationHelper.GetThicknessValue(From, To, progress));
            }),
            length: Duration,
            easing: EasingHelper.GetEasing(Easing));
        }
    }
}
