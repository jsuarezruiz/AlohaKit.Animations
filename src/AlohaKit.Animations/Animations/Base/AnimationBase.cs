namespace AlohaKit.Animations
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The AnimationBase class serves as an abstract base for animations, offering configurable properties 
    /// such as duration, delay, easing, and repeat behavior.
    /// </summary>
    public abstract class AnimationBase : BindableObject
    {
        /// <summary>
        /// A CancellationTokenSource for managing animation timer cancellation.
        /// </summary>
        private CancellationTokenSource _animateTimerCancellationTokenSource;

        /// <summary>
        /// Bindable property for specifying the target visual element of the animation.
        /// </summary>
        public static readonly BindableProperty TargetProperty =
            BindableProperty.Create(
                nameof(Target),
                typeof(VisualElement),
                typeof(AnimationBase),
                null,
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the target visual element for the animation.
        /// </summary>
        public VisualElement Target
        {
            get { return (VisualElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        /// <summary>
        /// Bindable property for specifying the duration of the animation in milliseconds.
        /// </summary>
        public static readonly BindableProperty DurationProperty =
            BindableProperty.Create(
                nameof(Duration),
                typeof(string),
                typeof(AnimationBase),
                "1000",
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the duration of the animation, represented as a string in milliseconds.
        /// </summary>
        public string Duration
        {
            get { return (string)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        /// <summary>
        /// Bindable property for specifying the easing type of the animation.
        /// </summary>
        public static readonly BindableProperty EasingProperty =
            BindableProperty.Create(
                nameof(Easing),
                typeof(EasingType),
                typeof(AnimationBase),
                EasingType.Linear,
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the easing type of the animation.
        /// </summary>
        public EasingType Easing
        {
            get { return (EasingType)GetValue(EasingProperty); }
            set { SetValue(EasingProperty, value); }
        }

        /// <summary>
        /// Bindable property for specifying a delay before the animation begins, in milliseconds.
        /// </summary>
        public static readonly BindableProperty DelayProperty =
            BindableProperty.Create(
                nameof(Delay),
                typeof(int),
                typeof(AnimationBase),
                0,
                propertyChanged: (bindable, oldValue, newValue) =>
                    ((AnimationBase)bindable).Delay = (int)newValue);

        /// <summary>
        /// Gets or sets the delay before the animation begins, in milliseconds.
        /// </summary>
        public int Delay
        {
            get { return (int)GetValue(DelayProperty); }
            set { SetValue(DelayProperty, value); }
        }

        /// <summary>
        /// Bindable property for specifying whether the animation should repeat indefinitely.
        /// </summary>
        public static readonly BindableProperty RepeatForeverProperty =
            BindableProperty.Create(
                nameof(RepeatForever),
                typeof(bool),
                typeof(AnimationBase),
                false,
                propertyChanged: (bindable, oldValue, newValue) =>
                    ((AnimationBase)bindable).RepeatForever = (bool)newValue);

        /// <summary>
        /// Gets or sets a value indicating whether the animation should repeat indefinitely.
        /// </summary>
        public bool RepeatForever
        {
            get { return (bool)GetValue(RepeatForeverProperty); }
            set { SetValue(RepeatForeverProperty, value); }
        }

        protected abstract Task BeginAnimation();

        public async Task Begin()
        {
            if (Delay > 0)
            {
                await Task.Delay(Delay);
            }

            if (!RepeatForever)
            {
                await BeginAnimation();
            }
            else
            {
                RepeatAnimation(new CancellationTokenSource());
            }
        }

        public void End()
        {
            Microsoft.Maui.Controls.ViewExtensions.CancelAnimations(Target);

            if (_animateTimerCancellationTokenSource != null)
            {
                _animateTimerCancellationTokenSource.Cancel();
            }
        }

        internal void RepeatAnimation(CancellationTokenSource tokenSource)
        {
            _animateTimerCancellationTokenSource = tokenSource;

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0612 // Type or member is obsolete
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (!_animateTimerCancellationTokenSource.IsCancellationRequested)
                {
                    await BeginAnimation();

                    RepeatAnimation(_animateTimerCancellationTokenSource);
                }
            });
#pragma warning restore CS0612 // Type or member is obsolete
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}