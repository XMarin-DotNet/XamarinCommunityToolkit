namespace Xamarin.Forms.Toolkit.Behaviors
{
    public class NumericValidationBehavior : BaseBehavior<Entry>
    {
        bool colorSet;
        Color color = Color.Default;

        internal static readonly BindablePropertyKey TextColorInvalidKey =
            BindableProperty.CreateReadOnly(nameof(TextColorInvalid), typeof(Color), typeof(EntryEmailValidation), Color.Default);

        public static readonly BindableProperty TextColorInvalidProperty =
            TextColorInvalidKey.BindableProperty;

        public Color TextColorInvalid
        {
            get => (Color)GetValue(TextColorInvalidProperty);
            set => SetValue(TextColorInvalidKey, value);
        }

        internal static readonly BindablePropertyKey IsValidPropertyKey =
            BindableProperty.CreateReadOnly(nameof(IsValid), typeof(bool), typeof(EntryEmptyValidation), false);

        public static readonly BindableProperty IsValidProperty =
            IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            private set => SetValue(IsValidPropertyKey, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            HandleTextChanged(bindable, new TextChangedEventArgs(string.Empty, bindable.Text));
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var text = e?.NewTextValue ?? string.Empty;

            IsValid = double.TryParse(text, out var result);

            var entry = sender as Entry;

            if (entry == null)
                return;

            if (!colorSet)
            {
                colorSet = true;
                color = entry.TextColor;
            }

            entry.TextColor = IsValid ? color : TextColorInvalid;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
        }
    }
}
