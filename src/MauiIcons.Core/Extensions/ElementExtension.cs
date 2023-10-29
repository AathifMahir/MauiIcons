using System.Runtime.CompilerServices;

namespace MauiIcons.Core;
public static class ElementExtension
{
#nullable enable
    public static TIcon Icon<TIcon>(this TIcon bindable, Enum? text) where TIcon : BindableObject
    {
        if(IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconProperty, text);
        }
        return bindable;
    }
#nullable disable

    public static TSize IconSize<TSize>(this TSize bindable, double size) where TSize : BindableObject
    {
        if(IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSizeProperty, size);
        }
        return bindable;
    }

    public static TColor IconColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconColorProperty, color);
        }
        return bindable;
    }

    public static TColor IconBackgroundColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconBackgroundColorProperty, color);
        }
        return bindable;
    }

    public static TBool IconAutoScaling<TBool>(this TBool bindable, bool value) where TBool : BindableObject
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconAutoScalingProperty, value);
        }
        return bindable;
    }

    public static TText IconSuffix<TText>(this TText bindable, string suffix) where TText : BindableObject
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixProperty, suffix);
        }
        return bindable;
    }

    public static TText IconSuffixFontFamily<TText>(this TText bindable, string fontFamily) where TText : BindableObject
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixFontFamilyProperty, fontFamily);
        }
        return bindable;
    }

    public static TSize IconSuffixFontSize<TSize>(this TSize bindable, double size) where TSize : BindableObject
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixFontSizeProperty, size);
        }
        return bindable;
    }

    public static TColor IconSuffixTextColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixTextColorProperty, color);
        }
        return bindable;
    }

    public static TBool IconSuffixAutoScaling<TBool>(this TBool bindable, bool value) where TBool : BindableObject
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixAutoScalingProperty, value);
        }
        return bindable;
    }

    public static TAnimation EntranceAnimationType<TAnimation>(this TAnimation bindable, AnimationType animationType) where TAnimation : BindableObject
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.EntranceAnimationTypeProperty, animationType);
        }
        return bindable;
    }

    public static TDuration EntranceAnimationDuration<TDuration>(this TDuration bindable, uint duration) where TDuration : BindableObject
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.EntranceAnimationDurationProperty, duration);
        }
        return bindable;
    }

    static bool IsMauiIconType<TType>(TType bindable) where TType : BindableObject
    {
        if (bindable is not MauiIcon)
        {
            DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new(17, 1);
            defaultInterpolatedStringHandler.AppendFormatted(typeof(TType));
            defaultInterpolatedStringHandler.AppendLiteral(" is not supported");
            throw new NotSupportedException(defaultInterpolatedStringHandler.ToStringAndClear());
        }
        return true;
    }
}
