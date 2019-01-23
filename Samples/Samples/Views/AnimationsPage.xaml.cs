using Xamarin.Forms;
using Xamarin.Forms.Toolkit.Animations;

namespace Xamarin.Samples.Views
{
    public partial class AnimationsPage : CarouselPage
    {
        public AnimationsPage()
        {
            InitializeComponent();

            AnimationExtensionButton.Clicked += async (sender, args) =>
            {
                await AnimationBox.Animate(new HeartAnimation());
            };

            Title = CurrentPage?.Title ?? string.Empty;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage.Title;
        }
    }
}
