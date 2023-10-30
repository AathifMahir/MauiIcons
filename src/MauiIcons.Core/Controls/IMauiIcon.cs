using Microsoft.Maui.Graphics.Converters;

namespace MauiIcons.Core;
public interface IMauiIcon
{
#nullable enable
    public Enum? Icon 
    { 
        get; 
    }

#nullable disable

    [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
    public double IconSize
    {
        get;
    }

    [System.ComponentModel.TypeConverter(typeof(ColorTypeConverter))]
    public Color IconColor
    {
        get;
    }

    [System.ComponentModel.TypeConverter(typeof(ColorTypeConverter))]
    public Color IconBackgroundColor
    {
        get;
    }
    public bool IconAutoScaling
    {
        get;
    }
    public string IconSuffix
    {
        get;
    }

    public string IconSuffixFontFamily
    {
        get;
    }

    [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
    public double IconSuffixFontSize
    {
        get;

    }

    [System.ComponentModel.TypeConverter(typeof(ColorTypeConverter))]
    public Color IconSuffixTextColor
    {
        get;
    }

    public bool IconSuffixAutoScaling
    {
        get;
    }

    public AnimationType EntranceAnimationType
    {
        get;
    }

    public uint EntranceAnimationDuration
    {
        get;
    }
}
