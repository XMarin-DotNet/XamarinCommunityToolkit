using System;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms.Toolkit.Effects;

[assembly: ExportEffect(typeof(SearchBarSuggestionPlatform), nameof(SearchBarSuggestionEffect))]
namespace Xamarin.Forms.Toolkit.Effects
{
    class SearchBarSuggestionPlatform : PlatformEffect
    {
        protected override void OnAttached()
        {
            var autoSuggestBox = Control as AutoSuggestBox;
            if (autoSuggestBox != null)
            {
                autoSuggestBox.SuggestionChosen += OnSuggestionChosen;
                autoSuggestBox.TextChanged += OnTextChangedEffect;
                autoSuggestBox.AutoMaximizeSuggestionArea = true;
                autoSuggestBox.ItemsSource = SearchBarSuggestion.GetSuggestions(Element);
            }
        }

        protected override void OnDetached()
        {
            var autoSuggestBox = Control as AutoSuggestBox;
            autoSuggestBox.SuggestionChosen -= OnSuggestionChosen;
            autoSuggestBox.TextChanged -= OnTextChangedEffect;
        }

        void OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            ((IElementController)Element).SetValueFromRenderer(SearchBar.TextProperty, sender.Text);
        }

        void OnTextChangedEffect(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            var platformSpecificAction = (Action)Element.GetValue(SearchBarSuggestion.TextChangedActionProperty);
            platformSpecificAction?.Invoke();
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            if (args.PropertyName == SearchBarSuggestion.SuggestionsProperty.PropertyName)
                UpdateItemsSource();
        }

        void UpdateItemsSource()
        {
            ((AutoSuggestBox)Control).ItemsSource = SearchBarSuggestion.GetSuggestions(Element);
        }
    }
}
