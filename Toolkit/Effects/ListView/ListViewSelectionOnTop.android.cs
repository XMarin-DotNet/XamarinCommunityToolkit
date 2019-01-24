using System;
using System.Diagnostics;
using Android.Runtime;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(ListViewSelectionOnTopPlatform), nameof(ListViewSelectionOnTop))]
namespace Xamarin.Forms.Toolkit.Effects
{
    [Preserve(AllMembers = true)]
    class ListViewSelectionOnTopPlatform : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                if (!(Control is AbsListView listView))
                    return;

                listView.SetDrawSelectorOnTop(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
