using MauiIcons.Core.Helpers;
using System.Globalization;

namespace MauiIcons.Core.Converters;
internal sealed class IconToGlyphConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not null && value is Enum val)
        {
            return val.GetDescription();
        }
        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not null && value is string str)
        {
            return str.GetEnumByDescription(targetType);
        }
        return null;
    }
}
