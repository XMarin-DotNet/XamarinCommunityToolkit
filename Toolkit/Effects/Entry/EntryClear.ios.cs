using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using PlatformEffects = Xamarin.Forms.Toolkit.Effects.iOS;
using RoutingEffects = Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(PlatformEffects.EntryClear), nameof(RoutingEffects.EntryClear))]
namespace Xamarin.Forms.Toolkit.Effects.iOS
{
    [Preserve(AllMembers = true)]
    public class EntryClear : PlatformEffect
    {
        UITextFieldViewMode old;

        protected override void OnAttached()
        {
            ConfigureControl();
        }

        protected override void OnDetached()
        {
            var editText = Control as UITextField;
            if (editText == null)
                return;

            editText.ClearButtonMode = old;
        }

        void ConfigureControl()
        {
            var editText = Control as UITextField;
            if (editText == null)
                return;

            old = editText.ClearButtonMode;
            editText.ClearButtonMode = UITextFieldViewMode.WhileEditing;
        }
    }
}
