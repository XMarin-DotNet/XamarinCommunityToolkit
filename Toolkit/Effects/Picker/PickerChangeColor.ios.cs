using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.Toolkit.Effects;
using FormsColor = Xamarin.Forms.Color;

[assembly: ExportEffect(typeof(PickerChangeColorPlatform), nameof(PickerChangeColorEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    class PickerChangeColorPlatform : PlatformEffect
    {
        FormsColor color;

        protected override void OnAttached()
        {
            if (!(Control is UITextField control))
                return;

            color = (FormsColor)Element.GetValue(PickerChangeColor.ColorProperty);
            control.AttributedPlaceholder = new Foundation.NSAttributedString(control.AttributedPlaceholder.Value, foregroundColor: color.ToUIColor());
        }

        protected override void OnDetached()
        {
        }
    }
}
