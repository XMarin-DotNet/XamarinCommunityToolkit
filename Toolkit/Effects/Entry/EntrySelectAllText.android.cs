﻿using Android.Runtime;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using PlatformEffects = Xamarin.Forms.Toolkit.Effects.Droid;
using RoutingEffects = Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(PlatformEffects.EntrySelectAllText), nameof(RoutingEffects.EntrySelectAllText))]

namespace Xamarin.Forms.Toolkit.Effects.Droid
{
    [Preserve(AllMembers = true)]
    public class EntrySelectAllText : PlatformEffect
    {
        protected override void OnAttached()
        {
            var editText = Control as EditText;
            if (editText == null)
                return;

            editText.SetSelectAllOnFocus(true);
        }

        protected override void OnDetached()
        {
            var editText = Control as EditText;
            if (editText == null)
                return;

            editText.SetSelectAllOnFocus(false);
        }
    }
}
