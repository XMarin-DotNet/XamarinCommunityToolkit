using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(LabelMultilinePlatform), nameof(LabelMultilineEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    class LabelMultilinePlatform : PlatformEffect
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

            var effect = (LabelMultilineEffect)Element.Effects.FirstOrDefault(item => item is LabelMultilineEffect);
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
