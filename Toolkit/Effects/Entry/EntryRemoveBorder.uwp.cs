using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(EntryRemoveBorderPlatform), nameof(EntryRemoveBorderEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    class EntryRemoveBorderPlatform : PlatformEffect
    {
        Windows.UI.Xaml.Thickness old;

        protected override void OnAttached()
        {
            var textBox = Control as TextBox;
            if (textBox == null)
                return;
            old = textBox.BorderThickness;
            textBox.BorderThickness = new Windows.UI.Xaml.Thickness(0);
        }

        protected override void OnDetached()
        {
            var textBox = Control as TextBox;
            if (textBox == null)
                return;

            textBox.BorderThickness = old;
        }
    }
}
