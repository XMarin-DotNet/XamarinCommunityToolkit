namespace Xamarin.Forms.Toolkit.Effects
{
    public class EntryClearEffect : RoutingEffect
    {
#if __ANDROID__
        public static int DrawableId { get; set; } = -1;
#endif

        public EntryClearEffect()
            : base(Ids.EntryClear)
        {
        }
    }
}
