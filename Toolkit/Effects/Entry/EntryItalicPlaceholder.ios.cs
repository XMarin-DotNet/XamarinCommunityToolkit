using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(EntryItalicPlaceholderPlatform), nameof(EntryItalicPlaceholderEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    [Preserve(AllMembers = true)]
    class EntryItalicPlaceholderPlatform : PlatformEffect
    {
        NSAttributedString old;

        protected override void OnAttached()
        {
            var entry = Control as UITextField;
            if (entry == null || string.IsNullOrWhiteSpace(entry.Placeholder))
                return;

            old = entry.AttributedPlaceholder;
            var entryFontSize = entry.Font.PointSize;
            entry.AttributedPlaceholder = new NSAttributedString(entry.Placeholder, font: UIFont.ItalicSystemFontOfSize(entryFontSize));
        }

        protected override void OnDetached()
        {
            var entry = Control as UITextField;
            if (entry == null)
                return;

            entry.AttributedPlaceholder = old;
        }
    }
}
