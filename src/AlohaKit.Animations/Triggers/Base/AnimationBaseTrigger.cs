namespace AlohaKit.Animations
{
    using System;

    /// <summary>
    /// The AnimationBaseTrigger class provides the foundation for creating custom animation triggers 
    /// by defining common properties, methods, and behavior for animations.
    /// </summary>
    /// <typeparam name="T">The type of the property to be animated.</typeparam>
    public abstract class AnimationBaseTrigger<T> : TriggerAction<VisualElement>
    {
        /// <summary>
        /// Gets or sets the starting value of the animation.
        /// </summary>
        public T From { get; set; } = default(T);

        /// <summary>
        /// Gets or sets the target value of the animation.
        /// </summary>
        public T To { get; set; } = default(T);

        /// <summary>
        /// Gets or sets the duration of the animation in milliseconds.
        /// </summary>
        public uint Duration { get; set; } = 1000;

        /// <summary>
        /// Gets or sets the delay before the animation begins, in milliseconds.
        /// </summary>
        public int Delay { get; set; } = 0;

        /// <summary>
        /// Gets or sets the easing function to apply to the animation.
        /// </summary>
        public EasingType Easing { get; set; } = EasingType.Linear;

        /// <summary>
        /// Gets or sets the bindable property that will be animated.
        /// </summary>
        public BindableProperty TargetProperty { get; set; } = default(BindableProperty);

        /// <summary>
        /// Invokes the animation on the specified visual element.
        /// This method must be implemented in derived classes.
        /// </summary>
        /// <param name="sender">The visual element on which the animation is applied.</param>
        /// <exception cref="NotImplementedException">
        /// Thrown to indicate that the method must be implemented in derived classes.
        /// </exception>
        protected override void Invoke(VisualElement sender)
        {
            throw new NotImplementedException("Please Implement Invoke() in derived-class");
        }

        /// <summary>
        /// Sets the default "From" value for the animation if it has not been explicitly specified.
        /// </summary>
        /// <param name="property">The current property value to use as the default "From" value.</param>
        protected void SetDefaultFrom(T property)
        {
            From = (From == null || From.Equals(default(T))) ? property : From;
        }
    }
}