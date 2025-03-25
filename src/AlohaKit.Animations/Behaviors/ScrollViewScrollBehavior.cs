/// <summary>
/// Represents a behavior for tracking the scroll position of a <see cref="ScrollView"/> and calculating
/// various scroll-related values, such as relative and percentage-based scroll positions.
/// </summary>
namespace AlohaKit.Animations
{
    /// <summary>
    /// The ScrollViewScrollBehavior class provides bindable properties to observe the horizontal and vertical scroll
    /// positions of a <see cref="ScrollView"/> and calculates relative and percentage-based scroll values.
    /// </summary>
    public class ScrollViewScrollBehavior : Behavior<ScrollView>
    {
        /// <summary>
        /// Bindable property for the horizontal scroll value in pixels.
        /// </summary>
        public static readonly BindableProperty ScrollXProperty =
            BindableProperty.Create(
                nameof(ScrollX),
                typeof(double),
                typeof(ScrollViewScrollBehavior),
                default(double),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the horizontal scroll value in pixels.
        /// </summary>
        public double ScrollX
        {
            get { return (double)GetValue(ScrollXProperty); }
            set { SetValue(ScrollXProperty, value); }
        }

        /// <summary>
        /// Bindable property for the vertical scroll value in pixels.
        /// </summary>
        public static readonly BindableProperty ScrollYProperty =
            BindableProperty.Create(
                nameof(ScrollY),
                typeof(double),
                typeof(ScrollViewScrollBehavior),
                default(double),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the vertical scroll value in pixels.
        /// </summary>
        public double ScrollY
        {
            get { return (double)GetValue(ScrollYProperty); }
            set { SetValue(ScrollYProperty, value); }
        }

        /// <summary>
        /// Bindable property for the horizontal scroll value between 0 and 1.
        /// </summary>
        public static readonly BindableProperty RelativeScrollXProperty =
            BindableProperty.Create(
                nameof(RelativeScrollX),
                typeof(double),
                typeof(ScrollViewScrollBehavior),
                default(double),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the horizontal scroll value as a relative value between 0 and 1.
        /// </summary>
        public double RelativeScrollX
        {
            get { return (double)GetValue(RelativeScrollXProperty); }
            set { SetValue(RelativeScrollXProperty, value); }
        }

        /// <summary>
        /// Bindable property for the vertical scroll value between 0 and 1.
        /// </summary>
        public static readonly BindableProperty RelativeScrollYProperty =
            BindableProperty.Create(
                nameof(RelativeScrollY),
                typeof(double),
                typeof(ScrollViewScrollBehavior),
                default(double),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the vertical scroll value as a relative value between 0 and 1.
        /// </summary>
        public double RelativeScrollY
        {
            get { return (double)GetValue(RelativeScrollYProperty); }
            set { SetValue(RelativeScrollYProperty, value); }
        }

        /// <summary>
        /// Bindable property for the horizontal scroll value as a percentage (0% to 100%).
        /// </summary>
        public static readonly BindableProperty PercentageScrollXProperty =
            BindableProperty.Create(
                nameof(PercentageScrollX),
                typeof(double),
                typeof(ScrollViewScrollBehavior),
                default(double),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the horizontal scroll value as a percentage (0% to 100%).
        /// </summary>
        public double PercentageScrollX
        {
            get { return (double)GetValue(PercentageScrollXProperty); }
            set { SetValue(PercentageScrollXProperty, value); }
        }

        /// <summary>
        /// Bindable property for the vertical scroll value as a percentage (0% to 100%).
        /// </summary>
        public static readonly BindableProperty PercentageScrollYProperty =
            BindableProperty.Create(
                nameof(PercentageScrollY),
                typeof(double),
                typeof(ScrollViewScrollBehavior),
                default(double),
                BindingMode.TwoWay,
                null);

        /// <summary>
        /// Gets or sets the vertical scroll value as a percentage (0% to 100%).
        /// </summary>
        public double PercentageScrollY
        {
            get { return (double)GetValue(PercentageScrollYProperty); }
            set { SetValue(PercentageScrollYProperty, value); }
        }

        /// <summary>
        /// Called when the behavior is attached to a <see cref="ScrollView"/>.
        /// Subscribes to the scroll event of the associated ScrollView.
        /// </summary>
        /// <param name="bindable">The ScrollView to which the behavior is attached.</param>
        protected override void OnAttachedTo(ScrollView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Scrolled += new EventHandler<ScrolledEventArgs>(OnScrolled);
        }

        /// <summary>
        /// Called when the behavior is detached from a <see cref="ScrollView"/>.
        /// Unsubscribes from the scroll event of the associated ScrollView.
        /// </summary>
        /// <param name="bindable">The ScrollView from which the behavior is detached.</param>
        protected override void OnDetachingFrom(ScrollView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Scrolled -= new EventHandler<ScrolledEventArgs>(OnScrolled);
        }

        /// <summary>
        /// Handles the scroll event to update scroll values, including relative and percentage-based values.
        /// </summary>
        /// <param name="sender">The source of the scroll event.</param>
        /// <param name="e">The scroll event arguments containing scroll position data.</param>
        private void OnScrolled(object sender, ScrolledEventArgs e)
        {
            ScrollY = e.ScrollY;
            ScrollX = e.ScrollX;

            ScrollView scrollView = (ScrollView)sender;
            Size contentSize = scrollView.ContentSize;

            var viewportHeight = contentSize.Height - scrollView.Height;
            var viewportWidth = contentSize.Width - scrollView.Width;

            RelativeScrollY = viewportHeight <= 0 ? 0 : e.ScrollY / viewportHeight;
            RelativeScrollX = viewportWidth <= 0 ? 0 : e.ScrollX / viewportWidth;

            PercentageScrollX = RelativeScrollX * 100;
            PercentageScrollY = RelativeScrollY * 100;
        }
    }
}
