using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(LabelMultiLinePlatform), nameof(LabelMultiLine))]
namespace Xamarin.Forms.Toolkit.Effects
{
    class LabelMultiLinePlatform : PlatformEffect
    {
        int initialeLines;
        TextWrapping initialTextWrapping;

        protected override void OnAttached()
        {
            var control = Control as TextBlock;

            if (control == null)
            {
                return;
            }

            initialeLines = control.MaxLines;
            initialTextWrapping = control.TextWrapping;

            var effect = (LabelMultiLine)Element.Effects.FirstOrDefault(item => item is LabelMultiLine);
            if (effect != null && effect.Lines > 0)
            {
                control.MaxLines = effect.Lines;
                control.TextWrapping = TextWrapping.WrapWholeWords;
            }
        }

        protected override void OnDetached()
        {
            var control = Control as TextBlock;

            if (control == null)
                return;

            control.MaxLines = initialeLines;
            control.TextWrapping = initialTextWrapping;
        }
    }
}
