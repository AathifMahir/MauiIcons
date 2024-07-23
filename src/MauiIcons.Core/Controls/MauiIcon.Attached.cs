using MauiIcons.Core.Base;
using MauiIcons.Core.Converters;
using MauiIcons.Core.Helpers;

namespace MauiIcons.Core;
public partial class MauiIcon
{
    public static new readonly BindableProperty IconProperty = BindableProperty.CreateAttached("Icon", typeof(BaseIcon), typeof(MauiIcon), null, propertyChanged: OnIconPropertyChanged);

    private static void OnIconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue is null || newValue is not BaseIcon)
            return;

        BaseIcon baseIcon = (BaseIcon)newValue;
        switch (bindable)
        {
            case Button button:
                button.SetValue(Button.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                button.SetBinding(Button.TextProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new IconToGlyphConverter()));
                button.SetBinding(Button.TextColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: button.TextColor));
                button.SetBinding(Button.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: button.BackgroundColor));
                button.SetBinding(Button.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon, mode: BindingMode.OneWay));
                button.SetBinding(Button.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon, mode: BindingMode.OneWay));
                break;

            case Label label:
                label.SetValue(Label.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                label.SetBinding(Label.TextProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new IconToGlyphConverter()));
                label.SetBinding(Label.TextColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: label.TextColor));
                label.SetBinding(Label.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: label.BackgroundColor));
                label.SetBinding(Label.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon, mode: BindingMode.OneWay));
                label.SetBinding(Label.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon, mode: BindingMode.OneWay));
                break;

            case Span span:
                span.SetValue(Span.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                span.SetBinding(Span.TextProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new IconToGlyphConverter()));
                span.SetBinding(Span.TextColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: span.TextColor));
                span.SetBinding(Span.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: span.BackgroundColor));
                span.SetBinding(Span.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon, mode: BindingMode.OneWay));
                span.SetBinding(Span.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon, mode: BindingMode.OneWay));
                break;

            case Entry entry:
                entry.SetValue(Entry.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                entry.SetBinding(Entry.TextProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new IconToGlyphConverter()));
                entry.SetBinding(Entry.TextColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: entry.TextColor));
                entry.SetBinding(Entry.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: entry.BackgroundColor));
                entry.SetBinding(Entry.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon, mode: BindingMode.OneWay));
                entry.SetBinding(Entry.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon, mode: BindingMode.OneWay));
                break;

            case Editor editor:
                editor.SetValue(Editor.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                editor.SetBinding(Editor.TextProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new IconToGlyphConverter()));
                editor.SetBinding(Editor.TextColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: editor.TextColor));
                editor.SetBinding(Editor.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: editor.BackgroundColor));
                editor.SetBinding(Editor.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon, mode: BindingMode.OneWay));
                editor.SetBinding(Editor.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon, mode: BindingMode.OneWay));
                break;

            case SearchBar searchBar:
                searchBar.SetValue(SearchBar.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                searchBar.SetBinding(SearchBar.TextProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new IconToGlyphConverter()));
                searchBar.SetBinding(SearchBar.TextColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: searchBar.TextColor));
                searchBar.SetBinding(SearchBar.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: searchBar.BackgroundColor));
                searchBar.SetBinding(SearchBar.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon, mode: BindingMode.OneWay));
                searchBar.SetBinding(SearchBar.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon, mode: BindingMode.OneWay));
                break;

            case MauiIcon mauiIcon:
                mauiIcon.SetBinding(MauiIcon.ValueProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, mode: BindingMode.OneWay));
                mauiIcon.SetBinding(MauiIcon.IconColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: mauiIcon.IconColor));
                mauiIcon.SetBinding(MauiIcon.IconBackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: mauiIcon.IconBackgroundColor));
                mauiIcon.SetBinding(MauiIcon.IconSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon, mode: BindingMode.OneWay));
                mauiIcon.SetBinding(MauiIcon.IconAutoScalingProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon, mode: BindingMode.OneWay));
                break;

            case Image image:
                image.SetValue(Image.SourceProperty, new FontImageSource());
                ((FontImageSource)image.Source).SetBinding(FontImageSource.GlyphProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new IconToGlyphConverter()));
                ((FontImageSource)image.Source).SetValue(FontImageSource.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                ((FontImageSource)image.Source).SetBinding(FontImageSource.SizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon, mode: BindingMode.OneWay));
                ((FontImageSource)image.Source).SetBinding(FontImageSource.ColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: ((FontImageSource)image.Source).Color));
                ((FontImageSource)image.Source).SetBinding(FontImageSource.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon, mode: BindingMode.OneWay));
                break;

            case ImageButton imageButton:
                imageButton.SetValue(ImageButton.SourceProperty, new FontImageSource());
                ((FontImageSource)imageButton.Source).SetBinding(FontImageSource.GlyphProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new IconToGlyphConverter()));
                ((FontImageSource)imageButton.Source).SetValue(FontImageSource.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                ((FontImageSource)imageButton.Source).SetBinding(FontImageSource.SizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon, mode: BindingMode.OneWay));
                ((FontImageSource)imageButton.Source).SetBinding(FontImageSource.ColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: ((FontImageSource)imageButton.Source).Color));
                ((FontImageSource)imageButton.Source).SetBinding(FontImageSource.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon, mode: BindingMode.OneWay));
                break;

            case ImageCell imageCell:
                imageCell.SetValue(ImageCell.ImageSourceProperty, new FontImageSource());
                ((FontImageSource)imageCell.ImageSource).SetBinding(FontImageSource.GlyphProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new IconToGlyphConverter()));
                ((FontImageSource)imageCell.ImageSource).SetValue(FontImageSource.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                ((FontImageSource)imageCell.ImageSource).SetBinding(FontImageSource.SizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon, mode: BindingMode.OneWay));
                ((FontImageSource)imageCell.ImageSource).SetBinding(FontImageSource.ColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: ((FontImageSource)imageCell.ImageSource).Color));
                ((FontImageSource)imageCell.ImageSource).SetBinding(FontImageSource.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon, mode: BindingMode.OneWay));
                break;

            case FontImageSource fontImageSource:
                fontImageSource.SetValue(FontImageSource.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                fontImageSource.SetBinding(FontImageSource.GlyphProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new IconToGlyphConverter()));
                fontImageSource.SetBinding(FontImageSource.SizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon, mode: BindingMode.OneWay));
                fontImageSource.SetBinding(FontImageSource.ColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, mode: BindingMode.OneWay,
                    converter: new DefaultColorConverter(), converterParameter: fontImageSource.Color));
                fontImageSource.SetBinding(FontImageSource.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon, mode: BindingMode.OneWay));
                break;

            default:
                throw new MauiIconsExpection($"MauiIcons extension doesn't support this control {bindable}");
        }
    }


    public static BaseIcon? GetIcon(BindableObject view)
    {
        return (BaseIcon?)view.GetValue(IconProperty);
    }

    public static void SetIcon(BindableObject view, BaseIcon? value)
    {
        view.SetValue(IconProperty, value);
    }
}
