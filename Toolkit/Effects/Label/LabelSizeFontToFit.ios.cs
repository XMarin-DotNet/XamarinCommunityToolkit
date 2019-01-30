using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(LabelSizeFontToFitPlatform), nameof(LabelSizeFontToFitEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    [Preserve(AllMembers = true)]
    class LabelSizeFontToFitPlatform : PlatformEffect
    {
        protected override void OnAttached()
        {
            var label = Control as UILabel;
            if (label == null)
                return;

            label.AdjustsFontSizeToFitWidth = true;
            label.Lines = 1;
            label.BaselineAdjustment = UIBaselineAdjustment.AlignCenters;
            label.LineBreakMode = UILineBreakMode.Clip;
        }

        protected override void OnDetached()
        {
        }
    }
}
