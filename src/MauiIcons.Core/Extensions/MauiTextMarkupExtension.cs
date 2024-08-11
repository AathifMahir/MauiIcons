using MauiIcons.Core.Helpers;
using System.Runtime.CompilerServices;

namespace MauiIcons.Core;
public static class MauiTextMarkupExtension
{
    /// <summary>
    /// Sets the icon.
    /// </summary>
    public static TIcon Icon<TIcon>(this TIcon bindable, Enum icon, bool isPlaceHolder = true, bool fontOverride = false) where TIcon : BindableObject, IText
    {
        if (bindable is ILabel)
        {
            bindable.SetValue(Label.TextProperty, icon.GetDescription());
            bindable.SetValue(Label.FontFamilyProperty, icon.GetType().Name);
            return bindable;
        }
        if (bindable is IButton)
        {
            bindable.SetValue(Button.TextProperty, icon.GetDescription());
            bindable.SetValue(Button.FontFamilyProperty, icon.GetType().Name);
            return bindable;
        }
        if (bindable is Span)
        {
            bindable.SetValue(Span.TextProperty, icon.GetDescription());
            bindable.SetValue(Span.FontFamilyProperty, icon.GetType().Name);
            return bindable;
        }

        if (!Options.DefaultFontOverride && !fontOverride)
            throw new MauiIconsExpection("the input controls does not natively support icons or image sources. To apply an icon to text or placholder, " +
                        "Set fontOverride Parameter to True. This will replace any custom fonts with the default fonts. Please be aware that explicitly setting the FontFamily on the control itself will not render the icon. " +
                        "Additionally, using FontOverride may cause unexpected behavior, such as issues with text rendering.");

        if (bindable is IEntry)
        {
            if (isPlaceHolder)
                bindable.SetValue(Entry.PlaceholderProperty, icon.GetDescription());
            else
                bindable.SetValue(Entry.TextProperty, icon.GetDescription());

            bindable.SetValue(Entry.FontFamilyProperty, icon.GetType().Name);

            return bindable;
        }
        if(bindable is ISearchBar)
        {
            if(isPlaceHolder)
                bindable.SetValue(SearchBar.PlaceholderProperty, icon.GetDescription());
            else
                bindable.SetValue(SearchBar.TextProperty, icon.GetDescription());

            bindable.SetValue(SearchBar.FontFamilyProperty, icon.GetType().Name);
            return bindable;
        }
        if(bindable is IEditor)
        {
            if(isPlaceHolder)
                bindable.SetValue(Editor.PlaceholderProperty, icon.GetDescription());
            else
                bindable.SetValue(Editor.TextProperty, icon.GetDescription());

            bindable.SetValue(Editor.FontFamilyProperty, icon.GetType().Name);
            return bindable;
        }
        return ThrowCustomExpection<TIcon>();
    }

    /// <summary>
    /// Sets the size of the icon.
    /// </summary>

    public static TSize IconSize<TSize>(this TSize bindable, double size, bool isPlaceHolder = true) where TSize : BindableObject, IText
    {
        if (bindable is ILabel)
        {
            bindable.SetValue(Label.FontSizeProperty, size);
            return bindable;
        }
        if (bindable is IButton)
        {
            bindable.SetValue(Button.FontSizeProperty, size);
            return bindable;
        }
        if (bindable is Span)
        {
            bindable.SetValue(Span.FontSizeProperty, size);
            return bindable;
        }
        if (bindable is IEntry)
        {
            bindable.SetValue(Entry.FontSizeProperty, size);
            return bindable;
        }
        if (bindable is ISearchBar)
        {
            bindable.SetValue(SearchBar.FontSizeProperty, size);
            return bindable;
        }
        if (bindable is IEditor)
        {
            bindable.SetValue(Editor.FontSizeProperty, size);
            return bindable;
        }

        return ThrowCustomExpection<TSize>();
    }

    /// <summary>
    /// Sets the color of the icon.
    /// </summary>
    public static TColor IconColor<TColor>(this TColor bindable, Color color, bool isPlaceHolder = true) where TColor : BindableObject, IText
    {
        if (bindable is ILabel)
        {
            bindable.SetValue(Label.TextColorProperty, color);
            return bindable;
        }
        if (bindable is IButton)
        {
            bindable.SetValue(Button.TextColorProperty, color);
            return bindable;
        }
        if (bindable is Span)
        {
            bindable.SetValue(Span.TextColorProperty, color);
            return bindable;
        }
        if (bindable is IEntry)
        {
            if(isPlaceHolder)
                bindable.SetValue(Entry.PlaceholderColorProperty, color);
            else
                bindable.SetValue(Entry.TextColorProperty, color);

            return bindable;
        }
        if (bindable is ISearchBar)
        {
            if(isPlaceHolder)
                bindable.SetValue(SearchBar.PlaceholderColorProperty, color);
            else
                bindable.SetValue(SearchBar.TextColorProperty, color);

            return bindable;
        }
        if (bindable is IEditor)
        {
            bindable.SetValue(Editor.PlaceholderColorProperty, color);
            return bindable;
        }

        return ThrowCustomExpection<TColor>();
    }

