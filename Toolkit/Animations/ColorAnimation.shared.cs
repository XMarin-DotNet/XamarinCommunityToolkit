﻿using System;
using System.Threading.Tasks;

namespace Xamarin.Forms.Toolkit.Animations
{
    public class ColorAnimation : AnimationBase
    {
        public static readonly BindableProperty ToColorProperty =
            BindableProperty.Create(nameof(ToColor), typeof(Color), typeof(ColorAnimation), Color.Default, BindingMode.TwoWay, null);

        public Color ToColor
        {
            get => (Color)GetValue(ToColorProperty);
            set => SetValue(ToColorProperty, value);
        }

        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            var fromColor = Target.BackgroundColor;

            return Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Target.ColorTo(fromColor, ToColor, c => Target.BackgroundColor = c, Convert.ToUInt32(Duration));
                });
            });
        }
    }
}
