using Android.Runtime;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Toolkit.Effects;
using AndroidPicker = Android.Widget.EditText;
using FormsColor = Xamarin.Forms.Color;

[assembly: ExportEffect(typeof(PickerChangeColorPlatform), nameof(PickerChangeColorEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    [Preserve(AllMembers = true)]
    class PickerChangeColorPlatform : PlatformEffect
    {
        FormsColor color;

        protected override void OnAttached()
        {
            color = (FormsColor)Element.GetValue(PickerChangeColor.ColorProperty);
            ((AndroidPicker)Control).SetHintTextColor(color.ToAndroid());
        }

        protected override void OnDetached()
        {
        }
    }
}
