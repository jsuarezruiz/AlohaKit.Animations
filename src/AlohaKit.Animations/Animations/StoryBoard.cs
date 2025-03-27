namespace AlohaKit.Animations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a storyboard that orchestrates a sequence of animations on a target element.
    /// </summary>
    [ContentProperty("Animations")]
    public class StoryBoard : AnimationBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoryBoard"/> class with an empty list of animations.
        /// </summary>
        public StoryBoard()
        {
            Animations = new List<AnimationBase>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoryBoard"/> class with a specified list of animations.
        /// </summary>
        /// <param name="animations">A list of animations to be managed by the storyboard.</param>
        public StoryBoard(List<AnimationBase> animations)
        {
            Animations = animations;
        }

        /// <summary>
        /// Gets the list of animations managed by the storyboard.
        /// </summary>
        public List<AnimationBase> Animations
        {
            get;
        }

        protected override async Task BeginAnimation()
        {
            foreach (var animation in Animations)
            {
                if (animation.Target == null)
                    animation.Target = Target;

                await animation.Begin();
            }
        }
    }
}
