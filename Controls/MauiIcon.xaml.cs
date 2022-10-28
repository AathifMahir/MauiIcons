
namespace Maui.Icons;

public sealed partial class MauiIcon : ContentView
{
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(MauiIcon), string.Empty);
    public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(double), typeof(MauiIcon), 30.0);
    public static readonly BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(MauiIcon), Colors.White);
    public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(MauiIcon), Colors.Transparent);
    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
    public double IconSize
    {
        get => (double)GetValue(IconSizeProperty);
        set => SetValue(IconSizeProperty, value);
    }
    public Color IconColor
    {
        get => (Color)GetValue(IconColorProperty);
        set => SetValue(IconColorProperty, value);
    }

    public Color IconBackgroundColor
    {
        get => (Color)GetValue(IconBackgroundColorProperty);
        set => SetValue(IconBackgroundColorProperty, value);
    }

    public string CustomFontFamily { get; set; } = AssignIconType();

    
    public MauiIcon()
	{
		InitializeComponent();
        BindingContext = this;
    }

    private static string PlatformBasedIconType()
    {
        if(DeviceInfo.Current.Platform == DevicePlatform.Android) 
            return Constants.MaterialIcons;
        if(DeviceInfo.Current.Platform == DevicePlatform.iOS || 
            DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst || 
            DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
            return Constants.CuppertinoIcons;
        return Constants.FluentIcons;
    }

    private static string AssignIconType()
    {
        return AppBuilderExtensions.SelectedIconType switch
        {
            IconType.FluentIcons => Constants.FluentIcons,
            IconType.MaterialIcons => Constants.MaterialIcons,
            IconType.CuppertinoIcons => Constants.CuppertinoIcons,
            IconType.Default => PlatformBasedIconType(),
            _ => Constants.FluentIcons,
        };
    }

}