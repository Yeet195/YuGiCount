using System.Globalization;

namespace YuGiCount.Converters;

// Dice Symbol Converter
public class DiceRollSymbolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Console.WriteLine($"DiceRollSymbolConverter received value: {value}");
        if (value is bool isWin)
        {
            return isWin ? "🎲✔️" : "🎲❌";
        }
        return "🎲❓";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException(); // No need to convert back for this scenario.
    }
}

// Win Button State Converter
public class BoolToWinConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isWin)
            return !isWin; // Enable if not win.

        return true; // Enable by default.
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

// Loss Button State Converter
public class BoolToLossConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isWin)
            return isWin; // Enable if win.

        return true; // Enable by default.
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
