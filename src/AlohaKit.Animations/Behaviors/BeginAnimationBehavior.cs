namespace AlohaKit.Animations
{
    using System.Threading.Tasks;

    /// <summary>
    /// The BeginAnimationBehavior class provides functionality to automatically trigger an animation 
    /// when the behavior is attached to a visual element. It ensures the animation is associated with 
    /// the element and starts after a short delay.
    /// </summary>
    public class BeginAnimationBehavior : Behavior<VisualElement>
    {
        /// <summary>
        /// A reference to the associated visual element to which the behavior is attached.
        /// </summary>
        private static VisualElement associatedObject;

        /// <summary>
        /// Called when the behavior is attached to a visual element.
        /// Associates the animation with the element and begins the animation.
        /// </summary>
        /// <param name="bindable">The visual element to which the behavior is attached.</param>
        protected override async void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            associatedObject = bindable;

            if (Animation != null)
            {
                if (Animation.Target == null)
                {
                    Animation.Target = associatedObject;
                }

                // Introduces a short delay before starting the animation.
                var delay = Task.Delay(250);
                await Task.WhenAll(delay);
                await Animation.Begin();
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
