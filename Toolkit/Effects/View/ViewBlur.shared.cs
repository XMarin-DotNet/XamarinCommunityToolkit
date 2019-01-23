﻿using System.Linq;

namespace Xamarin.Forms.Toolkit.Effects
{
    public static class ViewBlur
    {
        public static readonly BindableProperty BlurAmountProperty = BindableProperty.CreateAttached("BlurAmount", typeof(double), typeof(ViewBlur), 0.0, propertyChanged: OnBlurAmountChanged);

        static void OnBlurAmountChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
                return;

            var blurAmount = (double)newValue;
            var attachedEffect = view.Effects.FirstOrDefault(e => e is ViewBlurEffect);
            if (blurAmount > 0 && attachedEffect == null)
            {
                view.Effects.Add(new ViewBlurEffect());
            }
            else if (blurAmount == 0 && attachedEffect != null)
            {
                view.Effects.Remove(attachedEffect);
            }
        }

        public static double GetBlurAmount(BindableObject view) =>
            (double)view.GetValue(BlurAmountProperty);

        public static void SetBlurAmount(BindableObject view, double amount) =>
            view.SetValue(BlurAmountProperty, amount);
    }

    public class ViewBlurEffect : RoutingEffect
    {
        public ViewBlurEffect()
            : base(EffectIds.ViewBlur)
        {
        }
    }
}
