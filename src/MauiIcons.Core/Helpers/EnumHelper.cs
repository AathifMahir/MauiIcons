using System.ComponentModel;
using System.Reflection;

namespace MauiIcons.Core.Helpers;
internal static class EnumHelper
{
#nullable enable
    public static string GetDescription(this Enum? value)
    {
        if(value is null) return string.Empty;
        string? description = value.ToString();

        FieldInfo? fieldInfo = value.GetType().GetField(value.ToString() ?? "");
        if (fieldInfo != null)
        {
            object[]? attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attributes?.Length > 0)
            {
                description = ((DescriptionAttribute)attributes[0]).Description;
            }
        }
        return description;
    }

    public static TEnum? GetEnumByDescription<TEnum>(this string? description, bool ignoreCase = false) where TEnum : struct, Enum
    {
        return Enum.GetValues<TEnum>()
                .FirstOrDefault(i => string.Compare(GetDescription(i), description, ignoreCase) == 0);
    }

    public static string GetFontFamily<TEnum>(this TEnum? value) where TEnum : struct, Enum
    {
        if(value is null) return string.Empty;
        return value.GetType().Name;
    }
}
