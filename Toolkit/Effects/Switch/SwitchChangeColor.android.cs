using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AndroidSwitch = Android.Widget.Switch;
using FormsColor = Xamarin.Forms.Color;
using FormsSwitch = Xamarin.Forms.Switch;
using PlatformEffects = Xamarin.Forms.Toolkit.Effects.Droid;
using RoutingEffects = Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(PlatformEffects.SwitchChangeColor), nameof(RoutingEffects.SwitchChangeColorEffect))]
namespace Xamarin.Forms.Toolkit.Effects.Droid
{
    [Preserve(AllMembers = true)]
    public class SwitchChangeColor : PlatformEffect
    {
        FormsColor trueColor;
        FormsColor falseColor;

        protected override void OnAttached()
        {
            if (Platform.HasApiLevel(BuildVersionCodes.JellyBean))
            {
                trueColor = (FormsColor)Element.GetValue(RoutingEffects.SwitchChangeColor.TrueColorProperty);
                falseColor = (FormsColor)Element.GetValue(RoutingEffects.SwitchChangeColor.FalseColorProperty);

                ((SwitchCompat)Control).CheckedChange += OnCheckedChange;

                var isChecked = ((SwitchCompat)Control).Checked;
                var startingColor = isChecked ? trueColor : falseColor;
                ((SwitchCompat)Control).ThumbDrawable.SetColorFilter(startingColor.ToAndroid(), PorterDuff.Mode.Multiply);
            }
        }

        void OnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs checkedChangeEventArgs)
        {
            if (checkedChangeEventArgs.IsChecked)
            {
                ((SwitchCompat)Control).ThumbDrawable.SetColorFilter(trueColor.ToAndroid(), PorterDuff.Mode.Multiply);
            }
            else
            {
                ((SwitchCompat)Control).ThumbDrawable.SetColorFilter(falseColor.ToAndroid(), PorterDuff.Mode.Multiply);
            }

            ((FormsSwitch)Element).IsToggled = checkedChangeEventArgs.IsChecked;
        }

        protected override void OnDetached()
        {
            if (Platform.HasApiLevel(BuildVersionCodes.JellyBean) && Build.VERSION.SdkInt < BuildVersionCodes.LollipopMr1)
            {
                ((AndroidSwitch)Control).CheckedChange -= OnCheckedChange;
            }
        }
    }
}
