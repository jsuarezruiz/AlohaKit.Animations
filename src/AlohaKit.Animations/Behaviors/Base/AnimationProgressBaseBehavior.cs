namespace AlohaKit.Animations
{
    /// <summary>
    /// The AnimationProgressBaseBehavior class provides the foundation for creating behaviors
    /// that animate properties of a visual element based on the progress of an animation.
    /// </summary>
    public abstract class AnimationProgressBaseBehavior : Behavior<VisualElement>
    {
        /// <summary>
        /// Bindable property for the current progress of the animation.
        /// </summary>
        public static readonly BindableProperty ProgressProperty =
            BindableProperty.Create(
                nameof(Progress),
                typeof(double?),
                typeof(AnimationProgressBaseBehavior),
                default(double),
                BindingMode.TwoWay,
                null,
                OnChanged);

        /// <summary>
        /// Gets or sets the current progress of the animation, where the value is a nullable double.
        /// </summary>
        public double? Progress
        {
            get { return (double?)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        /// <summary>
        /// Bindable property for the minimum progress value of the animation.
        /// </summary>
        public static readonly BindableProperty MinimumProperty =
            BindableProperty.Create(
                nameof(Minimum),
                typeof(double),
                typeof(AnimationProgressBaseBehavior),
                0.0d,
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the minimum progress value of the animation.
        /// </summary>
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        /// <summary>
        /// Bindable property for the maximum progress value of the animation.
        /// </summary>
        public static readonly BindableProperty MaximumProperty =
            BindableProperty.Create(
                nameof(Maximum),
                typeof(double),
                typeof(AnimationProgressBaseBehavior),
                100.0d,
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the maximum progress value of the animation.
        /// </summary>
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        /// <summary>
        /// Bindable property for the easing function of the animation.
        /// </summary>
        public static readonly BindableProperty EasingProperty =
            BindableProperty.Create(
                nameof(Easing),
                typeof(EasingType),
                typeof(AnimationProgressBaseBehavior),
                EasingType.Linear,
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the easing function applied to the animation.
        /// </summary>
        public EasingType Easing
        {
            get { return (EasingType)GetValue(EasingProperty); }
            set { SetValue(EasingProperty, value); }
        }

        /// <summary>
        /// Bindable property for the target property that will be animated.
        /// </summary>
        public static readonly BindableProperty TargetPropertyProperty =
            BindableProperty.Create(
                nameof(TargetProperty),
                typeof(BindableProperty),
                typeof(AnimationProgressBaseBehavior),
                null,
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the bindable property that will be animated.
        /// </summary>
        public BindableProperty TargetProperty
        {
            get { return (BindableProperty)GetValue(TargetPropertyProperty); }
            set { SetValue(TargetPropertyProperty, value); }
        }

        /// <summary>
        /// Gets the target visual element to which the behavior is attached.
        /// </summary>
        public VisualElement Target { get; private set; }

        /// <summary>
        /// Called when the behavior is attached to a visual element.
        /// </summary>
        /// <param name="bindable">The visual element to which the behavior is attached.</param>
        protected override void OnAttachedTo(VisualElement bindable)
        {
            Target = bindable;
            Update();
            base.OnAttachedTo(bindable);
        }

        /// <summary>
        /// Called when the value of the <see cref="Progress"/> property changes.
        /// </summary>
        /// <param name="bindable">The bindable object where the property changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        protected static void OnChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AnimationProgressBaseBehavior)bindable).Update();
        }

        /// <summary>
        /// Called when the behavior is detached from a visual element.
        /// </summary>
        /// <param name="bindable">The visual element from which the behavior is detached.</param>
        protected override void OnDetachingFrom(VisualElement bindable)
        {
            base.OnDetachingFrom(bindable);
            Target = null;
        }

        /// <summary>
        /// Performs the animation update logic. This method must be implemented by derived classes.
        /// </summary>
        protected abstract void OnUpdate();

        /// <summary>
        /// Updates the animation based on the current progress and target properties.
        /// </summary>
        protected void Update()
        {
            if (Target != null && Progress.HasValue)
            {
                OnUpdate();
            }
        }
    }
}
