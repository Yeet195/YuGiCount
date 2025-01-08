using System;
using System.Globalization;

namespace YuGiCount.Converters;

public class BoolToLossConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is false;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is true ? false : (object?)null;
}
