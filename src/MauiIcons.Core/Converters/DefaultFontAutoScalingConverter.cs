using System.Globalization;

namespace MauiIcons.Core.Converters;
internal sealed class DefaultFontAutoScalingConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value switch
        {
            null when parameter is bool => parameter,
            bool => value,
            _ => false
        };

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
