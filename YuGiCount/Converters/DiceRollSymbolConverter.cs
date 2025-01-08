using System;
using System.Globalization;

namespace YuGiCount.Converters;

public class DiceRollSymbolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        value switch
        {
            true => "🎲✅",  // Win
            false => "🎲❌", // Loss
            _ => "🎲"       // Undefined
        };

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}
