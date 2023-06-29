using MauiIcons.Material;

namespace MauiIcons.Sample;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        AddToStack();
    }

    void AddToStack()
    {
        var MauiIcon = new MauiIcon() { Icon = MaterialIcons.AddComment, IconColor = Colors.LightBlue, Variant = MaterialVariant.Rounded };
        var MauiIcon1 = new MauiIcon() { Icon = MaterialIcons.AddComment, IconColor = Colors.LightYellow, Variant = MaterialVariant.Outlined };
        var MauiIcon2 = new MauiIcon() { Icon = MaterialIcons.AddComment, IconColor = Colors.LightSteelBlue, Variant = MaterialVariant.Sharp };
        var MauiIcon3 = new MauiIcon() { Icon = MaterialIcons.AddComment, IconColor = Colors.LimeGreen, Variant = MaterialVariant.TwoTone };
        var MauiIcon4 = new MauiIcon() { Icon = MaterialIcons.AddComment, IconColor = Colors.Lime, Variant = MaterialVariant.Regular };
        StackMaterialCodeBehind.Add(MauiIcon);
        StackMaterialCodeBehind.Add(MauiIcon1);
        StackMaterialCodeBehind.Add(MauiIcon2);
        StackMaterialCodeBehind.Add(MauiIcon3);
        StackMaterialCodeBehind.Add(MauiIcon4);
    }
}

