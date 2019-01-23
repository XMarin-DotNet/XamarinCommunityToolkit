using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using PlatformEffects = Xamarin.Forms.Toolkit.Effects.iOS;
using RoutingEffects = Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(PlatformEffects.SwitchChangeColor), nameof(RoutingEffects.SwitchChangeColorEffect))]
namespace Xamarin.Forms.Toolkit.Effects.iOS
{
    public class SwitchChangeColor : PlatformEffect
    {
        Color trueColor;
        Color falseColor;

        protected override void OnAttached()
        {
            var uiSwitch = Control as UISwitch;
            if (uiSwitch == null)
                return;

            trueColor = (Color)Element.GetValue(RoutingEffects.SwitchChangeColor.TrueColorProperty);
            falseColor = (Color)Element.GetValue(RoutingEffects.SwitchChangeColor.FalseColorProperty);

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
