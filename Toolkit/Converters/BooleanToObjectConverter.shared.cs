using System;
using System.Globalization;

namespace Xamarin.Forms.Toolkit.Converters
{
    public class BooleanToObjectConverter<T> : IValueConverter
    {
        public static BooleanToObjectConverter<T> Instance { get; } = new BooleanToObjectConverter<T>();

        public static void Init()
        {
            var time = DateTime.UtcNow;
        }

        public T FalseObject { get; set; }

        public T TrueObject { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            (bool)value ? TrueObject : FalseObject;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            ((T)value).Equals(TrueObject);
    }
}
