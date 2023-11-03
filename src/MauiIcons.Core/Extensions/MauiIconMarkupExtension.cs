using System.Runtime.CompilerServices;

namespace MauiIcons.Core;
public static class MauiIconMarkupExtension
{
    public static TIcon Icon<TIcon>(this TIcon bindable, Enum Icon) where TIcon : BindableObject, IMauiIcon
    {
        if(bindable is IMauiIcon)
        {
            bindable.SetValue(MauiIcon.IconProperty, Icon);
        }
        return bindable;
    }

    public static TSize IconSize<TSize>(this TSize bindable, double size) where TSize : BindableObject, IMauiIcon
    {
        if(IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSizeProperty, size);
        }
        return bindable;
    }

    public static TColor IconColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconColorProperty, color);
        }
        return bindable;
    }

    public static TColor IconBackgroundColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconBackgroundColorProperty, color);
        }
        return bindable;
    }

    public static TBool IconAutoScaling<TBool>(this TBool bindable, bool value) where TBool : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconAutoScalingProperty, value);
        }
        return bindable;
    }

    public static TText IconSuffix<TText>(this TText bindable, string suffix) where TText : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixProperty, suffix);
        }
        return bindable;
    }

    public static TText IconSuffixFontFamily<TText>(this TText bindable, string fontFamily) where TText : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixFontFamilyProperty, fontFamily);
        }
        return bindable;
    }

    public static TSize IconSuffixFontSize<TSize>(this TSize bindable, double size) where TSize : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixFontSizeProperty, size);
        }
        return bindable;
    }

    public static TColor IconSuffixTextColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixTextColorProperty, color);
        }
        return bindable;
    }

    public static TBool IconSuffixAutoScaling<TBool>(this TBool bindable, bool value) where TBool : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.IconSuffixAutoScalingProperty, value);
        }
        return bindable;
    }

    public static TAnimation EntranceAnimationType<TAnimation>(this TAnimation bindable, AnimationType animationType) where TAnimation : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.EntranceAnimationTypeProperty, animationType);
        }
        return bindable;
    }

    public static TDuration EntranceAnimationDuration<TDuration>(this TDuration bindable, uint duration) where TDuration : BindableObject, IMauiIcon
    {
        if (IsMauiIconType(bindable))
        {
            bindable.SetValue(MauiIcon.EntranceAnimationDurationProperty, duration);
        }
        return bindable;
    }

    static bool IsMauiIconType<TType>(TType bindable) where TType : BindableObject, IMauiIcon
    {
        if (bindable is IMauiIcon mi)
        {
            if (mi.Icon is null) throw new MauiIconsExpection("The Icon Has Not Been Assigned. Please Ensure That You Assign the Icon Before Configuring Other Icon-Based Properties.");
            return true;
        }
        DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new(17, 1);
        defaultInterpolatedStringHandler.AppendFormatted(typeof(TType));
        defaultInterpolatedStringHandler.AppendLiteral(" is not supported");
        throw new MauiIconsExpection(defaultInterpolatedStringHandler.ToStringAndClear());
    }
}
