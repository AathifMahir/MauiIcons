using MauiIcons.Core.Helpers;
using System.Globalization;

namespace MauiIcons.Core.Converters;
internal sealed class EnumToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value != null)
        {
            return EnumHelper.GetDescription((Enum)value);
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
