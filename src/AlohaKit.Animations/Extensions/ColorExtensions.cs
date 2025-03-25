// https://developer.xamarin.com/samples/xamarin-forms/userinterface/animation/custom/
namespace AlohaKit.Animations
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The ColorExtensions class contains methods to animate color changes and manage color animations
    /// for visual elements.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Animates the transition of a color property from one value to another on the specified visual element.
        /// </summary>
        /// <param name="self">The visual element to which the color animation is applied.</param>
        /// <param name="fromColor">The starting color value.</param>
        /// <param name="toColor">The target color value.</param>
        /// <param name="callback">A callback function to handle the interpolated color during the animation.</param>
        /// <param name="length">The duration of the animation in milliseconds (default is 250).</param>
        /// <param name="easing">The easing function to apply to the animation (default is linear).</param>
        /// <returns>
        /// A Task representing the asynchronous operation.
        /// Returns <c>true</c> if the animation completes successfully; <c>false</c> otherwise.
        /// </returns>
        public static Task<bool> ColorTo(this VisualElement self, Color fromColor, Color toColor, Action<Color> callback, uint length = 250, Easing easing = null)
        {
            Color transform(double t) =>
                Color.FromRgba(fromColor.Red + t * (toColor.Red - fromColor.Red),
                               fromColor.Green + t * (toColor.Green - fromColor.Green),
                               fromColor.Blue + t * (toColor.Blue - fromColor.Blue),
                               fromColor.Alpha + t * (toColor.Alpha - fromColor.Alpha));

            return ColorAnimation(self, "ColorTo", transform, callback, length, easing);
        }

        /// <summary>
        /// Cancels the color animation on the specified visual element.
        /// </summary>
        /// <param name="self">The visual element on which to cancel the color animation.</param>
        public static void CancelAnimation(this VisualElement self)
        {
            self.AbortAnimation("ColorTo");
        }

        static Task<bool> ColorAnimation(VisualElement element, string name, Func<double, Color> transform, Action<Color> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<Color>(name, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));

            return taskCompletionSource.Task;
        }
    }
}
