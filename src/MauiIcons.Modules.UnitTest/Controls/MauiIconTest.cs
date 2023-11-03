using FluentAssertions;
using MauiIcons.Core;
using MauiIcons.Cupertino;
using MauiIcons.Material;

namespace MauiIcons.Modules.UnitTest.Controls;
public class MauiIconTest : BaseHandlerTest
{
    public MauiIconTest()
    {
        Assert.IsAssignableFrom<IMauiIcon>(new MauiIcon());
    }

    [Fact]
    public void DefaultIcon()
    {
        // Arrange
        MauiIcon mi;

        // Act
        mi = new MauiIcon();

        // Assert
        mi.Icon.Should().BeNull();
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
        mauiiIcon.EntranceAnimationDuration.Should().Be(1500);
        mauiiIcon.EntranceAnimationType.Should().Be(AnimationType.None);
    }

    [Fact]
    public void IconChanged()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var assignedIcon = CupertinoIcons.Airplane;

        // Act
        mauiiIcon = new MauiIcon();
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "Icon")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.Icon = assignedIcon;


        // Assert
        mauiiIcon.Icon.Should().NotBeNull();
        mauiiIcon.Icon.Should().Be(assignedIcon);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconChangedToNull()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;

        // Act
        mauiiIcon = new MauiIcon() { Icon = CupertinoIcons.Airplane };
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "Icon")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.Icon = null;

        // Assert
        mauiiIcon.Icon.Should().BeNull();
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconChangedToNewIcon()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var newIcon = CupertinoIcons.ZoomIn;

        // Act
        mauiiIcon = new MauiIcon() { Icon = CupertinoIcons.Airplane };
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "Icon")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.Icon = newIcon;

        // Assert
        mauiiIcon.Icon.Should().NotBeNull();
        mauiiIcon.Icon.Should().Be(newIcon);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconChangedToNewIconFromDifferentEnumeration()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var newIcon = MaterialIcons.ZoomIn;

        // Act
        mauiiIcon = new MauiIcon() { Icon = CupertinoIcons.Airplane };
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "Icon")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.Icon = newIcon;

        // Assert
        mauiiIcon.Icon.Should().NotBeNull();
        mauiiIcon.Icon.Should().Be(newIcon);
        changedSignaled.Should().BeTrue();
    }
}
