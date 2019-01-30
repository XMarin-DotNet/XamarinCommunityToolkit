namespace Xamarin.Forms.Toolkit.Effects
{
    public class LabelCustomFontEffect : RoutingEffect
    {
        public string FontPath { get; set; }

        public string FontFamilyName { get; set; }

        public LabelCustomFontEffect()
            : base(Ids.LabelCustomFont)
        {
        }
    }
}
