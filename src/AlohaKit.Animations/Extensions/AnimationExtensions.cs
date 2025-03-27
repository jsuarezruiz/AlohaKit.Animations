/// <summary>
/// Provides extension methods for animating <see cref="VisualElement"/> objects using animations.
/// </summary>
namespace AlohaKit.Animations
{
    using System.Threading.Tasks;

    /// <summary>
    /// Contains extension methods to simplify applying animations to visual elements.
    /// </summary>
    public static class AnimationExtensions
    {
        /// <summary>
        /// Animates the specified <see cref="VisualElement"/> using the provided <see cref="AnimationBase"/> object.
        /// </summary>
        /// <param name="visualElement">The target visual element to be animated.</param>
        /// <param name="animation">The animation to apply to the visual element.</param>
        /// <returns>
        /// A Task representing the asynchronous operation.
        /// Returns <c>true</c> if the animation completes successfully; <c>false</c> otherwise.
        /// </returns>
        public static async Task<bool> Animate(this VisualElement visualElement, AnimationBase animation)
        {
            try
            {
                animation.Target = visualElement;

                await animation.Begin();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
