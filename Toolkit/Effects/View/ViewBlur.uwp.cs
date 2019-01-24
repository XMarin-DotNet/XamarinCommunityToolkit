﻿using System.ComponentModel;
using System.Numerics;
using Microsoft.Graphics.Canvas.Effects;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(ViewBlurPlatform), nameof(ViewBlurEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    class ViewBlurPlatform : PlatformEffect
    {
        SpriteVisual blurVisual;
        CompositionBrush blurBrush;
        Visual rootVisual;

        Compositor Compositor { get; set; }

        protected override void OnAttached()
        {
            var blurAmount = (double)Element.GetValue(ViewBlur.BlurAmountProperty);

            rootVisual = ElementCompositionPreview.GetElementVisual(Container);

            Compositor = rootVisual.Compositor;

            blurVisual = Compositor.CreateSpriteVisual();

            var brush = BuildBlurBrush();
            brush.SetSourceParameter("source", Compositor.CreateBackdropBrush());
            blurBrush = brush;
            blurVisual.Brush = blurBrush;

            ElementCompositionPreview.SetElementChildVisual(Container, blurVisual);

            Container.Loading += OnLoading;
            Container.Unloaded += OnUnloaded;

            blurBrush.Properties.InsertScalar("Blur.BlurAmount", (float)blurAmount);
            rootVisual.Properties.InsertScalar("BlurAmount", (float)blurAmount);

            SetUpPropertySetExpressions();
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == "BlurAmount")
            {
                var blurAmount = (double)Element.GetValue(ViewBlur.BlurAmountProperty);
                rootVisual.Properties.InsertScalar("BlurAmount", (float)blurAmount);
            }
        }

        void SetUpPropertySetExpressions()
        {
            var exprAnimation = Compositor.CreateExpressionAnimation();
            exprAnimation.Expression = "sourceProperties.BlurAmount";
            exprAnimation.SetReferenceParameter("sourceProperties", rootVisual.Properties);

            blurBrush.Properties.StartAnimation("Blur.BlurAmount", exprAnimation);
        }

        protected override void OnDetached() =>
            Container.SizeChanged -= OnSizeChanged;

        void OnLoading(FrameworkElement sender, object args)
        {
            Container.SizeChanged += OnSizeChanged;
            OnSizeChanged(this, null);
        }

        void OnUnloaded(object sender, RoutedEventArgs e)
        {
            if (Container == null)
                return;

            Container.SizeChanged -= OnSizeChanged;
        }

        void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (blurVisual == null)
                return;

            blurVisual.Size = new Vector2((float)Container.ActualWidth, (float)Container.ActualHeight);
        }

        CompositionEffectBrush BuildBlurBrush()
        {
            var blurEffect = new GaussianBlurEffect()
            {
                Name = "Blur",
                BlurAmount = 0.0f,
                BorderMode = EffectBorderMode.Hard,
                Optimization = EffectOptimization.Balanced,
                Source = new CompositionEffectSourceParameter("source"),
            };

            var factory = Compositor.CreateEffectFactory(
                blurEffect,
                new[] { "Blur.BlurAmount" });

            var brush = factory.CreateBrush();
            return brush;
        }
    }
}
