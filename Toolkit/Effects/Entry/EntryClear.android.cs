using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using PlatformEffects = Xamarin.Forms.Toolkit.Effects.Droid;
using RoutingEffects = Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(PlatformEffects.EntryClear), nameof(RoutingEffects.EntryClear))]
namespace Xamarin.Forms.Toolkit.Effects.Droid
{
    [Preserve(AllMembers = true)]
    public class EntryClear : PlatformEffect
    {
        public static int DrawableId { get; set; } = -1;

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

            var id = DrawableId != -1 ? DrawableId : global::Android.Resource.Drawable.IcMenuCloseClearCancel;
            editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, id, 0);
            editText.SetOnTouchListener(new OnDrawableTouchListener());
        }
    }

    class OnDrawableTouchListener : Java.Lang.Object, global::Android.Views.View.IOnTouchListener
    {
        public bool OnTouch(global::Android.Views.View v, MotionEvent e)
        {
            if (v is EditText && e.Action == MotionEventActions.Up)
            {
                var editText = (EditText)v;
                if (e.RawX >= (editText.Right - editText.GetCompoundDrawables()[2].Bounds.Width()))
                {
                    editText.Text = string.Empty;
                    return true;
                }
            }

            return false;
        }
    }
}
