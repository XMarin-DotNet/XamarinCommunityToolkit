namespace Xamarin.Forms.Toolkit.Effects
{
    public class EntryClear : RoutingEffect
    {
#if __ANDROID__
        public static int DrawableId { get; set; } = -1;
#endif

        public EntryClear()
            : base(Ids.EntryClear)
        {
        }
    }
}