    /// <summary>
    /// Sets the background color of the icon.
    /// </summary>
    public static TColor IconBackgroundColor<TColor>(this TColor bindable, Color color, bool isPlaceHolder = true) where TColor : BindableObject, IText
    {
        if (bindable is ILabel)
        {
            bindable.SetValue(Label.BackgroundColorProperty, color);
            return bindable;
        }
        if (bindable is IButton)
        {
            bindable.SetValue(Button.BackgroundColorProperty, color);
            return bindable;
        }
        if (bindable is Span)
        {
            bindable.SetValue(Span.BackgroundColorProperty, color);
            return bindable;
        }
        if (bindable is IEntry)
        {
            bindable.SetValue(Entry.BackgroundColorProperty, color);
            return bindable;
        }
        if (bindable is ISearchBar)
        {
            bindable.SetValue(SearchBar.BackgroundColorProperty, color);
            return bindable;
        }
        if (bindable is IEditor)
        {
            bindable.SetValue(Editor.BackgroundColorProperty, color);
            return bindable;
        }

        return ThrowCustomExpection<TColor>();
    }

    /// <summary>
    /// Sets a value indicating whether the icon should automatically scale.
    /// </summary>
    public static TBool IconAutoScaling<TBool>(this TBool bindable, bool value, bool isPlaceHolder = true) where TBool : BindableObject, IText
    {
        if (bindable is ILabel)
        {
            bindable.SetValue(Label.FontAutoScalingEnabledProperty, value);
            return bindable;
        }
        if (bindable is IButton)
        {
            bindable.SetValue(Button.FontAutoScalingEnabledProperty, value);
            return bindable;
        }
        if (bindable is Span)
        {
            bindable.SetValue(Span.FontAutoScalingEnabledProperty, value);
            return bindable;
        }
        if (bindable is IEntry)
        {
            bindable.SetValue(Entry.FontAutoScalingEnabledProperty, value);
            return bindable;
        }
        if (bindable is ISearchBar)
        {
            bindable.SetValue(SearchBar.FontAutoScalingEnabledProperty, value);
            return bindable;
        }
        if (bindable is IEditor)
        {
            bindable.SetValue(Editor.FontAutoScalingEnabledProperty, value);
            return bindable;
        }
        return ThrowCustomExpection<TBool>();
    }

    
    /// <summary>
    /// Sets a value for multiple platforms that this should render.
    /// </summary>
    public static TPlatform OnPlatforms<TPlatform>(this TPlatform bindable, IList<string> platforms, bool isPlaceHolder = true) where TPlatform : BindableObject, IText
    {
        if (bindable is ILabel && PlatformHelper.IsValidPlatform(platforms))
            return bindable;

        else if (bindable is ILabel)
        {
            bindable.SetValue(Label.TextProperty, null);
            bindable.SetValue(Label.FontFamilyProperty, null);
            bindable.SetValue(Label.FontSizeProperty, null);
            bindable.SetValue(Label.TextColorProperty, null);
            bindable.SetValue(Label.BackgroundColorProperty, null);
            bindable.SetValue(Label.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        if (bindable is IButton && PlatformHelper.IsValidPlatform(platforms))
            return bindable;

        else if (bindable is IButton)
        {
            bindable.SetValue(Button.TextProperty, null);
            bindable.SetValue(Button.FontFamilyProperty, null);
            bindable.SetValue(Button.FontSizeProperty, null);
            bindable.SetValue(Button.TextColorProperty, null);
            bindable.SetValue(Button.BackgroundColorProperty, null);
            bindable.SetValue(Button.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        if (bindable is Span && PlatformHelper.IsValidPlatform(platforms))
            return bindable;

        else if (bindable is Span)
        {
            bindable.SetValue(Span.TextProperty, null);
            bindable.SetValue(Span.FontFamilyProperty, null);
            bindable.SetValue(Span.FontSizeProperty, null);
            bindable.SetValue(Span.TextColorProperty, null);
            bindable.SetValue(Span.BackgroundColorProperty, null);
            bindable.SetValue(Span.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        if (bindable is IEntry && PlatformHelper.IsValidPlatform(platforms))
            return bindable;

        else if (bindable is IEntry)
        {
            bindable.SetValue(Entry.TextProperty, null);
            bindable.SetValue(Entry.PlaceholderProperty, null);
            bindable.SetValue(Entry.FontFamilyProperty, null);
            bindable.SetValue(Entry.FontSizeProperty, null);
            bindable.SetValue(Entry.TextColorProperty, null);
            bindable.SetValue(Entry.PlaceholderProperty, null);
            bindable.SetValue(Entry.BackgroundColorProperty, null);
            bindable.SetValue(Entry.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        if (bindable is ISearchBar && PlatformHelper.IsValidPlatform(platforms))
            return bindable;

        else if (bindable is ISearchBar)
        {
            bindable.SetValue(SearchBar.TextProperty, null);
            bindable.SetValue(SearchBar.PlaceholderProperty, null);
            bindable.SetValue(SearchBar.FontFamilyProperty, null);
            bindable.SetValue(SearchBar.FontSizeProperty, null);
            bindable.SetValue(SearchBar.TextColorProperty, null);
            bindable.SetValue(SearchBar.PlaceholderProperty, null);
            bindable.SetValue(SearchBar.BackgroundColorProperty, null);
            bindable.SetValue(SearchBar.FontAutoScalingEnabledProperty, false);
            return bindable;

        }
        if (bindable is IEditor && PlatformHelper.IsValidPlatform(platforms))
            return bindable;

        else if (bindable is IEditor)
        {
            bindable.SetValue(Editor.TextProperty, null);
            bindable.SetValue(Editor.PlaceholderProperty, null);
            bindable.SetValue(Editor.FontFamilyProperty, null);
            bindable.SetValue(Editor.FontSizeProperty, null);
            bindable.SetValue(Editor.TextColorProperty, null);
            bindable.SetValue(Editor.PlaceholderProperty, null);
            bindable.SetValue(Editor.BackgroundColorProperty, null);
            bindable.SetValue(Editor.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        return ThrowCustomExpection<TPlatform>();
    }

    /// <summary>
    /// Sets a value for multiple Idioms that this should render.
    /// </summary>
    public static TIdiom OnIdioms<TIdiom>(this TIdiom bindable, IList<string> idioms, bool isPlaceHolder = true) where TIdiom : BindableObject, IText
    {
        if (bindable is ILabel && PlatformHelper.IsValidIdiom(idioms))
            return bindable;

        else if (bindable is ILabel)
        {
            bindable.SetValue(Label.TextProperty, null);
            bindable.SetValue(Label.FontFamilyProperty, null);
            bindable.SetValue(Label.FontSizeProperty, null);
            bindable.SetValue(Label.TextColorProperty, null);
            bindable.SetValue(Label.BackgroundColorProperty, null);
            bindable.SetValue(Label.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        if (bindable is IButton && PlatformHelper.IsValidIdiom(idioms))
            return bindable;

        else if (bindable is IButton)
        {
            bindable.SetValue(Button.TextProperty, null);
            bindable.SetValue(Button.FontFamilyProperty, null);
            bindable.SetValue(Button.FontSizeProperty, null);
            bindable.SetValue(Button.TextColorProperty, null);
            bindable.SetValue(Button.BackgroundColorProperty, null);
            bindable.SetValue(Button.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        if (bindable is Span && PlatformHelper.IsValidIdiom(idioms))
            return bindable;

        else if (bindable is Span)
        {
            bindable.SetValue(Span.TextProperty, null);
            bindable.SetValue(Span.FontFamilyProperty, null);
            bindable.SetValue(Span.FontSizeProperty, null);
            bindable.SetValue(Span.TextColorProperty, null);
            bindable.SetValue(Span.BackgroundColorProperty, null);
            bindable.SetValue(Span.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        if (bindable is IEntry && PlatformHelper.IsValidIdiom(idioms))
            return bindable;

        else if (bindable is IEntry)
        {
            bindable.SetValue(Entry.TextProperty, null);
            bindable.SetValue(Entry.PlaceholderProperty, null);
            bindable.SetValue(Entry.FontFamilyProperty, null);
            bindable.SetValue(Entry.FontSizeProperty, null);
            bindable.SetValue(Entry.TextColorProperty, null);
            bindable.SetValue(Entry.PlaceholderProperty, null);
            bindable.SetValue(Entry.BackgroundColorProperty, null);
            bindable.SetValue(Entry.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        if (bindable is ISearchBar && PlatformHelper.IsValidIdiom(idioms))
            return bindable;

        else if (bindable is ISearchBar)
        {
            bindable.SetValue(SearchBar.TextProperty, null);
            bindable.SetValue(SearchBar.PlaceholderProperty, null);
            bindable.SetValue(SearchBar.FontFamilyProperty, null);
            bindable.SetValue(SearchBar.FontSizeProperty, null);
            bindable.SetValue(SearchBar.TextColorProperty, null);
            bindable.SetValue(SearchBar.PlaceholderProperty, null);
            bindable.SetValue(SearchBar.BackgroundColorProperty, null);
            bindable.SetValue(SearchBar.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        if (bindable is IEditor && PlatformHelper.IsValidIdiom(idioms))
            return bindable;

        else if (bindable is IEditor)
        {
            bindable.SetValue(Editor.TextProperty, null);
            bindable.SetValue(Editor.PlaceholderProperty, null);
            bindable.SetValue(Editor.FontFamilyProperty, null);
            bindable.SetValue(Editor.FontSizeProperty, null);
            bindable.SetValue(Editor.TextColorProperty, null);
            bindable.SetValue(Editor.PlaceholderProperty, null);
            bindable.SetValue(Editor.BackgroundColorProperty, null);
            bindable.SetValue(Editor.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        return ThrowCustomExpection<TIdiom>();
    }

    static TType ThrowCustomExpection<TType>()
    {
        DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new(17, 1);
        defaultInterpolatedStringHandler.AppendFormatted(typeof(TType));
        defaultInterpolatedStringHandler.AppendLiteral(" is not supported");
        throw new MauiIconsExpection(defaultInterpolatedStringHandler.ToStringAndClear());
    }
}
