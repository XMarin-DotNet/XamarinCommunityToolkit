using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Xamarin.Forms.Toolkit.Converters
{
    [ValueConversion(typeof(IEnumerator<IValueConverter>), typeof(IEnumerator<IValueConverter>))]
    public class ValueConverterGroup : List<IValueConverter>, IValueConverter
    {
        public static ValueConverterGroup Instance { get; } = new ValueConverterGroup();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            this.Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, culture));

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
