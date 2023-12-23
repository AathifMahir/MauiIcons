using CommunityToolkit.Maui.Markup;
using MauiIcons.Core;
using MauiIcons.Cupertino;
using MauiIcons.Fluent;
using MauiIcons.Fluent.Filled;
using MauiIcons.FontAwesome;
using MauiIcons.FontAwesome.Brand;
using MauiIcons.Material;
using MauiIcons.Material.Outlined;
using MauiIcons.Material.Rounded;
using MauiIcons.Material.Sharp;

namespace MauiIcons.Sample;

public class MarkupPage : ContentPage
{
	public MarkupPage()
	{
        AddMarkup();
	}

    private void AddMarkup()
    {
        Label label;
        label = (Label)new MauiIcon().Icon(FluentFilledIcons.Alert28Filled).IconSuffix("Label Test").EntranceAnimationType(AnimationType.Rotate);
        Button button = (Button)new MauiIcon().Icon(FluentFilledIcons.Apps20Filled).IconSuffix("Test Button").IconSuffixFontSize(15);
        Image image;
        image = (Image)new MauiIcon().Icon(FluentFilledIcons.Apps20Filled).IconSuffix("Test Button").IconSuffixFontSize(15);
        Content = new VerticalStackLayout()
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new HorizontalStackLayout()
                {
                    Margin = new Thickness(0,12,0,12),
                    Spacing = 15,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                         new MauiIcon().Icon(FluentFilledIcons.Accessibility48Filled).IconColor(Colors.Cyan).OnIdioms(new List<string>{"Desktop"}).OnPlatforms(new List<string>{"Android"}),
                         new MauiIcon().Icon(FluentFilledIcons.Accessibility48Filled).IconColor(Colors.Green),
                         new MauiIcon().Icon(MaterialIcons.Accessibility).IconColor(Colors.Blue),
                         new MauiIcon().Icon(MaterialRoundedIcons.Accessibility).IconColor(Colors.Yellow),
                         new MauiIcon().Icon(MaterialOutlinedIcons.Accessibility).IconColor(Colors.Magenta),
                         new MauiIcon().Icon(MaterialSharpIcons.Accessibility).IconColor(Colors.Violet),
                    }
                },
                new HorizontalStackLayout()
                {
                    Margin = new Thickness(0,12,0,12),
                    Spacing = 15,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                         new MauiIcon().Icon(CupertinoIcons.AntFill).IconColor(Colors.Purple).IconSuffix("Background Color").IconSuffixTextColor(Colors.Purple).IconSuffixBackgroundColor(Colors.Green).IconBackgroundColor(Colors.Yellow).IconAndSuffixBackgroundColor(Colors.White),
                         new ImageButton().Icon(MaterialOutlinedIcons.SmokingRooms).OnIdioms(new List<string>{"Desktop"}).OnPlatforms(new List<string>{"WinUI"}),
                         new Image().Icon(FluentIcons.Accessibility24).IconColor(Colors.Pink).IconSize(50.0).OnPlatforms(new List<string>(){ "Android", "WinUI"}),
                         new Image().Icon(FluentIcons.Accessibility24),
                         new Image().Icon(MaterialIcons.AccessAlarm).IconSize(40.0),
                         new Label().Icon(FluentIcons.Accessibility24).IconSize(40.0),
                    }
                },
                new HorizontalStackLayout()
                {
                    Margin = new Thickness(0,12,0,12),
                    Spacing = 15,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                         new Entry().Icon(FluentIcons.Airplane20).IconSize(20.0),
                         new Button().Icon(CupertinoIcons.Alarm).IconSize(30),
                         new Button().Text("Test"),
                         label,
                         button,
                         image,
                         new Label().Icon(FluentIcons.Accessibility24).IconSize(40.0).IconColor(Colors.Pink).OnIdioms(new List<string>{"Desktop", "Phone"}).OnPlatforms(new List<string>{"WinUI", "MacCatalyst", "Android"}),
                    }
                },
                new HorizontalStackLayout ()
                {
                    Margin = new Thickness (0,12,0,12),
                    Spacing = 15,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new MauiIcon().Icon(FontAwesomeBrandIcons.Pinterest).IconColor(Colors.Red),
                        new Button().Icon(FontAwesomeBrandIcons.Github).IconSize(30),
                        new Entry().Icon(FontAwesomeIcons.Building).IconSize(20.0),
                    }
                }

            }

        };
    }
}