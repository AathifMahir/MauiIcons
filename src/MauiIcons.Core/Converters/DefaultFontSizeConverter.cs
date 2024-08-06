using System.Globalization;

namespace MauiIcons.Core.Converters;
internal sealed class DefaultFontSizeConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
       value switch
        {
            null or double and 0 when parameter is double and > 0 => parameter,
            double and > 0 => value,
            _ => 30.0
        };

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
