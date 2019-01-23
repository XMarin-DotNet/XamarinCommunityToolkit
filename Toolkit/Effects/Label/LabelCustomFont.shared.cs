namespace Xamarin.Forms.Toolkit.Effects
{
    public class LabelCustomFont : RoutingEffect
    {
        public string FontPath { get; set; }

        public string FontFamilyName { get; set; }

        public LabelCustomFont()
            : base(EffectIds.LabelCustomFont)
        {
        }
    }
}
