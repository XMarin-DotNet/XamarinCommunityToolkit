using System;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(LabelMultiLinePlatform), nameof(LabelMultiLine))]
namespace Xamarin.Forms.Toolkit.Effects
{
    class LabelMultiLinePlatform : PlatformEffect
    {
        nint initialeLines;

        protected override void OnAttached()
        {
            var control = Control as UILabel;

            if (control == null)
                return;

            initialeLines = control.Lines;

            var effect = (LabelMultiLine)Element.Effects.FirstOrDefault(item => item is LabelMultiLine);
            if (effect != null && effect.Lines > 0)
                control.Lines = effect.Lines;
        }

        protected override void OnDetached()
        {
            var control = Control as UILabel;

            if (control == null)
                return;

            control.Lines = initialeLines;
        }
    }
}
