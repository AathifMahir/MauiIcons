using FluentAssertions;
using MauiIcons.Core;
using MauiIcons.Cupertino;
using MauiIcons.Fluent.Filled;

namespace MauiIcons.Modules.UnitTest.Extensions;
public class LabelMarkupExtensionTests : BaseHandlerTest
{
    [Fact]
    public void Icon()
    {
        // Arrange
        Label label;
        var icon = FluentFilledIcons.Accessibility16Filled;
        var iconCode = "\uF102";

        // Act
        label = new Label().Icon(icon);

        // Assert
        label.Text.Should().NotBeNull();
        label.Text.Should().Be(iconCode);
        label.FontFamily.Should().Be("FluentFilledIcons");
    }

    [Fact]
    public void IconChanged()
    {
        // Arrange
        Label label;
        bool changedSignaled = false;
        var assignedIcon = CupertinoIcons.Airplane;
        var assignedIconCode = "\ue900";

        // Act
        label = new Label();
        label.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "Text")
            {
                changedSignaled = true;
            }
        };
        label.Icon(assignedIcon);


        // Assert
        label.Text.Should().NotBeNull();
        label.Text.Should().Be(assignedIconCode);
        label.FontFamily.Should().Be("CupertinoIcons");
        changedSignaled.Should().BeTrue();
    }


    [Fact]
    public void IconColorChanged()
    {
        // Arrange
        Label label;
        bool changedSignaled = false;
        var assignedColor = Colors.Blue;

        // Act
        label = new Label();
        label.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "TextColor")
            {
                changedSignaled = true;
            }
        };
        label.IconColor(assignedColor);


        // Assert
        label.TextColor.Should().NotBeNull();
        label.TextColor.Should().Be(assignedColor);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconColorChangedToDefault()
    {
        // Arrange
        Label label;
        Color assignedColor = default!;

        // Act
        label = new Label().IconColor(Colors.Green);
        label.IconColor(assignedColor);


        // Assert
        label.TextColor.Should().BeNull();
    }


    [Fact]
    public void IconSizeChanged()
    {
        // Arrange
        Label label;
        bool changedSignaled = false;
        var assignedSize = 25.0;

        // Act
        label = new Label();
        label.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "FontSize")
            {
                changedSignaled = true;
            }
        };
        label.IconSize(assignedSize);


        // Assert
        label.FontSize.Should().Be(assignedSize);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconSizeChangedToDefault()
    {
        // Arrange
        Label label;
        var defaultSize = 30.0;
        var assignedSize = 40.0;

        // Act
        label = new Label().IconSize(assignedSize);
        label.IconSize(defaultSize);

        // Assert
        label.FontSize.Should().Be(defaultSize);
    }

    [Fact]
    public void IconBackgroundColorChanged()
    {
        // Arrange
        Label label;
        bool changedSignaled = false;
        var assignedColor = Colors.Blue;

        // Act
        label = new Label();
        label.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "BackgroundColor")
            {
                changedSignaled = true;
            }
        };
        label.IconBackgroundColor(assignedColor);


        // Assert
        label.BackgroundColor.Should().NotBeNull();
        label.BackgroundColor.Should().Be(assignedColor);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconBackgroundColorChangedToNull()
    {
        // Arrange
        Label label;
        Color assignedColor = null!;

        // Act
        label = new Label().IconBackgroundColor(Colors.Green);
        label.IconBackgroundColor(assignedColor);


        // Assert
        label.BackgroundColor.Should().BeNull();
    }

    
}
