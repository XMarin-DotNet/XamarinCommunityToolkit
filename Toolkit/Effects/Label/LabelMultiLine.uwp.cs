﻿using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using PlatformEffects = Xamarin.Forms.Toolkit.Effects.UWP;
using RoutingEffects = Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(PlatformEffects.LabelMultiLine), nameof(RoutingEffects.LabelMultiLine))]
namespace Xamarin.Forms.Toolkit.Effects.UWP
{
    public class LabelMultiLine : PlatformEffect
    {
        int initialeLines;
        TextWrapping initialTextWrapping;

        protected override void OnAttached()
        {
            var control = Control as TextBlock;

            if (control == null)
            {
                return;
            }

            initialeLines = control.MaxLines;
            initialTextWrapping = control.TextWrapping;

            var effect = (RoutingEffects.LabelMultiLine)Element.Effects.FirstOrDefault(item => item is RoutingEffects.LabelMultiLine);
            if (effect != null && effect.Lines > 0)
            {
                control.MaxLines = effect.Lines;
                control.TextWrapping = TextWrapping.WrapWholeWords;
            }
        }

        protected override void OnDetached()
        {
            var control = Control as TextBlock;

            if (control == null)
                return;

            control.MaxLines = initialeLines;
            control.TextWrapping = initialTextWrapping;
        }
    }
}
