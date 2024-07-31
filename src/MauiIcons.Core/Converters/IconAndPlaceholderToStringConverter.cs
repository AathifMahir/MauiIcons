using MauiIcons.Core.Helpers;
using System.Globalization;

namespace MauiIcons.Core.Converters;

internal sealed class IconAndPlaceholderToStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null && parameter is null) return string.Empty;

        if ((parameter is null || parameter is string strValue && string.IsNullOrWhiteSpace(strValue)) && value is Enum enumValue)
            return enumValue.GetDescription();

        if (parameter is string stringValue && !string.IsNullOrWhiteSpace(stringValue) && value is null)
            return stringValue;

       

        if (parameter is string stringFinalValue && !string.IsNullOrWhiteSpace(stringFinalValue) && value is Enum enumFinalValue)
            return $"{enumFinalValue.GetDescription()} {stringFinalValue}";

        return string.Empty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
