using MauiIcons.Core.Helpers;
using System.Runtime.CompilerServices;
using IImage = Microsoft.Maui.IImage;

namespace MauiIcons.Core;
public static class MauiImageMarkupExtension
{
    /// <summary>
    /// Gets or sets the icon.
    /// </summary>
    public static TImage Icon<TImage>(this TImage bindable, Enum icon) where TImage : BindableObject, IImageSourcePart
    {
        if (bindable is Button)
        {
            bindable.SetValue(Button.TextProperty, icon.GetDescription());
            bindable.SetValue(Button.FontFamilyProperty, icon.GetType().Name);
            return bindable;
        }
        if (bindable is IImage)
        {
            ImageSource imageSource = new FontImageSource()
            {
                Glyph = icon.GetDescription(),
                FontFamily =  icon.GetType().Name,
            };
            bindable.SetValue(Image.SourceProperty, imageSource);
            return bindable;
        }
        return ThrowCustomExpection<TImage>();
    }

    /// <summary>
    /// Gets or sets the size of the icon.
    /// </summary>
    public static TSize IconSize<TSize>(this TSize bindable, double size) where TSize : BindableObject, IImage
    {
        if (bindable is Button)
        {
            bindable.SetValue(Button.FontSizeProperty, size);
            return bindable;
        }
        if (bindable is IImage)
        {
            var imageSource = GetExistingSource(bindable);
            imageSource.Size = size;

            bindable.SetValue(Image.SourceProperty, imageSource);
            return bindable;
        }
        return ThrowCustomExpection<TSize>();
    }

    /// <summary>
    /// Gets or sets the color of the icon.
    /// </summary>
    public static TColor IconColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject, IImage
    {
        if (bindable is Button)
        {
            bindable.SetValue(Button.TextColorProperty, color);
            return bindable;
        }
        if (bindable is IImage)
        {
            var imageSource = GetExistingSource(bindable);
            imageSource.Color = color;

            bindable.SetValue(Image.SourceProperty, imageSource);
            return bindable;
        }
        return ThrowCustomExpection<TColor>();
    }

    /// <summary>
    /// Gets or sets the background color of the icon.
    /// </summary>
    public static TColor IconBackgroundColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject, IImage
    {
        if (bindable is Button)
        {
            bindable.SetValue(Button.BackgroundColorProperty, color);
            return bindable;
        }
        if (bindable is IImage)
        {
            bindable.SetValue(Image.BackgroundColorProperty, color);
            return bindable;
        }
        return ThrowCustomExpection<TColor>();
    }

    /// <summary>
    /// Gets or sets a value indicating whether the icon should automatically scale.
    /// </summary>
    public static TBool IconAutoScaling<TBool>(this TBool bindable, bool value) where TBool : BindableObject, IImage
    {
        if (bindable is Button)
        {
            bindable.SetValue(Button.FontAutoScalingEnabledProperty, value);
            return bindable;
        }
        if (bindable is IImage)
        {
            var imageSource = GetExistingSource(bindable);
            imageSource.FontAutoScalingEnabled = value;

            bindable.SetValue(Image.SourceProperty, imageSource);
            return bindable;
        }
        return ThrowCustomExpection<TBool>();
    }

    /// <summary>
    /// Sets a value for platform that this should render.
    /// </summary>
    public static TPlatform OnPlatform<TPlatform>(this TPlatform bindable, PlatformType platform) where TPlatform : BindableObject, IText
    {
        if (bindable is Button && PlatformHelper.IsValidPlatform(platform))
            return bindable;

        else if (bindable is Button)
        {
            bindable.SetValue(Button.TextProperty, null);
            bindable.SetValue(Button.FontFamilyProperty, null);
            bindable.SetValue(Button.FontSizeProperty, null);
            bindable.SetValue(Button.TextColorProperty, null);
            bindable.SetValue(Button.BackgroundColorProperty, null);
            bindable.SetValue(Button.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        if (bindable is IImage && PlatformHelper.IsValidPlatform(platform))
            return bindable;

        else if (bindable is IImage)
        {
            bindable.SetValue(Image.SourceProperty, null);
            bindable.SetValue(Image.BackgroundColorProperty, null);
            return bindable;
        }
        return ThrowCustomExpection<TPlatform>();
    }

    /// <summary>
    /// Sets a value for Idiom that this should render.
    /// </summary>
    public static TIdiom OnIdiom<TIdiom>(this TIdiom bindable, IdiomType idiom) where TIdiom : BindableObject, IText
    {
        if (bindable is Button && PlatformHelper.IsValidIdiom(idiom))
            return bindable;

        else if (bindable is Button)
        {
            bindable.SetValue(Button.TextProperty, null);
            bindable.SetValue(Button.FontFamilyProperty, null);
            bindable.SetValue(Button.FontSizeProperty, null);
            bindable.SetValue(Button.TextColorProperty, null);
            bindable.SetValue(Button.BackgroundColorProperty, null);
            bindable.SetValue(Button.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        if (bindable is IImage && PlatformHelper.IsValidIdiom(idiom))
            return bindable;

        else if (bindable is IImage)
        {
            bindable.SetValue(Image.SourceProperty, null);
            bindable.SetValue(Image.BackgroundColorProperty, null);
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

    static FontImageSource GetExistingSource<TType>(TType bindable) where TType : BindableObject
    {
        if(bindable is Image fontImage)
        {
            if(fontImage.Source is null) return new FontImageSource();

            return (FontImageSource)fontImage.Source;
        }
        throw new MauiIconsExpection("This Image Element Does Not Support Maui Icon Extensions.");
    }
}
