using System.Globalization;

namespace MauiIcons.Core.Converters;
internal sealed class DefaultColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value switch
        {
            null when parameter is Color color => color,
            Color colorValue => colorValue,
            _ => null
        };

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
