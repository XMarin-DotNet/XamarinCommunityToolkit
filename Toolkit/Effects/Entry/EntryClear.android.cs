using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(EntryClearPlatform), nameof(EntryClear))]
namespace Xamarin.Forms.Toolkit.Effects
{
    [Preserve(AllMembers = true)]
    class EntryClearPlatform : PlatformEffect
    {
        protected override void OnAttached()
        {
            ConfigureControl();
        }

        protected override void OnDetached()
        {
            var editText = Control as EditText;

            editText?.SetOnTouchListener(null);
            editText?.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, 0, 0);
        }

        void ConfigureControl()
        {
            if (!(Control is EditText editText))
                return;

            var id = EntryClear.DrawableId != -1 ? EntryClear.DrawableId : global::Android.Resource.Drawable.IcMenuCloseClearCancel;
            editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, id, 0);
            editText.SetOnTouchListener(new OnDrawableTouchListener());
        }
    }

    class OnDrawableTouchListener : Java.Lang.Object, global::Android.Views.View.IOnTouchListener
    {
        public bool OnTouch(global::Android.Views.View v, MotionEvent e)
        {
            if (e.Action != MotionEventActions.Up)
                return false;

            if (!(v is EditText editText))
                return false;

            if (e.RawX >= (editText.Right - editText.GetCompoundDrawables()[2].Bounds.Width()))
            {
                editText.Text = string.Empty;
                return true;
            }

            return false;
        }
    }
}
