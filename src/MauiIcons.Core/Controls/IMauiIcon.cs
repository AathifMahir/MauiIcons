using Microsoft.Maui.Graphics.Converters;

namespace MauiIcons.Core;
public interface IMauiIcon
{
    /// <summary>
    /// Gets or sets the icon enum value.
    /// </summary>
    Enum? Value { get; }


    /// <summary>
    /// Gets or sets the size of the icon.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
    double IconSize { get;  }

    /// <summary>
    /// Gets or sets the color of the icon.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(ColorTypeConverter))]
    Color IconColor { get;  }

    /// <summary>
    /// Gets or sets the background color of the icon.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(ColorTypeConverter))]
    Color IconBackgroundColor { get;  }

    /// <summary>
    /// Gets or sets a value indicating whether the icon should automatically scale.
    /// </summary>
    bool IconAutoScaling { get; }

    /// <summary>
    /// Gets or sets the suffix for the icon.
    /// </summary>
    string IconSuffix { get; }

    /// <summary>
    /// Gets or sets the font family for the icon suffix.
    /// </summary>
    string IconSuffixFontFamily { get; }

    /// <summary>
    /// Gets or sets the font size for the icon suffix.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
    double IconSuffixFontSize { get; }

    /// <summary>
    /// Gets or sets the text color for the icon suffix.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(ColorTypeConverter))]
    Color IconSuffixTextColor { get; }

    /// <summary>
    /// Gets or sets the background color for the icon suffix.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(ColorTypeConverter))]
    Color IconSuffixBackgroundColor { get; }

    /// <summary>
    /// Gets or sets the background color for the icon and Suffix, It applies the color to whole control.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(ColorTypeConverter))]
    Color IconAndSuffixBackgroundColor { get; }

    /// <summary>
    /// Gets or sets a value indicating whether the icon suffix should automatically scale.
    /// </summary>
    bool IconSuffixAutoScaling { get; }

    /// <summary>
    /// Gets or Sets the type of entrance animation for the element.
    /// </summary>
    AnimationType EntranceAnimationType { get;}

    /// <summary>
    /// Gets or sets the duration of the entrance animation for the element.
    /// </summary>
    uint EntranceAnimationDuration { get; }

    /// <summary>
    /// Gets or sets the Platforms that control should render.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(ListStringTypeConverter))]
    IList<string> OnPlatforms { get; set; }

    /// <summary>
    /// Gets or sets the Idioms that control should render.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(ListStringTypeConverter))]
    IList<string> OnIdioms { get; set; }
    
}
