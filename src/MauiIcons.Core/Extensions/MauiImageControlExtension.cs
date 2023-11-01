﻿using MauiIcons.Core.Helpers;
using System.Runtime.CompilerServices;
using IImage = Microsoft.Maui.IImage;

namespace MauiIcons.Core;
public static class MauiImageControlExtension
{
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
            if(fontImage.Source is null) throw new MauiIconsExpection("Icon Not Assigned Yet. Please Ensure You Assign the Icon Before Configuring Other Icon-Based Properties.");
            return (FontImageSource)fontImage.Source;
        }
        throw new MauiIconsExpection("This Image Element Does Not Support Maui Icon Extensions.");
    }
}
