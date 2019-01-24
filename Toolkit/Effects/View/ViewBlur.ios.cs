﻿using System;
using System.ComponentModel;
using System.Drawing;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(ViewBlurPlatform), nameof(ViewBlurEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    class ViewBlurPlatform : PlatformEffect
    {
        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            var visualElement = Element as VisualElement;

            if (visualElement == null)
                return;

            if (args.PropertyName == nameof(visualElement.Width) || args.PropertyName == nameof(visualElement.Height))
            {
                var blurAmount = (double)Element.GetValue(ViewBlur.BlurAmountProperty);

                var blur = UIBlurEffect.FromStyle(UIBlurEffectStyle.Light);

                var blurView = new UIVisualEffectView(blur)
                {
                    Alpha = (nfloat)blurAmount,
                    Frame = new RectangleF(0, 0, (float)((VisualElement)Element).Width, (float)((VisualElement)Element).Height)
                };

                Control.Add(blurView);
            }
        }

        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }
    }
}
