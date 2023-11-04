using FluentAssertions;
using MauiIcons.Core;
using MauiIcons.Fluent.Filled;
using MauiIcons.Cupertino;

namespace MauiIcons.Modules.UnitTest.Extensions;
public class MauiIconMarkupExtensionTests : BaseHandlerTest
{
    [Fact]
    public void Icon()
    {
		// Arrange
		MauiIcon mauiIcon;
		var icon = FluentFilledIcons.Accessibility16Filled;

		// Act
		mauiIcon = new MauiIcon().Icon(icon);

		// Assert
		mauiIcon.Icon.Should().NotBeNull();
		mauiIcon.Icon.Should().Be(icon);
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
        mauiiIcon.Icon(assignedIcon);


        // Assert
        mauiiIcon.Icon.Should().NotBeNull();
        mauiiIcon.Icon.Should().Be(assignedIcon);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconChangedToDifferentEnumerationThatDontHaveIconCode()
    {
        // Arrange
        MauiIcon mauiiIcon;
        var newIcon = EnumTest.Two;

        // Act
        mauiiIcon = new MauiIcon().Icon(CupertinoIcons.Airplane);
        mauiiIcon.Icon(newIcon);

        // Assert
        mauiiIcon.Icon.Should().NotBeNull();
        mauiiIcon.Icon.Should().Be(newIcon);
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
        mauiiIcon.IconColor(assignedColor);


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
        mauiiIcon = new MauiIcon().IconColor(Colors.Green);
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
        mauiiIcon.IconSize(assignedSize);


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
        mauiiIcon = new MauiIcon().IconSize(assignedSize);
        mauiiIcon.IconSize(defaultSize);

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
        mauiiIcon.IconBackgroundColor(assignedColor);


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
        mauiiIcon = new MauiIcon().IconBackgroundColor(Colors.Green);
        mauiiIcon.IconBackgroundColor(assignedColor);


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
        mauiiIcon.IconAndSuffixBackgroundColor(assignedColor);


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
        mauiiIcon = new MauiIcon().IconAndSuffixBackgroundColor(Colors.Green);
        mauiiIcon.IconAndSuffixBackgroundColor(assignedColor);


        // Assert
        mauiiIcon.BackgroundColor.Should().BeNull();
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
        mauiiIcon.IconAutoScaling(autoScale);


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
        mauiiIcon = new MauiIcon().IconAutoScaling(true);
        mauiiIcon.IconAutoScaling(autoScale);


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
        mauiiIcon.IconSuffix(suffix);


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
        mauiiIcon = new MauiIcon().IconSuffix(suffix);
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
        mauiiIcon.IconSuffixFontFamily(suffixFontFamily);


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
        mauiiIcon = new MauiIcon().IconSuffixFontFamily(suffixFontFamily);
        mauiiIcon.IconSuffixFontFamily(null);


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
        mauiiIcon.IconSuffixFontSize(assignedSize);


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
        mauiiIcon = new MauiIcon().IconSuffixFontSize(assignedSize);
        mauiiIcon.IconSuffixFontSize(defaultSize);

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
        mauiiIcon.IconSuffixTextColor(assignedColor);


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
        mauiiIcon = new MauiIcon().IconSuffixTextColor(Colors.Green);
        mauiiIcon.IconSuffixTextColor(assignedColor);


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
        mauiiIcon.IconSuffixBackgroundColor(assignedColor);


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
        mauiiIcon = new MauiIcon().IconSuffixBackgroundColor(Colors.Green);
        mauiiIcon.IconSuffixBackgroundColor(assignedColor);

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
        mauiiIcon.IconSuffixAutoScaling(autoScale);


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
        mauiiIcon = new MauiIcon().IconSuffixAutoScaling(true);
        mauiiIcon.IconSuffixAutoScaling(autoScale);


        // Assert
        mauiiIcon.IconSuffixAutoScaling.Should().Be(autoScale);
    }
}
