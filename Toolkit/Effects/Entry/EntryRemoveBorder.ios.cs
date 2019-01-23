using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using PlatformEffects = Xamarin.Forms.Toolkit.Effects.iOS;
using RoutingEffects = Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(PlatformEffects.EntryRemoveBorder), nameof(RoutingEffects.EntryRemoveBorder))]
namespace Xamarin.Forms.Toolkit.Effects.iOS
{
    [Preserve(AllMembers = true)]
    public class EntryRemoveBorder : PlatformEffect
    {
        UITextBorderStyle old;

        protected override void OnAttached()
        {
            var editText = Control as UITextField;
            if (editText == null)
                return;

            old = editText.BorderStyle;
            editText.BorderStyle = UITextBorderStyle.None;
        }

        protected override void OnDetached()
        {
            var editText = Control as UITextField;
            if (editText == null)
                return;

            editText.BorderStyle = old;
        }
    }
}
