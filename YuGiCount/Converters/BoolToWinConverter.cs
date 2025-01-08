using System;
using System.Globalization;

namespace YuGiCount.Converters;

public class BoolToWinConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is true;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is true ? true : (object?)null;
}
