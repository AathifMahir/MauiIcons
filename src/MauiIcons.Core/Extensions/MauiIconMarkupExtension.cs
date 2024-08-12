using System.Runtime.CompilerServices;

namespace MauiIcons.Core;
public static class MauiIconMarkupExtension
{
    /// <summary>
    /// Sets the icon.
    /// </summary>
    public static TIcon Icon<TIcon>(this TIcon bindable, Enum Icon) where TIcon : BindableObject, IMauiIcon
    {
        if(bindable is IMauiIcon)
        {
            bindable.SetValue(MauiIcon.ValueProperty, Icon);
        }
        return bindable;
    }

    /// <summary>
    /// Sets the size of the icon.
    /// </summary>
    public static TSize IconSize<TSize>(this TSize bindable, double size) where TSize : BindableObject, IMauiIcon
    {
        if(IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSizeProperty, size);
        }
        return bindable;
    }

    /// <summary>
    /// Sets the color of the icon.
    /// </summary>
    public static TColor IconColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconColorProperty, color);
        }
        return bindable;
    }

    /// <summary>
    /// Sets the background color of the icon.
    /// </summary>
    public static TColor IconBackgroundColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconBackgroundColorProperty, color);
        }
        return bindable;
    }

    /// <summary>
    /// Sets a value indicating whether the icon should automatically scale.
    /// </summary>
    public static TBool IconAutoScaling<TBool>(this TBool bindable, bool value) where TBool : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconAutoScalingProperty, value);
        }
        return bindable;
    }

    /// <summary>
    /// Sets the suffix for the icon.
    /// </summary>
    public static TText IconSuffix<TText>(this TText bindable, string suffix) where TText : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixProperty, suffix);
        }
        return bindable;
    }

    /// <summary>
    /// Sets the font family for the icon suffix.
    /// </summary>
    public static TText IconSuffixFontFamily<TText>(this TText bindable, string fontFamily) where TText : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixFontFamilyProperty, fontFamily);
        }
        return bindable;
    }

    /// <summary>
    /// Sets the font size for the icon suffix.
    /// </summary>
    public static TSize IconSuffixFontSize<TSize>(this TSize bindable, double size) where TSize : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixFontSizeProperty, size);
        }
        return bindable;
    }

    /// <summary>
    /// Sets the text color for the icon suffix.
    /// </summary>
    public static TColor IconSuffixTextColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixTextColorProperty, color);
        }
        return bindable;
    }

    /// <summary>
    /// Sets the background color for the icon suffix.
    /// </summary>
    public static TColor IconSuffixBackgroundColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixBackgroundColorProperty, color);
        }
        return bindable;
    }

    /// <summary>
    /// Sets the background color for the icon and Suffix, It applies the color to whole control.
    /// </summary>
    public static TColor BackgroundColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.BackgroundColorProperty, color);
        }
        return bindable;
    }

    /// <summary>
    /// Sets a value indicating whether the icon suffix should automatically scale.
    /// </summary>

    public static TBool IconSuffixAutoScaling<TBool>(this TBool bindable, bool value) where TBool : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixAutoScalingProperty, value);
        }
        return bindable;
    }

    /// <summary>
    /// Sets the type of entrance animation for the element.
    /// </summary>
    public static TAnimation EntranceAnimationType<TAnimation>(this TAnimation bindable, AnimationType animationType) where TAnimation : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.EntranceAnimationTypeProperty, animationType);
        }
        return bindable;
    }

    /// <summary>
    /// Sets the duration of the entrance animation for the element.
    /// </summary>
    public static TDuration EntranceAnimationDuration<TDuration>(this TDuration bindable, uint duration) where TDuration : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.EntranceAnimationDurationProperty, duration);
        }
        return bindable;
    }
    /// <summary>
    /// Sets a value for multiple platforms that this should render.
    /// </summary>
    public static TPlatform OnPlatforms<TPlatform>(this TPlatform bindable, IList<string> platforms) where TPlatform : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.OnPlatformsProperty, platforms);
        }
        return bindable;
    }

    /// <summary>
    /// Sets a value for multiple Idioms that this should render.
    /// </summary>
    public static TIdiom OnIdioms<TIdiom>(this TIdiom bindable, IList<string> idioms) where TIdiom : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.OnIdiomsProperty, idioms);
        }
        return bindable;
    }

    static bool IsMauiIconType<TType>(TType bindable) where TType : BindableObject, IMauiIcon
    {
        if (bindable is IMauiIcon) return true;

        DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new(17, 1);
        defaultInterpolatedStringHandler.AppendFormatted(typeof(TType));
        defaultInterpolatedStringHandler.AppendLiteral(" is not supported");
        throw new MauiIconsException(defaultInterpolatedStringHandler.ToStringAndClear());
    }
}
