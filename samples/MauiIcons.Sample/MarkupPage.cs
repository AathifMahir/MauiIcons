using CommunityToolkit.Maui.Markup;
using MauiIcons.Core;
using MauiIcons.Cupertino;
using MauiIcons.Fluent;
using MauiIcons.Fluent.Filled;
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
        label = (Label)new MauiIcon().Icon(FluentFilledIcons.Alert28Filled).IconSuffix("Label Test").IconColor(Colors.Magenta).EntranceAnimationType(AnimationType.Rotate);
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
                    Children =
                    {
                         new MauiIcon().Icon(FluentFilledIcons.Accessibility48Filled).IconColor(Colors.Cyan),
                         new MauiIcon().Icon(FluentFilledIcons.Accessibility48Filled).IconColor(Colors.Green),
                         new MauiIcon().Icon(MaterialIcons.Accessibility).IconColor(Colors.Blue),
                         new MauiIcon().Icon(MaterialRoundedIcons.Accessibility).IconColor(Colors.Yellow),
                         new MauiIcon().Icon(MaterialOutlinedIcons.Accessibility).IconColor(Colors.Magenta),
                         new MauiIcon().Icon(MaterialSharpIcons.Accessibility).IconColor(Colors.Violet),
                         new MauiIcon().Icon(CupertinoIcons.AntFill).IconColor(Colors.Purple).IconSuffix("Background Color").IconSuffixTextColor(Colors.Purple).IconSuffixBackgroundColor(Colors.Green).IconBackgroundColor(Colors.Yellow).IconAndSuffixBackgroundColor(Colors.White),
                         new ImageButton().Icon(MaterialOutlinedIcons.SmokingRooms),
                         new Image().Icon(FluentIcons.Accessibility24),
                         new Image().Icon(FluentIcons.Accessibility24).IconColor(Colors.Blue),
                         new Image().Icon(MaterialIcons.AccessAlarm).IconSize(40.0).IconColor(Colors.Cyan).IconBackgroundColor(Colors.White),
                         new Label().Icon(FluentIcons.Accessibility24).IconSize(40.0).IconColor(Colors.Red),
                         label,
                         new Entry().Icon(FluentIcons.Airplane20).IconSize(20.0).IconColor(Colors.Aqua),
                         new Button().Icon(CupertinoIcons.Alarm).IconSize(30).BackgroundColor(default),
                         new Button().Text("Test"),

                    }
                }
            }

        };
    }
}