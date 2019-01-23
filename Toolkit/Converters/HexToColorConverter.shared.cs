using System;
using System.Globalization;

namespace Xamarin.Forms.Toolkit.Converters
{
    [ValueConversion(typeof(string), typeof(Color))]
    public class HexToColorConverter : IValueConverter
    {
        public static HexToColorConverter Instance { get; } = new HexToColorConverter();

        public static void Init()
        {
            var time = DateTime.UtcNow;
        }

        public Color DefaultColor { get; set; } = Color.FromHex("#3498db");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = value as string;
            try
            {
                return string.IsNullOrEmpty(color) ? DefaultColor : Color.FromHex(color);
            }
            catch
            {
                return DefaultColor;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            null;
    }
}
