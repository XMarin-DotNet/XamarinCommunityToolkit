using System;
using Foundation;
using ObjCRuntime;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(EntrySelectAllTextPlatform), nameof(EntrySelectAllTextEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    [Preserve(AllMembers = true)]
    class EntrySelectAllTextPlatform : PlatformEffect
    {
        protected override void OnAttached()
        {
            var editText = Control as UITextField;
            if (editText == null)
                return;

            editText.EditingDidBegin += (object sender, EventArgs e) =>
            {
                editText.PerformSelector(new Selector("selectAll"), null, 0.0f);
            };
        }

        protected override void OnDetached()
        {
            var editText = Control as UITextField;
            if (editText == null)
                return;

            editText.EditingDidBegin -= (object sender, EventArgs e) =>
            {
                editText.PerformSelector(new Selector("selectAll"), null, 0.0f);
            };
        }
    }
}
