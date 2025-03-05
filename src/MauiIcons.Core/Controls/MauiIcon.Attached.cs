using MauiIcons.Core.Base;
using MauiIcons.Core.Converters;
using MauiIcons.Core.Helpers;

namespace MauiIcons.Core;
public partial class MauiIcon
{
    public static readonly BindableProperty ValueProperty = BindableProperty.CreateAttached("Value", typeof(BaseIcon), typeof(MauiIcon), null, propertyChanged: OnValuePropertyChanged);

    private static void OnValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue is null) return;

        BaseIcon baseIcon = (BaseIcon)newValue;
        bool isAllSetProperty = baseIcon.TargetName.Equals(".");
        bool isNotFontOverridenOrSuppressed = !baseIcon.FontOverride && !Options.DefaultFontOverride;

        if (!baseIcon.IsSet(BindableObject.BindingContextProperty))
            baseIcon.SetBinding(BindableObject.BindingContextProperty, Binding.Create<MauiIcon, object>(static (mi) => mi.BindingContext, source: bindable));

        switch (bindable)
        {
            case Button button:
                SetConditionalBinding(nameof(Button.Text),
                    matchBinding: () =>
                    {
                        if (isNotFontOverridenOrSuppressed)
                            throw new MauiIconsException("Your Applying Icon to Button Text Property Instead of ImageSource, To apply an icon to text, " +
                                "set FontOverride to true or UseMauiIconsCore Builder and Set DefaultFontOverride Globally. This will override the fonts and use default fonts instead of any assigned custom fonts.");

                        button.SetBinding(Button.TextColorProperty, Binding.Create<MauiIcon, Color>(static (mi) => mi.IconColor, source: baseIcon,
                    converter: new DefaultFontColorConverter(), converterParameter: button.TextColor));
                        button.SetBinding(Button.BackgroundColorProperty, Binding.Create<MauiIcon, Color>(static (mi) => mi.IconBackgroundColor, source: baseIcon,
                            converter: new DefaultFontColorConverter(), converterParameter: button.BackgroundColor));
                        button.SetBinding(Button.FontSizeProperty, Binding.Create<MauiIcon, double>(static (mi) => mi.IconSize, source: baseIcon,
                            converter: new DefaultFontSizeConverter(), converterParameter: button.FontSize));
                        button.SetBinding(Button.FontAutoScalingEnabledProperty, Binding.Create<MauiIcon, bool>(static (mi) => mi.IconAutoScaling, source: baseIcon,
                            converter: new DefaultFontAutoScalingConverter(), converterParameter: button.FontAutoScalingEnabled));

                        button.SetValue(Button.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                        button.SetBinding(Button.TextProperty, Binding.Create<MauiIcon, Enum?>(static (mi) => mi.Icon, source: baseIcon,
                            converter: new IconToGlyphConverter()));
                    },
                    defaultBinding: () =>
                    {
                        button.SetValue(Button.ImageSourceProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)button.ImageSource, baseIcon, button.TextColor);
                    });
                break;

            case Span span:
                span.SetValue(Span.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                span.SetBinding(Span.TextProperty, Binding.Create<MauiIcon, Enum?>(static (mi) => mi.Icon, source: baseIcon,
                    converter: new IconToGlyphConverter()));
                span.SetBinding(Span.TextColorProperty, Binding.Create<MauiIcon, Color>(static (mi) => mi.IconColor, source: baseIcon,
                    converter: new DefaultFontColorConverter(), converterParameter: span.TextColor));
                span.SetBinding(Span.BackgroundColorProperty, Binding.Create<MauiIcon, Color>(static (mi) => mi.IconBackgroundColor, source: baseIcon,
                    converter: new DefaultFontColorConverter(), converterParameter: span.BackgroundColor));
                span.SetBinding(Span.FontSizeProperty, Binding.Create<MauiIcon, double>(static (mi) => mi.IconSize, source: baseIcon,
                    converter: new DefaultFontSizeConverter(), converterParameter: span.FontSize));
                span.SetBinding(Span.FontAutoScalingEnabledProperty, Binding.Create<MauiIcon, bool>(static (mi) => mi.IconAutoScaling, source: baseIcon,
                    converter: new DefaultFontAutoScalingConverter(), converterParameter: span.FontAutoScalingEnabled));
                break;

            case Label label:
                label.SetValue(Label.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                label.SetBinding(Label.TextProperty, Binding.Create<MauiIcon, Enum?>(static (mi) => mi.Icon, source: baseIcon,
                    converter: new IconToGlyphConverter()));
                label.SetBinding(Label.TextColorProperty, Binding.Create<MauiIcon, Color>(static (mi) => mi.IconColor, source: baseIcon,
                    converter: new IconToGlyphConverter(), converterParameter: label.TextColor));
                label.SetBinding(Label.BackgroundColorProperty, Binding.Create<MauiIcon, Color>(static (mi) => mi.IconBackgroundColor, source: baseIcon,
                    converter: new DefaultFontColorConverter(), converterParameter: label.BackgroundColor));
                label.SetBinding(Label.FontSizeProperty, Binding.Create<MauiIcon, double>(static (mi) => mi.IconSize, source: baseIcon,
                    converter: new DefaultFontSizeConverter(), converterParameter: label.FontSize));
                label.SetBinding(Label.FontAutoScalingEnabledProperty, Binding.Create<MauiIcon, bool>(static (mi) => mi.IconAutoScaling, source: baseIcon,
                    converter: new DefaultFontAutoScalingConverter(), converterParameter: label.FontAutoScalingEnabled));
                break;

            case InputView inputView:
                if (isNotFontOverridenOrSuppressed)
                    throw new MauiIconsException("This input control does not natively support icons or image sources. To apply an icon to text or placholder, " +
                        "set FontOverride to true or UseMauiIconsCore Builder and Set DefaultFontOverride Globally. This will replace any custom fonts with the default fonts. Please be aware that explicitly setting the FontFamily on the control itself will not render the icon. " +
                        "Additionally, using FontOverride may cause unexpected behavior, such as issues with text rendering.");

                inputView.SetValue(InputView.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                inputView.SetBinding(InputView.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon,
                    converter: new DefaultFontColorConverter(), converterParameter: inputView.BackgroundColor));
                inputView.SetBinding(InputView.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon,
                    converter: new DefaultFontSizeConverter(), converterParameter: inputView.FontSize));
                inputView.SetBinding(InputView.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon,
                    converter: new DefaultFontAutoScalingConverter(), converterParameter: inputView.FontAutoScalingEnabled));

                SetConditionalBinding(nameof(InputView.Text),
                    matchBinding: () =>
                    {
                        inputView.SetBinding(InputView.TextProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, converter: new IconToGlyphConverter()));
                        inputView.SetBinding(InputView.TextColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, converter: new DefaultFontColorConverter(), converterParameter: inputView.TextColor));
                    },
                    defaultBinding: () =>
                    {
                        inputView.SetBinding(InputView.PlaceholderProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, converter: new IconToGlyphConverter()));
                        inputView.SetBinding(InputView.PlaceholderColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon, converter: new DefaultFontColorConverter(), converterParameter: inputView.PlaceholderColor));
                    });
                break;

            case MauiIcon mauiIcon:
                mauiIcon.SetBinding(MauiIcon.ValueProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon));
                mauiIcon.SetBinding(MauiIcon.IconColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon,
                    converter: new DefaultFontColorConverter(), converterParameter: mauiIcon.IconColor));
                mauiIcon.SetBinding(MauiIcon.IconBackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon,
                    converter: new DefaultFontColorConverter(), converterParameter: mauiIcon.IconBackgroundColor));
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
                SetFontImageSourceBinding((FontImageSource)imageCell.ImageSource, baseIcon, imageCell.TextColor);
                break;
            case FontImageSource fontImage:
                SetFontImageSourceBinding(fontImage, baseIcon);
                break;

            case BaseShellItem baseShellItem:
                SetConditionalBinding(nameof(BaseShellItem.FlyoutIcon),
                    matchBinding: () =>
                    {
                        baseShellItem.SetValue(BaseShellItem.FlyoutIconProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)baseShellItem.FlyoutIcon, baseIcon);
                    },
                    defaultBinding: () =>
                    {
                        baseShellItem.SetValue(BaseShellItem.IconProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)baseShellItem.Icon, baseIcon);
                    });
                break;

            case Shell shell:
                SetConditionalBinding(nameof(Shell.FlyoutIcon),
                    matchBinding: () =>
                    {
                        shell.SetValue(Shell.FlyoutIconProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)shell.FlyoutIcon, baseIcon);
                    },
                    defaultBinding: () =>
                    {
                        shell.SetValue(Shell.IconImageSourceProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)shell.IconImageSource, baseIcon);
                    });
                break;

            case SearchHandler searchHandler:
                SetConditionalBinding(nameof(SearchHandler.ClearIcon),
                    matchBinding: () =>
                    {
                        searchHandler.SetValue(SearchHandler.ClearIconProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)searchHandler.ClearIcon, baseIcon, searchHandler.TextColor);
                    },
                    defaultBinding: () =>
                    {
                        searchHandler.SetValue(SearchHandler.QueryIconProperty, new FontImageSource());
                        SetFontImageSourceBinding((FontImageSource)searchHandler.QueryIcon, baseIcon, searchHandler.TextColor);
                    });
                break;

            case BackButtonBehavior backButtonBehavior:
                backButtonBehavior.SetValue(BackButtonBehavior.IconOverrideProperty, new FontImageSource());
                SetFontImageSourceBinding((FontImageSource)backButtonBehavior.IconOverride, baseIcon);
                break;

            case MenuItem menuItem:
                menuItem.SetValue(MenuItem.IconImageSourceProperty, new FontImageSource());
                SetFontImageSourceBinding((FontImageSource)menuItem.IconImageSource, baseIcon);
                break;

            case Page page:
                page.SetValue(Page.IconImageSourceProperty, new FontImageSource());
                SetFontImageSourceBinding((FontImageSource)page.IconImageSource, baseIcon);
                break;

            case Picker picker:
                if (isNotFontOverridenOrSuppressed)
                    throw new MauiIconsException("This Picker Control doesn't natively support icons or image sources. To apply an icon to Title, " +
                        "set FontOverride to true or UseMauiIconsCore Builder and Set DefaultFontOverride Globally. This will override the fonts and use default fonts instead of any assigned custom fonts and additionally explicitly setting font or text on the control itself would not render the icon.");

                picker.SetValue(Picker.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
                picker.SetBinding(Picker.TitleProperty, new Binding(nameof(baseIcon.Icon), source: baseIcon, converter: new IconToGlyphConverter()));
                picker.SetBinding(Picker.TitleColorProperty, new Binding(nameof(baseIcon.IconColor), source: baseIcon,
                    converter: new DefaultFontColorConverter(), converterParameter: picker.TitleColor));
                picker.SetBinding(Picker.FontSizeProperty, new Binding(nameof(baseIcon.IconSize), source: baseIcon,
                    converter: new DefaultFontSizeConverter(), converterParameter: picker.FontSize));
                picker.SetBinding(Picker.FontAutoScalingEnabledProperty, new Binding(nameof(baseIcon.IconAutoScaling), source: baseIcon,
                    converter: new DefaultFontAutoScalingConverter(), converterParameter: picker.FontAutoScalingEnabled));
                picker.SetBinding(Picker.BackgroundColorProperty, new Binding(nameof(baseIcon.IconBackgroundColor), source: baseIcon,
                    converter: new DefaultFontColorConverter(), converterParameter: picker.BackgroundColor));
                break;

            case RadioButton radioButton:
                Image img = new();
                img.SetValue(Image.SourceProperty, new FontImageSource());
                SetFontImageSourceBinding((FontImageSource)img.Source, baseIcon, radioButton.TextColor);
                radioButton.SetValue(RadioButton.ContentProperty, img);
                break;

            case Slider slider:
                slider.SetValue(Slider.ThumbImageSourceProperty, new FontImageSource());
                SetFontImageSourceBinding((FontImageSource)slider.ThumbImageSource, baseIcon);
                break;

            default:
                throw new MauiIconsException($"MauiIcons extension doesn't support the {bindable} control, which doesn't natively support assigning icons or images.");
        }

        void SetConditionalBinding(string propertyName, Action matchBinding, Action defaultBinding)
        {
            if (isAllSetProperty || IsPropertyNameIsSet(propertyName))
            {
                matchBinding();

                if (!isAllSetProperty)
                    return;
            }

            defaultBinding();

            bool IsPropertyNameIsSet(ReadOnlySpan<char> propertyName) =>
                baseIcon.TargetName.AsSpan().CompareTo(propertyName, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }

    static void SetFontImageSourceBinding(FontImageSource fontImageSource, BaseIcon baseIcon, Color? textColor = null)
    {
        fontImageSource.SetValue(FontImageSource.FontFamilyProperty, baseIcon.Icon.GetFontFamily());
        fontImageSource.SetBinding(FontImageSource.GlyphProperty, Binding.Create<MauiIcon, Enum?>(static (mi) => mi.Icon, source: baseIcon,
            converter: new IconToGlyphConverter()));
        fontImageSource.SetBinding(FontImageSource.SizeProperty, Binding.Create<MauiIcon, double>(static (mi) => mi.IconSize, source: baseIcon,
            converter: new DefaultFontSizeConverter(), converterParameter: fontImageSource.Size));
        fontImageSource.SetBinding(FontImageSource.ColorProperty, Binding.Create<MauiIcon, Color>(static (mi) => mi.IconColor, source: baseIcon,
            converter: new DefaultFontColorConverter(), 
            converterParameter: textColor ?? fontImageSource.Color));
        fontImageSource.SetBinding(FontImageSource.FontAutoScalingEnabledProperty, Binding.Create<MauiIcon, bool>(static (mi) => mi.IconAutoScaling, source: baseIcon,
            converter: new DefaultFontAutoScalingConverter(), converterParameter: fontImageSource.FontAutoScalingEnabled));
    }

    public static BaseIcon? GetValue(BindableObject view)
    {
        return (BaseIcon?)view.GetValue(ValueProperty);
    }

    public static void SetValue(BindableObject view, BaseIcon? value)
    {
        view.SetValue(ValueProperty, value);
    }
}
