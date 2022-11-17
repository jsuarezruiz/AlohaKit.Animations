namespace AlohaKit.Animations.Sample
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            AnimationExtensionButton.Clicked += async (sender, args) =>
            {
                await AnimationBox.Animate(new HeartAnimation());
            };
        }
    }
}