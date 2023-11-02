using FluentAssertions;
using MauiIcons.Core;

namespace MauiIcons.Cupertino.UnitTest.Controls;
public class MauiIconTest : BaseHandlerTest
{
    public MauiIconTest()
    {
        Assert.IsAssignableFrom<IMauiIcon>(new MauiIcon());
    }

    [Fact]
    public void DefaultIconProperties()
    {
        // Arrange
        MauiIcon mauiiIcon;

        // Act
        mauiiIcon = new MauiIcon();

        // Assert
        mauiiIcon.Icon.Should().BeNull();
        mauiiIcon.IconColor.Should().Be(Colors.Black);
        mauiiIcon.IconBackgroundColor.Should().Be(Colors.Transparent);
        mauiiIcon.IconSize.Should().Be(30.0);
        mauiiIcon.IconAutoScaling.Should().BeFalse();
        mauiiIcon.IconSuffix.Should().BeNull();
        mauiiIcon.IconSuffixFontSize.Should().Be(20.0);
        mauiiIcon.IconSuffixFontFamily.Should().BeNull();
        mauiiIcon.IconSuffixTextColor.Should().BeNull();
        mauiiIcon.IconSuffixAutoScaling.Should().BeFalse();
        mauiiIcon.EntranceAnimationDuration.Should().Be((uint)1500);
        mauiiIcon.EntranceAnimationType.Should().Be(AnimationType.None);
    }

    [Fact]
    public void IconColor()
    {
        // Arrange
        var color = Colors.Red;

        // Act
        var icon = new MauiIcon()
        {
            IconColor = color
        };

        // Assert
        icon.IconColor.Should().NotBeNull();
    }
}
