using MauiIcons.Core.Helpers;
using System.Runtime.CompilerServices;

namespace MauiIcons.Core;
public static class MauiTextControlExtension
{
    public static TIcon Icon<TIcon>(this TIcon bindable, Enum icon, bool isPlaceHolder = true) where TIcon : BindableObject, IText
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

    public static TSize IconSize<TSize>(this TSize bindable, double size) where TSize : BindableObject, IText
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

    public static TColor IconBackgroundColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject, IText
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

    public static TBool IconAutoScaling<TBool>(this TBool bindable, bool value) where TBool : BindableObject, IText
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

    static TType ThrowCustomExpection<TType>()
    {
        DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new(17, 1);
        defaultInterpolatedStringHandler.AppendFormatted(typeof(TType));
        defaultInterpolatedStringHandler.AppendLiteral(" is not supported");
        throw new MauiIconsExpection(defaultInterpolatedStringHandler.ToStringAndClear());
    }
}
