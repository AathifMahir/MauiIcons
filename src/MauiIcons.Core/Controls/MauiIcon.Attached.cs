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

        if (!baseIcon.IsSet(BindableObject.BindingContextProperty))
            baseIcon.SetBinding(BindableObject.BindingContextProperty, new Binding(nameof(BindingContext), source: bindable));

        switch (bindable)
        {
            case Button button:
                button.SetBinding(Button.TextColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon,
                    converter: new DefaultColorConverter(), converterParameter: button.TextColor));
                button.SetBinding(Button.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon,
                    converter: new DefaultColorConverter(), converterParameter: button.BackgroundColor));
                button.SetBinding(Button.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon));
                button.SetBinding(Button.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon));

                SetConditionalBinding(nameof(Button.Text),
                    matchBinding: () => {

                        if (!baseIcon.OverrideFontProperties)
                            throw new MauiIconsExpection("Your Applying Icon to Button Text Property Instead of ImageSource, To apply an icon to text, " +
                                "set OverrideFontProperties to true. This will override the fonts and use default fonts instead of any assigned custom fonts.");

                        button.SetValue(Button.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                        button.SetBinding(Button.TextProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon,
                            converter: new IconToGlyphConverter()));
                    }, 
                    defaultBinding: () => {
                        button.SetValue(Button.ImageSourceProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)button.ImageSource, baseIcon);
                    });
                break;

            case Label label:
                label.SetValue(Label.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                label.SetBinding(Label.TextProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon,
                    converter: new IconToGlyphConverter()));
                label.SetBinding(Label.TextColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon,
                    converter: new DefaultColorConverter(), converterParameter: label.TextColor));
                label.SetBinding(Label.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon,
                    converter: new DefaultColorConverter(), converterParameter: label.BackgroundColor));
                label.SetBinding(Label.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon));
                label.SetBinding(Label.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon));
                break;

            case Span span:
                span.SetValue(Span.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                span.SetBinding(Span.TextProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon,
                    converter: new IconToGlyphConverter()));
                span.SetBinding(Span.TextColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon,
                    converter: new DefaultColorConverter(), converterParameter: span.TextColor));
                span.SetBinding(Span.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon,
                    converter: new DefaultColorConverter(), converterParameter: span.BackgroundColor));
                span.SetBinding(Span.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon));
                span.SetBinding(Span.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon));
                break;

            case Entry entry:

                if (!baseIcon.OverrideFontProperties)
                    throw new MauiIconsExpection("Entry doesn't natively support icons or image sources. To apply an icon to text or placeholder, set OverrideFontProperties to true. This will override the fonts and use default fonts instead of any assigned custom fonts.");

                entry.SetValue(Entry.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                entry.SetBinding(Entry.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon,
                    converter: new DefaultColorConverter(), converterParameter: entry.BackgroundColor));
                entry.SetBinding(Entry.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon));
                entry.SetBinding(Entry.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon));

                SetConditionalBinding(nameof(Entry.Text),
                    matchBinding: () => {
                        entry.SetBinding(Entry.TextProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, converter: new IconToGlyphConverter()));
                        entry.SetBinding(Entry.TextColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, converter: new DefaultColorConverter(), converterParameter: entry.TextColor));
                    },
                    defaultBinding: () => {
                        entry.SetBinding(Entry.PlaceholderProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, converter: new IconToGlyphConverter()));
                        entry.SetBinding(Entry.PlaceholderColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, converter: new DefaultColorConverter(), converterParameter: entry.PlaceholderColor));
                    });
                break;

            case Editor editor:

                if(!baseIcon.OverrideFontProperties)
                    throw new MauiIconsExpection("Editor doesn't natively support icons or image sources. To apply an icon to text or placeholder, set OverrideFontProperties to true. This will override the fonts and use default fonts instead of any assigned custom fonts.");

                editor.SetValue(Editor.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                editor.SetBinding(Editor.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon,
                    converter: new DefaultColorConverter(), converterParameter: editor.BackgroundColor));
                editor.SetBinding(Editor.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon));
                editor.SetBinding(Editor.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon));

                SetConditionalBinding(nameof(Editor.Text),
                    matchBinding: () => {
                        editor.SetBinding(Editor.TextProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, converter: new IconToGlyphConverter()));
                        editor.SetBinding(Editor.TextColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, converter: new DefaultColorConverter(), converterParameter: editor.TextColor));
                    },
                    defaultBinding: () => {
                        editor.SetBinding(Editor.PlaceholderProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, converter: new IconToGlyphConverter()));
                        editor.SetBinding(Editor.PlaceholderColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, converter: new DefaultColorConverter(), converterParameter: editor.PlaceholderColor));
                    });
                break;

            case SearchBar searchBar:

                if (!baseIcon.OverrideFontProperties)
                    throw new MauiIconsExpection("SearchBar doesn't natively support icons or image sources. To apply an icon to text or placeholder, set OverrideFontProperties to true. This will override the fonts and use default fonts instead of any assigned custom fonts.");

                searchBar.SetValue(SearchBar.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                searchBar.SetBinding(SearchBar.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon,
                   converter: new DefaultColorConverter(), converterParameter: searchBar.BackgroundColor));
                searchBar.SetBinding(SearchBar.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon));
                searchBar.SetBinding(SearchBar.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon));
                SetConditionalBinding(nameof(SearchBar.Text),
                    matchBinding: () => {
                        searchBar.SetBinding(SearchBar.TextProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, converter: new IconToGlyphConverter()));
                        searchBar.SetBinding(SearchBar.TextColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, converter: new DefaultColorConverter(), converterParameter: searchBar.TextColor));
                    },
                    defaultBinding: () => {
                        searchBar.SetBinding(SearchBar.PlaceholderProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, converter: new IconToGlyphConverter()));
                        searchBar.SetBinding(SearchBar.PlaceholderColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, converter: new DefaultColorConverter(), converterParameter: searchBar.PlaceholderColor));
                    });
                break;

            case MauiIcon mauiIcon:
                mauiIcon.SetBinding(MauiIcon.ValueProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon));
                mauiIcon.SetBinding(MauiIcon.IconColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon,
                    converter: new DefaultColorConverter(), converterParameter: mauiIcon.IconColor));
                mauiIcon.SetBinding(MauiIcon.IconBackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon,
                    converter: new DefaultColorConverter(), converterParameter: mauiIcon.IconBackgroundColor));
                mauiIcon.SetBinding(MauiIcon.IconSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon));
                mauiIcon.SetBinding(MauiIcon.IconAutoScalingProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon));
                mauiIcon.SetBinding(MauiIcon.OnPlatformsProperty, new Binding(nameof(baseIcon.OnPlatforms), source: baseIcon));
                mauiIcon.SetBinding(MauiIcon.OnIdiomsProperty, new Binding(nameof(baseIcon.OnIdioms), source: baseIcon));
                break;

            case Image image:
                image.SetValue(Image.SourceProperty, new FontImageSource());
                SetFontImageSourceBinding((FontImageSource)image.Source, baseIcon);
                break;
            case ImageButton imageButton:
                imageButton.SetValue(ImageButton.SourceProperty, new FontImageSource());
                SetFontImageSourceBinding((FontImageSource)imageButton.Source, baseIcon);
                break;
            case ImageCell imageCell:
                imageCell.SetValue(ImageCell.ImageSourceProperty, new FontImageSource());
                SetFontImageSourceBinding((FontImageSource)imageCell.ImageSource, baseIcon);
                break;
            case FontImageSource fontImage:
                SetFontImageSourceBinding(fontImage, baseIcon);
                break;

            case TabBar tabBar:
                SetConditionalBinding(nameof(TabBar.FlyoutIcon),
                    matchBinding: () => {
                        tabBar.SetValue(TabBar.FlyoutIconProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)tabBar.FlyoutIcon, baseIcon);
                    },
                    defaultBinding: () => {
                        tabBar.SetValue(TabBar.IconProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)tabBar.Icon, baseIcon);
                    });
                break;

            case ShellContent shellContent:
                SetConditionalBinding(nameof(ShellContent.FlyoutIcon),
                    matchBinding: () => {
                        shellContent.SetValue(ShellContent.FlyoutIconProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)shellContent.FlyoutIcon, baseIcon);
                    },
                    defaultBinding: () => {
                        shellContent.SetValue(ShellContent.IconProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)shellContent.Icon, baseIcon);
                    });
                break;

            case Tab tab:
                SetConditionalBinding(nameof(Tab.FlyoutIcon),
                    matchBinding: () => {
                        tab.SetValue(Tab.FlyoutIconProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)tab.FlyoutIcon, baseIcon);
                    },
                    defaultBinding: () => {
                        tab.SetValue(Tab.IconProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)tab.Icon, baseIcon);
                    });
                break;
            default:
                throw new MauiIconsExpection($"MauiIcons extension doesn't support this control {bindable}");
        }

        void SetConditionalBinding(string propertyName, Action matchBinding, Action defaultBinding)
        {
            if (IsPropertyNameIsSet(propertyName))
                matchBinding();
            else
                defaultBinding();

            bool IsPropertyNameIsSet(ReadOnlySpan<char> propertyName) =>
                baseIcon.TargetName.AsSpan().CompareTo(propertyName, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }

    static void SetFontImageSourceBinding(FontImageSource fontImageSource, BaseIcon baseIcon)
    {
        fontImageSource.SetValue(FontImageSource.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
        fontImageSource.SetBinding(FontImageSource.GlyphProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, converter: new IconToGlyphConverter()));
        fontImageSource.SetBinding(FontImageSource.SizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon));
        fontImageSource.SetBinding(FontImageSource.ColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, converter: new DefaultColorConverter(), converterParameter: fontImageSource.Color));
        fontImageSource.SetBinding(FontImageSource.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon));
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
