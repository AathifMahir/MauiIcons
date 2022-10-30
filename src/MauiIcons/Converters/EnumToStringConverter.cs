using MauiIcons.Helpers;
using System.Globalization;

namespace MauiIcons.Converters;
internal sealed class EnumToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value != null)
        {
            return EnumHelper.GetEnumDescription((Enum)value);
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
