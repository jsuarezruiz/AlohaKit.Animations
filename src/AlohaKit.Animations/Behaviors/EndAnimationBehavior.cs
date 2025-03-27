namespace AlohaKit.Animations
{
    /// <summary>
    /// The EndAnimationBehavior class provides functionality to automatically stop an animation
    /// when the behavior is attached to a visual element. It ensures the animation is associated with
    /// the element and invokes the End method on the animation.
    /// </summary>
    public class EndAnimationBehavior : Behavior<VisualElement>
    {
        /// <summary>
        /// A reference to the visual element associated with the behavior.
        /// </summary>
        private static VisualElement associatedObject;

        /// <summary>
        /// Called when the behavior is attached to a visual element.
        /// Associates the animation with the element and ends the animation.
        /// </summary>
        /// <param name="bindable">The visual element to which the behavior is attached.</param>
        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            associatedObject = bindable;

            if (Animation != null)
            {
                if (Animation.Target == null)
                {
                    Animation.Target = associatedObject;
                }

                Animation.End();
            }
        }

        /// <summary>
        /// Called when the behavior is detached from a visual element.
        /// Clears the association with the visual element.
        /// </summary>
        /// <param name="bindable">The visual element from which the behavior is detached.</param>
        protected override void OnDetachingFrom(VisualElement bindable)
        {
            associatedObject = null;
            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        /// Bindable property for specifying the animation to be executed when the behavior is attached.
        /// </summary>
        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(
                nameof(Animation),
                typeof(AnimationBase),
                typeof(BeginAnimationBehavior),
                null,
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the animation to be executed when the behavior is attached.
        /// </summary>
        public AnimationBase Animation
        {
            get { return (AnimationBase)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }
    }
}
