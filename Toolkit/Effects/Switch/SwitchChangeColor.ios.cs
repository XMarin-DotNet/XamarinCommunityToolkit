using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(SwitchChangeColorPlatform), nameof(SwitchChangeColorEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    class SwitchChangeColorPlatform : PlatformEffect
    {
        Color trueColor;
        Color falseColor;

        protected override void OnAttached()
        {
            var uiSwitch = Control as UISwitch;
            if (uiSwitch == null)
                return;

            trueColor = (Color)Element.GetValue(SwitchChangeColor.TrueColorProperty);
            falseColor = (Color)Element.GetValue(SwitchChangeColor.FalseColorProperty);

            if (falseColor != Color.Transparent)
            {
                uiSwitch.TintColor = falseColor.ToUIColor();
                uiSwitch.Layer.CornerRadius = 16;
                uiSwitch.BackgroundColor = falseColor.ToUIColor();
            }

            if (trueColor != Color.Transparent)
                uiSwitch.OnTintColor = trueColor.ToUIColor();
        }

        protected override void OnDetached()
        {
        }
    }
}
