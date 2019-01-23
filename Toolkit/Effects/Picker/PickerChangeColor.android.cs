using Android.Runtime;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AndroidPicker = Android.Widget.EditText;
using FormsColor = Xamarin.Forms.Color;
using PlatformEffects = Xamarin.Forms.Toolkit.Effects.Droid;
using RoutingEffects = Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(PlatformEffects.PickerChangeColor), nameof(RoutingEffects.PickerChangeColorEffect))]
namespace Xamarin.Forms.Toolkit.Effects.Droid
{
    [Preserve(AllMembers = true)]
    public class PickerChangeColor : PlatformEffect
    {
        FormsColor color;

        protected override void OnAttached()
        {
            color = (FormsColor)Element.GetValue(RoutingEffects.PickerChangeColor.ColorProperty);
            ((AndroidPicker)Control).SetHintTextColor(color.ToAndroid());
        }

        protected override void OnDetached()
        {
        }
    }
}
