using System.ComponentModel;
using System.Reflection;

namespace MauiIcons.Helpers;
internal static class EnumHelper
{
    internal static string GetEnumDescription(this Enum enumValue)
    {
        FieldInfo field = enumValue.GetType().GetField(enumValue?.ToString());
        if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
        {
            return attribute.Description;
        }
        return string.Empty;
    }
    internal static T GetEnumValueByDescription<T>(this string description) where T : Enum
    {
        foreach (Enum enumItem in Enum.GetValues(typeof(T)))
        {
            if (enumItem.GetEnumDescription() == description)
            {
                return (T)enumItem;
            }
        }
        return default;
    }


}
