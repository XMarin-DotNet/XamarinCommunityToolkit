using System.Linq;

namespace Xamarin.Forms.Toolkit.Effects
{
    public static class LabelMultiline
    {
        public static readonly BindableProperty LinesProperty = 
            BindableProperty.CreateAttached("Lines", typeof(int), typeof(LabelMultiline), Color.Transparent, propertyChanged: OnColorChanged);
  
        static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as Label;
            if (control == null)
                return;

            var color = (int)newValue;

            var attachedEffect = control.Effects.FirstOrDefault(e => e is LabelMultilineEffect);
            if (attachedEffect == null)
                control.Effects.Add(new LabelMultilineEffect());
            else
                control.Effects.Remove(attachedEffect);
        }

        public static int GetLines(BindableObject view) =>
            (int)view.GetValue(LinesProperty);

        public static void SetLines(BindableObject view, string lines) =>
            view.SetValue(LinesProperty, lines);
    }

    public class LabelMultilineEffect : RoutingEffect
    {
        public LabelMultilineEffect()
            : base(Ids.LabelMultiline)
        {
        }
    }
}
