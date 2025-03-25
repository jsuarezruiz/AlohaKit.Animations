namespace AlohaKit.Animations.Helpers
{
    /// <summary>
    /// The AnimationHelper class contains helper methods for calculating intermediate values 
    /// for various types of properties during an animation.
    /// </summary>
    public static class AnimationHelper
    {
        /// <summary>
        /// Calculates an interpolated integer value based on the animation progress.
        /// </summary>
        /// <param name="from">The starting integer value.</param>
        /// <param name="to">The ending integer value.</param>
        /// <param name="animationProgress">The progress of the animation, from 0.0 to 1.0.</param>
        /// <returns>The interpolated integer value.</returns>
        public static int GetIntValue(int from, int to, double animationProgress)
        {
            return (int)(from + (to - from) * animationProgress);
        }

        /// <summary>
        /// Calculates an interpolated double value based on the animation progress.
        /// </summary>
        /// <param name="from">The starting double value.</param>
        /// <param name="to">The ending double value.</param>
        /// <param name="animationProgress">The progress of the animation, from 0.0 to 1.0.</param>
        /// <returns>The interpolated double value.</returns>
        public static double GetDoubleValue(double from, double to, double animationProgress)
        {
            return from + (to - from) * animationProgress;
        }

        /// <summary>
        /// Calculates an interpolated color value based on the animation progress.
        /// </summary>
        /// <param name="from">The starting color.</param>
        /// <param name="to">The ending color.</param>
        /// <param name="animationProgress">The progress of the animation, from 0.0 to 1.0.</param>
        /// <returns>The interpolated color value.</returns>
        public static Color GetColorValue(Color from, Color to, double animationProgress)
        {
            var newR = (to.Red - from.Red) * animationProgress;
            var newG = (to.Green - from.Green) * animationProgress;
            var newB = (to.Blue - from.Blue) * animationProgress;
            return Color.FromRgb(from.Red + newR, from.Green + newG, from.Blue + newB);
        }

        /// <summary>
        /// Calculates an interpolated corner radius value based on the animation progress.
        /// </summary>
        /// <param name="from">The starting corner radius.</param>
        /// <param name="to">The ending corner radius.</param>
        /// <param name="animationProgress">The progress of the animation, from 0.0 to 1.0.</param>
        /// <returns>The interpolated corner radius value.</returns>
        public static CornerRadius GetCornerRadiusValue(CornerRadius from, CornerRadius to, double animationProgress)
        {
            return new CornerRadius(
                from.TopLeft + (to.TopLeft - from.TopLeft) * animationProgress,
                from.TopRight + (to.TopRight - from.TopRight) * animationProgress,
                from.BottomLeft + (to.BottomLeft - from.BottomLeft) * animationProgress,
                from.BottomRight + (to.BottomRight - from.BottomRight) * animationProgress);
        }

        /// <summary>
        /// Calculates an interpolated thickness value based on the animation progress.
        /// </summary>
        /// <param name="from">The starting thickness.</param>
        /// <param name="to">The ending thickness.</param>
        /// <param name="animationProgress">The progress of the animation, from 0.0 to 1.0.</param>
        /// <returns>The interpolated thickness value.</returns>
        public static Thickness GetThicknessValue(Thickness from, Thickness to, double animationProgress)
        {
            return new Thickness(
                from.Left + (to.Left - from.Left) * animationProgress,
                from.Top + (to.Top - from.Top) * animationProgress,
                from.Right + (to.Right - from.Right) * animationProgress,
                from.Bottom + (to.Bottom - from.Bottom) * animationProgress);
        }
    }
}
