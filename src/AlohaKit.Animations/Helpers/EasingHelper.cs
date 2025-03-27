namespace AlohaKit.Animations.Helpers
{
    /// <summary>
    /// The EasingHelper class provides a method to map <see cref="EasingType"/> values 
    /// to corresponding <see cref="Easing"/> objects.
    /// </summary>
    public static class EasingHelper
    {
        /// <summary>
        /// Retrieves the easing function corresponding to the specified <see cref="EasingType"/>.
        /// </summary>
        /// <param name="type">The easing type to retrieve the corresponding easing function for.</param>
        /// <returns>
        /// The <see cref="Easing"/> function corresponding to the specified easing type.
        /// Returns <c>null</c> if the easing type is not recognized.
        /// </returns>
        public static Easing GetEasing(EasingType type)
        {
            switch(type)
            {
                case EasingType.BounceIn:
                    return Easing.BounceIn;
                case EasingType.BounceOut:
                    return Easing.BounceOut;
                case EasingType.CubicIn:
                    return Easing.CubicIn;
                case EasingType.CubicInOut:
                    return Easing.CubicInOut;
                case EasingType.CubicOut:
                    return Easing.CubicOut;
                case EasingType.Linear:
                    return Easing.Linear;
                case EasingType.SinIn:
                    return Easing.SinIn;
                case EasingType.SinInOut:
                    return Easing.SinInOut;
                case EasingType.SinOut:
                    return Easing.SinOut;
                case EasingType.SpringIn:
                    return Easing.SpringIn;
                case EasingType.SpringOut:
                    return Easing.SpringOut;
            }

            return null;
        }
    }
}
