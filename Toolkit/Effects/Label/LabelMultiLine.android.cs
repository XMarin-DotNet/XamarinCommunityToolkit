using System.Linq;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(LabelMultilinePlatform), nameof(LabelMultilineEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    class LabelMultilinePlatform : PlatformEffect
    {
        protected override void OnAttached()
        {
            var control = Control as TextView;

            if (control == null)
                return;

            var effect = (LabelMultilineEffect)Element.Effects.FirstOrDefault(item => item is LabelMultilineEffect);
            if (effect != null && effect.Lines > 0)
            {
                control.SetSingleLine(false);
                control.SetLines(effect.Lines);
            }
        }

        protected override void OnDetached()
        {
            // TODO: Glenn - Reset to old amount of Lines and old SingleLine value
        }
    }
}
