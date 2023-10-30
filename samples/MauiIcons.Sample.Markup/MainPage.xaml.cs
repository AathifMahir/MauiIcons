using CommunityToolkit.Maui.Markup;
using MauiIcons.Core;
using MauiIcons.Cupertino;
using MauiIcons.Fluent;
using MauiIcons.Fluent.Filled;
using MauiIcons.Material;
using MauiIcons.Material.Outlined;
using MauiIcons.Material.Rounded;
using MauiIcons.Material.Sharp;

namespace MauiIcons.Sample.Markup;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        AddMarkup();
    }
    private void AddMarkup()
    {
        Content = new VerticalStackLayout()
        {

            Children =
            {
                new HorizontalStackLayout()
                {
                    Margin = new Thickness(0,12,0,12),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                         new MauiIcon().Icon(FluentIcons.Accessibility48).IconColor(Colors.Cyan),
                         new MauiIcon().Icon(FluentFilledIcons.Accessibility48Filled).IconColor(Colors.Green),
                         new MauiIcon().Icon(MaterialIcons.Accessibility).IconColor(Colors.Blue),
                         new MauiIcon().Icon(MaterialRoundedIcons.Accessibility).IconColor(Colors.Yellow),
                         new MauiIcon().Icon(MaterialOutlinedIcons.Accessibility).IconColor(Colors.Magenta),
                         new MauiIcon().Icon(MaterialSharpIcons.Accessibility).IconColor(Colors.Violet),
                         new MauiIcon().Icon(CupertinoIcons.AntFill).IconColor(Colors.Purple),
                         new ImageButton().Source((ImageSource)new MauiIcon().Icon(MaterialOutlinedIcons.SmokingRooms)),
                         
                    }
                }
            }

        };
    }


}

