/// <summary>
/// Represents a behavior that applies an entrance animation to a visual element and its children.
/// </summary>
namespace AlohaKit.Animations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AlohaKit.Animations.Helpers;

    /// <summary>
    /// The EntranceTransition class animates visual elements with an entrance effect that includes
    /// translation and opacity adjustments. It handles animations for the target element and its child elements.
    /// </summary>
    public class EntranceTransition : Behavior<VisualElement>
    {
        /// <summary>
        /// Specifies the delay between animations for child elements in milliseconds.
        /// </summary>
        private const int Delay = 100;

        /// <summary>
        /// Specifies the initial translation offset for the entrance animation.
        /// </summary>
        private const int TranslateFrom = 6;

        /// <summary>
        /// Stores the associated visual element to which the behavior is attached.
        /// </summary>
        private VisualElement _associatedObject;

        /// <summary>
        /// Stores the child visual elements of the associated object.
        /// </summary>
        private IEnumerable<VisualElement> _childrens;

        /// <summary>
        /// Bindable property for specifying the duration of the animation in milliseconds.
        /// </summary>
        public static readonly BindableProperty DurationProperty =
            BindableProperty.Create(
                nameof(Duration),
                typeof(string),
                typeof(EntranceTransition),
                "500",
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the duration of the entrance animation, represented as a string in milliseconds.
        /// </summary>
        public string Duration
        {
            get { return (string)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        /// <summary>
        /// Called when the behavior is attached to a visual element.
        /// Initializes child elements and subscribes to property changes.
        /// </summary>
        /// <param name="bindable">The visual element to which the behavior is attached.</param>
        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            _associatedObject = bindable;
            _childrens = VisualTreeHelper.GetChildren<VisualElement>(_associatedObject);
            _associatedObject.PropertyChanged += OnPropertyChanged;
        }

        /// <summary>
        /// Called when the behavior is detached from a visual element.
        /// Stops animations and clears references to the associated object and its children.
        /// </summary>
        /// <param name="bindable">The visual element from which the behavior is detached.</param>
        protected override void OnDetachingFrom(VisualElement bindable)
        {
            StopAnimation();
            _associatedObject.PropertyChanged -= OnPropertyChanged;
            _associatedObject = null;
            _childrens = null;
            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        /// Handles property changes for the associated visual element.
        /// Starts the animation when the "Renderer" property changes.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Details about the property change event.</param>
        async void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Renderer")
            {
                await StartAnimationAsync();
            }
        }

        /// <summary>
        /// Sets the initial transition state for the associated visual element and its children.
        /// Adjusts opacity and translation values.
        /// </summary>
        void SetInitialTransitionState()
        {
            if (_childrens.Any())
            {
                foreach (var child in _childrens)
                    SetInitialTransitionState(child);
            }
            else
                SetInitialTransitionState(_associatedObject);
        }

        /// <summary>
        /// Sets the initial transition state for a specific visual element.
        /// </summary>
        /// <param name="element">The visual element to set the initial state for.</param>
        void SetInitialTransitionState(VisualElement element)
        {
            element.Opacity = 0;
            element.TranslationX = _associatedObject.TranslationX + TranslateFrom;
            element.TranslationY = _associatedObject.TranslationY + TranslateFrom;
        }

        /// <summary>
        /// Stops all animations for the associated visual element and its children.
        /// </summary>
        void StopAnimation()
        {
            if (_childrens.Any())
            {
                foreach (var child in _childrens)
                    Microsoft.Maui.Controls.ViewExtensions.CancelAnimations(child);
            }
            else
                Microsoft.Maui.Controls.ViewExtensions.CancelAnimations(_associatedObject);
        }

        /// <summary>
        /// Starts the entrance animation asynchronously for the associated visual element and its children.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        async Task StartAnimationAsync()
        {
            StopAnimation();
            SetInitialTransitionState();

            if (_childrens.Any())
            {
                foreach (var child in _childrens)
                    await AnimateItemAsync(child);
            }
            else
            {
                if (!HasParentEntranceTransition(_associatedObject))
                    await AnimateItemAsync(_associatedObject);
            }
        }

        /// <summary>
        /// Animates a single visual element with translation and opacity transitions.
        /// </summary>
        /// <param name="element">The visual element to animate.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        async Task AnimateItemAsync(VisualElement element)
        {
            await Task.Delay(Delay);

            var parentAnimation = new Animation();

            var translateXAnimation = new Animation(v => element.TranslationX = v, element.TranslationX, 0, Easing.SpringIn);
            var translateYAnimation = new Animation(v => element.TranslationY = v, element.TranslationY, 0, Easing.SpringIn);
            var opacityAnimation = new Animation(v => element.Opacity = v, 0, 1, Easing.CubicIn);

            parentAnimation.Add(0, 0.75, translateXAnimation);
            parentAnimation.Add(0, 0.75, translateYAnimation);
            parentAnimation.Add(0, 1, opacityAnimation);

            parentAnimation.Commit(_associatedObject, "EntranceTransition" + element.Id, 16, Convert.ToUInt32(Duration), null, (v, c) => StopAnimation());
        }

        /// <summary>
        /// Checks if the specified visual element has a parent with the EntranceTransition behavior.
        /// </summary>
        /// <param name="element">The visual element to check.</param>
        /// <returns>True if the parent has the EntranceTransition behavior; otherwise, false.</returns>
        bool HasParentEntranceTransition(VisualElement element)
        {
            VisualElement parent = VisualTreeHelper.GetParent<VisualElement>(element);
            var behaviors = parent.Behaviors;
            return behaviors.OfType<EntranceTransition>().FirstOrDefault() != null;
        }
    }
}
