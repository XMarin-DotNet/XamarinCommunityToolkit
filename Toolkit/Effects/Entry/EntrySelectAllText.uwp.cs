using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(EntrySelectAllTextPlatform), nameof(EntrySelectAllText))]
namespace Xamarin.Forms.Toolkit.Effects
{
    [Preserve]
    class EntrySelectAllTextPlatform : PlatformEffect
    {
        protected override void OnAttached()
        {
            var textBox = Control as TextBox;
            if (textBox == null)
                return;

            textBox.GotFocus -= TextboxOnGotFocus;
            textBox.GotFocus += TextboxOnGotFocus;
        }

        void TextboxOnGotFocus(object sender, RoutedEventArgs e) =>
            ((TextBox)sender).SelectAll();

        protected override void OnDetached()
        {
            var textbox = Control as TextBox;
            if (textbox == null)
                return;

            textbox.GotFocus -= TextboxOnGotFocus;
        }
    }
}
