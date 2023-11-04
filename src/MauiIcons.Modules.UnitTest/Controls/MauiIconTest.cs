using FluentAssertions;
using MauiIcons.Core;
using MauiIcons.Cupertino;
using MauiIcons.Material;

namespace MauiIcons.Modules.UnitTest.Controls;
public class MauiIconTest : BaseHandlerTest
{
    
    [Fact]
    public void ShouldBeAssignedToIMauiIcon()
    {
        Assert.IsAssignableFrom<IMauiIcon>(new MauiIcon());
    }

    [Fact]
    public void DefaultProperties()
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
        mauiiIcon.IconSuffixBackgroundColor.Should().BeNull();
        mauiiIcon.IconSuffixAutoScaling.Should().BeFalse();
        mauiiIcon.EntranceAnimationDuration.Should().Be(1500);
        mauiiIcon.EntranceAnimationType.Should().Be(AnimationType.None);
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

        // Act
        mauiiIcon = new MauiIcon() { Icon = CupertinoIcons.Airplane };
        mauiiIcon.Icon = null;

        // Assert
        mauiiIcon.Icon.Should().BeNull();
    }


    [Fact]
    public void IconChangedToDifferentEnumeration()
    {
        // Arrange
        MauiIcon mauiiIcon;
        var newIcon = MaterialIcons.ZoomIn;

        // Act
        mauiiIcon = new MauiIcon() { Icon = CupertinoIcons.Airplane };
        mauiiIcon.Icon = newIcon;

        // Assert
        mauiiIcon.Icon.Should().NotBeNull();
        mauiiIcon.Icon.Should().Be(newIcon);
    }

    [Fact]
    public void IconChangedToDifferentEnumerationThatDontHaveIconCode()
    {
        // Arrange
        MauiIcon mauiiIcon;
        var newIcon = EnumTest.Two;

        // Act
        mauiiIcon = new MauiIcon() { Icon = CupertinoIcons.Airplane };
        mauiiIcon.Icon = newIcon;

        // Assert
        mauiiIcon.Icon.Should().NotBeNull();
        mauiiIcon.Icon.Should().Be(newIcon);
    }

    [Fact]
    public void CastingToLabel()
    {
        // Arrange
        Label label;

        // Act
        label = (Label)new MauiIcon() { Icon = CupertinoIcons.Airplane };

        // Assert
        label.FormattedText.Should().NotBeNull();
        label.FormattedText.Spans[0].Should().NotBeNull();
        label.FormattedText.Spans[0].Text.Should().NotBeNull();
        label.FormattedText.Spans[0].Text.Should().Be("\ue900");
        label.FormattedText.Spans[0].FontFamily.Should().NotBeNull();
        label.FormattedText.Spans[0].FontFamily.Should().Be("CupertinoIcons");
    }

    [Fact]
    public void CastingLabelSpacer()
    {
        // Arrange
        Label label;

        // Act
        label = (Label)new MauiIcon() { Icon = CupertinoIcons.Airplane };

        // Assert
        label.FormattedText.Should().NotBeNull();
        label.FormattedText.Spans[1].Should().NotBeNull();
        label.FormattedText.Spans[1].Text.Should().NotBeNull();
        label.FormattedText.Spans[1].Text.Should().Be(" ");
    }

    [Fact]
    public void CastingToLabelWithSuffixProperties()
    {
        // Arrange
        Label label;
        string iconSuffixText = "Suffix Test";
        var iconSuffixTextColor = Colors.Green;
        var iconSuffixBackgroundColor = Colors.DarkBlue;
        var iconSuffixFontFamily = "OpenSansSemibold";
        var iconSuffixFontSize = 35.0;

        // Act
        label = (Label)new MauiIcon() { Icon = CupertinoIcons.Airplane, IconSuffix = iconSuffixText, 
            IconSuffixTextColor = iconSuffixTextColor, IconSuffixBackgroundColor = iconSuffixBackgroundColor, 
            IconSuffixFontSize = iconSuffixFontSize, IconSuffixFontFamily = iconSuffixFontFamily };

        // Assert
        label.FormattedText.Should().NotBeNull();
        label.FormattedText.Spans[2].Should().NotBeNull();
        label.FormattedText.Spans[2].Text.Should().NotBeNull();
        label.FormattedText.Spans[2].Text.Should().Be(iconSuffixText);
        label.FormattedText.Spans[2].TextColor.Should().Be(iconSuffixTextColor);
        label.FormattedText.Spans[2].BackgroundColor.Should().Be(iconSuffixBackgroundColor);
        label.FormattedText.Spans[2].FontSize.Should().Be(iconSuffixFontSize);
        label.FormattedText.Spans[2].FontFamily.Should().Be(iconSuffixFontFamily);
    }

    [Fact]
    public void IconColorChanged()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var assignedColor = Colors.Blue;

        // Act
        mauiiIcon = new MauiIcon();
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "IconColor")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.IconColor = assignedColor;


        // Assert
        mauiiIcon.IconColor.Should().NotBeNull();
        mauiiIcon.IconColor.Should().Be(assignedColor);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconColorChangedToDefault()
    {
        // Arrange
        MauiIcon mauiiIcon;
        Color assignedColor = default!;

        // Act
        mauiiIcon = new MauiIcon() { IconColor =  Colors.Green };
        mauiiIcon.IconColor = assignedColor;


        // Assert
        mauiiIcon.IconColor.Should().BeNull();
    }


    [Fact]
    public void IconSizeChanged()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var assignedSize = 25.0;

        // Act
        mauiiIcon = new MauiIcon();
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "IconSize")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.IconSize = assignedSize;


        // Assert
        mauiiIcon.IconSize.Should().Be(assignedSize);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconSizeChangedToDefault()
    {
        // Arrange
        MauiIcon mauiiIcon;
        var defaultSize = 30.0;
        var assignedSize = 40.0;

        // Act
        mauiiIcon = new MauiIcon() { IconSize = assignedSize };
        mauiiIcon.IconSize = defaultSize;

        // Assert
        mauiiIcon.IconSize.Should().NotBe(assignedSize);
        mauiiIcon.IconSize.Should().Be(defaultSize);
    }

    [Fact]
    public void IconBackgroundColorChanged()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var assignedColor = Colors.Blue;

        // Act
        mauiiIcon = new MauiIcon();
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "IconBackgroundColor")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.IconBackgroundColor = assignedColor;


        // Assert
        mauiiIcon.IconBackgroundColor.Should().NotBeNull();
        mauiiIcon.IconBackgroundColor.Should().Be(assignedColor);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconBackgroundColorChangedToNull()
    {
        // Arrange
        MauiIcon mauiiIcon;
        Color assignedColor = null!;

        // Act
        mauiiIcon = new MauiIcon() { IconBackgroundColor = Colors.Green };
        mauiiIcon.IconBackgroundColor = assignedColor;


        // Assert
        mauiiIcon.IconBackgroundColor.Should().BeNull();
    }

    [Fact]
    public void IconAndSuffixBackgroundColorChanged()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var assignedColor = Colors.Blue;

        // Act
        mauiiIcon = new MauiIcon();
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "IconAndSuffixBackgroundColor")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.IconAndSuffixBackgroundColor = assignedColor;


        // Assert
        mauiiIcon.IconAndSuffixBackgroundColor.Should().NotBeNull();
        mauiiIcon.IconAndSuffixBackgroundColor.Should().Be(assignedColor);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconAndSuffixBackgroundColorChangedToNull()
    {
        // Arrange
        MauiIcon mauiiIcon;
        Color assignedColor = null!;

        // Act
        mauiiIcon = new MauiIcon() { IconAndSuffixBackgroundColor = Colors.Green };
        mauiiIcon.IconAndSuffixBackgroundColor = assignedColor;


        // Assert
        mauiiIcon.IconAndSuffixBackgroundColor.Should().BeNull();
    }

    [Fact]
    public void IconAutoScalingChanged()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var autoScale = true;

        // Act
        mauiiIcon = new MauiIcon();
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "IconAutoScaling")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.IconAutoScaling = autoScale;


        // Assert
        mauiiIcon.IconAutoScaling.Should().Be(autoScale);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconAutoScalingChangedToFalse()
    {
        // Arrange
        MauiIcon mauiiIcon;
        var autoScale = false;

        // Act
        mauiiIcon = new MauiIcon() { IconAutoScaling = true };
        mauiiIcon.IconAutoScaling = autoScale;


        // Assert
        mauiiIcon.IconAutoScaling.Should().Be(autoScale);
    }

    [Fact]
    public void IconSuffixChanged()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var suffix = "Test";

        // Act
        mauiiIcon = new MauiIcon();
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "IconSuffix")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.IconSuffix = suffix;


        // Assert
        mauiiIcon.IconSuffix.Should().Be(suffix);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconSuffixChangedToNull()
    {
        // Arrange
        MauiIcon mauiiIcon;
        var suffix = "Test";

        // Act
        mauiiIcon = new MauiIcon() { IconSuffix = suffix };
        mauiiIcon.IconSuffix = null;


        // Assert
        mauiiIcon.IconSuffix.Should().BeNull();
    }

    [Fact]
    public void IconFontFamilyChanged()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var suffixFontFamily = "OpenSansRegular";

        // Act
        mauiiIcon = new MauiIcon();
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "IconSuffixFontFamily")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.IconSuffixFontFamily = suffixFontFamily;


        // Assert
        mauiiIcon.IconSuffixFontFamily.Should().Be(suffixFontFamily);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconFontFamilyChangedToNull()
    {
        // Arrange
        MauiIcon mauiiIcon;
        var suffixFontFamily = "OpenSansRegular";

        // Act
        mauiiIcon = new MauiIcon() { IconSuffixFontFamily = suffixFontFamily };
        mauiiIcon.IconSuffixFontFamily = null;


        // Assert
        mauiiIcon.IconSuffixFontFamily.Should().BeNull();
    }

    [Fact]
    public void IconSuffixFontSizeChanged()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var assignedSize = 25.0;

        // Act
        mauiiIcon = new MauiIcon();
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "IconSuffixFontSize")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.IconSuffixFontSize = assignedSize;


        // Assert
        mauiiIcon.IconSuffixFontSize.Should().Be(assignedSize);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconSuffixFontSizeChangedToDefault()
    {
        // Arrange
        MauiIcon mauiiIcon;
        var defaultSize = 20.0;
        var assignedSize = 40.0;

        // Act
        mauiiIcon = new MauiIcon() { IconSuffixFontSize = assignedSize };
        mauiiIcon.IconSuffixFontSize = defaultSize;

        // Assert
        mauiiIcon.IconSuffixFontSize.Should().NotBe(assignedSize);
        mauiiIcon.IconSuffixFontSize.Should().Be(defaultSize);
    }

    [Fact]
    public void IconSuffixTextColorChanged()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var assignedColor = Colors.Blue;

        // Act
        mauiiIcon = new MauiIcon();
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "IconSuffixTextColor")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.IconSuffixTextColor = assignedColor;


        // Assert
        mauiiIcon.IconSuffixTextColor.Should().NotBeNull();
        mauiiIcon.IconSuffixTextColor.Should().Be(assignedColor);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconSuffixTextColorChangedToNull()
    {
        // Arrange
        MauiIcon mauiiIcon;
        Color assignedColor = null!;

        // Act
        mauiiIcon = new MauiIcon() { IconSuffixTextColor = Colors.Green };
        mauiiIcon.IconSuffixTextColor = assignedColor;


        // Assert
        mauiiIcon.IconSuffixTextColor.Should().BeNull();
    }

    [Fact]
    public void IconSuffixBackgroundColorChanged()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var assignedColor = Colors.Blue;

        // Act
        mauiiIcon = new MauiIcon();
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "IconSuffixBackgroundColor")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.IconSuffixBackgroundColor = assignedColor;


        // Assert
        mauiiIcon.IconSuffixBackgroundColor.Should().NotBeNull();
        mauiiIcon.IconSuffixBackgroundColor.Should().Be(assignedColor);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconSuffixBackgroundColorChangedToNull()
    {
        // Arrange
        MauiIcon mauiiIcon;
        Color assignedColor = null!;

        // Act
        mauiiIcon = new MauiIcon() { IconSuffixBackgroundColor = Colors.Green };
        mauiiIcon.IconSuffixBackgroundColor = assignedColor;

        // Assert
        mauiiIcon.IconSuffixBackgroundColor.Should().BeNull();
    }

    [Fact]
    public void IconSuffixAutoScalingChanged()
    {
        // Arrange
        MauiIcon mauiiIcon;
        bool changedSignaled = false;
        var autoScale = true;

        // Act
        mauiiIcon = new MauiIcon();
        mauiiIcon.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "IconSuffixAutoScaling")
            {
                changedSignaled = true;
            }
        };
        mauiiIcon.IconSuffixAutoScaling = autoScale;


        // Assert
        mauiiIcon.IconSuffixAutoScaling.Should().Be(autoScale);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconSuffixAutoScalingChangedToFalse()
    {
        // Arrange
        MauiIcon mauiiIcon;
        var autoScale = false;

        // Act
        mauiiIcon = new MauiIcon() { IconSuffixAutoScaling = true };
        mauiiIcon.IconSuffixAutoScaling = autoScale;


        // Assert
        mauiiIcon.IconSuffixAutoScaling.Should().Be(autoScale);
    }
}
