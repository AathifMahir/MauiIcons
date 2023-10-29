using MauiIcons.Core;
using MauiIcons.Fluent;
using MauiIcons.Material;

namespace MauiIcons.Sample;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        // Temporary Workaround for url styled namespace in xaml
        _ = new MauiIcon();
        AddToStack();
    }
    void AddToStack()
    {
        var image = new Image() { Source = (ImageSource)new MauiIcon() { Icon = MaterialIcons.AddComment, IconColor = Colors.Lime } };
        var MauiIcon = new MauiIcon() { Icon = MaterialIcons.AddComment, IconColor = Colors.LightYellow };
        var MauiIcon1 = new MauiIcon() { Icon = MaterialIcons.AddComment, IconColor = Colors.LightBlue };
        var MauiIcon2 = new MauiIcon() { Icon = MaterialIcons.AddComment, IconColor = Colors.LightSteelBlue };
        var MauiIcon3 = new Image() { Source = (ImageSource)new MauiIcon() { Icon = MaterialIcons.AddComment, IconColor = Colors.LimeGreen } };
        Label MauiIcon4 = (Label)new MauiIcon() { Icon = FluentIcons.Accessibility48, EntranceAnimationType = AnimationType.Rotate, IconSuffix = "New Suffix" };

        StackMaterialCodeBehind.Add(image);
        StackMaterialCodeBehind.Add(MauiIcon);
        StackMaterialCodeBehind.Add(MauiIcon1);
        StackMaterialCodeBehind.Add(MauiIcon2);
        StackMaterialCodeBehind.Add(MauiIcon3);
        StackMaterialCodeBehind.Add(MauiIcon4);
    }
}

