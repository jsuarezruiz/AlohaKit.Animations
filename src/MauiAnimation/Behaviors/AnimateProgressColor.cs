namespace MauiAnimation
{
    public class AnimateProgressColor : AnimationProgressBaseBehavior
    {
        public static readonly BindableProperty FromProperty =
              BindableProperty.Create(nameof(From), typeof(Color), typeof(AnimationProgressBaseBehavior), default(Color),
                  BindingMode.TwoWay, null);

        public Color From
        {
            get { return (Color)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public static readonly BindableProperty ToProperty =
            BindableProperty.Create(nameof(To), typeof(Color), typeof(AnimationProgressBaseBehavior), default(Color),
                BindingMode.TwoWay, null);

        public Color To
        {
            get { return (Color)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        protected override void OnUpdate()
        {
            if (From == null && To == null)
                return;

            if (From == null)
            {
                Target.SetValue(TargetProperty, To);
                return;
            }
            if (To == null)
            {
                Target.SetValue(TargetProperty, From);
                return;
            }

            var newR = (To.Red - From.Red) * Progress;
            var newG = (To.Green - From.Green) * Progress;
            var newB = (To.Blue - From.Blue) * Progress;
            Color value = Color.FromRgb((int)(From.Red + newR), (int)(From.Green + newG), (int)(From.Blue + newB));

            Target.SetValue(TargetProperty, value);
        }
    }
}