using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Toolkit.Effects;
using AndroidSwitch = Android.Widget.Switch;
using FormsColor = Xamarin.Forms.Color;
using FormsSwitch = Xamarin.Forms.Switch;

[assembly: ExportEffect(typeof(SwitchChangeColorPlatform), nameof(SwitchChangeColorEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    [Preserve(AllMembers = true)]
    class SwitchChangeColorPlatform : PlatformEffect
    {
        FormsColor trueColor;
        FormsColor falseColor;

        protected override void OnAttached()
        {
            if (Platform.HasApiLevel(BuildVersionCodes.JellyBean))
            {
                trueColor = (FormsColor)Element.GetValue(SwitchChangeColor.TrueColorProperty);
                falseColor = (FormsColor)Element.GetValue(SwitchChangeColor.FalseColorProperty);

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
