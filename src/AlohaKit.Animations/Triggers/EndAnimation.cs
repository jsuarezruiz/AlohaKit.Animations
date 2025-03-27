namespace AlohaKit.Animations
{
    /// <summary>
    /// The EndAnimation class defines a trigger action for stopping an animation
    /// applied to a visual element when the trigger is activated.
    /// </summary>
    public class EndAnimation : TriggerAction<VisualElement>
    {
        /// <summary>
        /// Gets or sets the animation to be stopped when the trigger action is invoked.
        /// </summary>
        public AnimationBase Animation { get; set; }

        /// <summary>
        /// Executes the trigger action, ending the specified animation on the target visual element.
        /// </summary>
        /// <param name="sender">The visual element on which the animation is stopped.</param>
        protected override void Invoke(VisualElement sender)
        {
            if (Animation != null)
                Animation.End();
        }
    }
}
