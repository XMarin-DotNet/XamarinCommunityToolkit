using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(PickerChangeColorPlatform), nameof(PickerChangeColorEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    [Preserve]
    class PickerChangeColorPlatform : PlatformEffect
    {
        Windows.UI.Color color;

        protected override void OnAttached()
        {
            if (!(Control is ComboBox comboBox))
                return;

            var color = (Color)Element.GetValue(PickerChangeColor.ColorProperty);
            this.color = ConvertColor(color);
            comboBox.Foreground = new SolidColorBrush(this.color);
        }

        protected override void OnDetached()
        {
        }

        Windows.UI.Color ConvertColor(Color color) =>
            Windows.UI.Color.FromArgb((byte)(color.A * 255), (byte)(color.R * 255), (byte)(color.G * 255), (byte)(color.B * 255));
    }
}
