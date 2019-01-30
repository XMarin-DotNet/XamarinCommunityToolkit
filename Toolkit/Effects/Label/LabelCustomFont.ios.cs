using System.ComponentModel;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(LabelCustomFontPlatform), nameof(LabelCustomFontEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    class LabelCustomFontPlatform : PlatformEffect
    {
        LabelCustomFontEffect effect;

        protected override void OnAttached()
        {
            var control = Control as UILabel;

            if (control == null)
                return;

            effect = (LabelCustomFontEffect)Element.Effects.FirstOrDefault(item => item is LabelCustomFontEffect);
            if (effect != null && !string.IsNullOrWhiteSpace(effect.FontPath))
                control.Font = UIFont.FromName(effect.FontFamilyName, control.Font.PointSize);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            // After one of these properties change, reapply the custom font
            // As per https://bugzilla.xamarin.com/show_bug.cgi?id=33666

            var control = Control as UILabel;

            if (control == null)
                return;

            if (args.PropertyName == Label.TextColorProperty.PropertyName
                   || args.PropertyName == Label.FontProperty.PropertyName
                   || args.PropertyName == Label.TextProperty.PropertyName
                   || args.PropertyName == Label.FormattedTextProperty.PropertyName)
            {
                control.Font = UIFont.FromName(effect.FontFamilyName, control.Font.PointSize);
            }

            base.OnElementPropertyChanged(args);
        }

        protected override void OnDetached()
        {
        }
    }
}
