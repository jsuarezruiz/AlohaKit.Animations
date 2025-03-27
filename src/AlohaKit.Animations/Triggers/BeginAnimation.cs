namespace AlohaKit.Animations
{
    /// <summary>
    /// The BeginAnimation class defines a trigger action for starting an animation 
    /// on a target visual element when the trigger is activated.
    /// </summary>
    [ContentProperty("Animation")]
    public class BeginAnimation : TriggerAction<VisualElement>
    {
        /// <summary>
        /// Gets or sets the animation to be executed when the trigger action is invoked.
        /// </summary>
        public AnimationBase Animation { get; set; }

        /// <summary>
        /// Executes the specified animation on the target visual element.
        /// </summary>
        /// <param name="sender">The visual element on which the animation is applied.</param>
        protected override async void Invoke(VisualElement sender)
        {
            if (Animation != null)
                await Animation.Begin();
        }
    }
}
