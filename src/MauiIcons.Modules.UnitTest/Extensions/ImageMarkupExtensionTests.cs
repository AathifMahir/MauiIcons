using MauiIcons.Core;
using MauiIcons.Cupertino;
using MauiIcons.Fluent.Filled;

namespace MauiIcons.Modules.UnitTest.Extensions;
public class ImageMarkupExtensionTests : BaseHandlerTest
{
    [Fact]
    public void Icon()
    {
        // Arrange
        Image image;
        var icon = FluentFilledIcons.Accessibility16Filled;
        var iconCode = "\uF102";
        FontImageSource source;

        // Act
        image = new Image().Icon(icon);
        source = (FontImageSource)image.Source;

        // Assert
        image.Source.Should().NotBeNull();
        source.Glyph.Should().Be(iconCode);
        source.FontFamily.Should().Be("FluentFilledIcons");
    }

    [Fact]
    public void IconChanged()
    {
        // Arrange
        Image image;
        bool changedSignaled = false;
        var assignedIcon = CupertinoIcons.Airplane;
        var assignedIconCode = "\ue900";
        FontImageSource source;

        // Act
        image = new Image();
        image.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "Source")
            {
                changedSignaled = true;
            }
        };
        image.Icon(assignedIcon);
        source = (FontImageSource)image.Source;


        // Assert
        image.Source.Should().NotBeNull();
        source.Glyph.Should().Be(assignedIconCode);
        source.FontFamily.Should().Be("CupertinoIcons");
        changedSignaled.Should().BeTrue();
    }


    [Fact]
    public void IconColorChanged()
    {
        // Arrange
        Image image;
        bool changedSignaled = false;
        var assignedColor = Colors.Blue;
        FontImageSource source;

        // Act
        image = new Image();
        image.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "Source")
            {
                changedSignaled = true;
            }
        };
        image.IconColor(assignedColor);
        source = (FontImageSource)image.Source;

        // Assert
        image.Source.Should().NotBeNull();
        source.Color.Should().Be(assignedColor);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconColorChangedToDefault()
    {
        // Arrange
        Image image;
        Color assignedColor = default!;
        FontImageSource source;

        // Act
        image = new Image().IconColor(Colors.Green);
        image.IconColor(assignedColor);
        source = (FontImageSource)image.Source;


        // Assert
        image.Source.Should().NotBeNull();
        source.Color.Should().BeNull();
    }


    [Fact]
    public void IconSizeChanged()
    {
        // Arrange
        Image image;
        bool changedSignaled = false;
        var assignedSize = 25.0;
        FontImageSource source;

        // Act
        image = new Image();
        image.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "Source")
            {
                changedSignaled = true;
            }
        };
        image.IconSize(assignedSize);
        source = (FontImageSource)image.Source;


        // Assert
        image.Source.Should().NotBeNull();
        source.Size.Should().Be(assignedSize);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconSizeChangedToDefault()
    {
        // Arrange
        Image image;
        var defaultSize = 30.0;
        FontImageSource source;

        // Act
        image = new Image().IconSize(40.0);
        image.IconSize(defaultSize);
        source = (FontImageSource)image.Source;

        // Assert
        image.Source.Should().NotBeNull();
        source.Size.Should().Be(defaultSize);
    }

    [Fact]
    public void IconBackgroundColorChanged()
    {
        // Arrange
        Image image;
        bool changedSignaled = false;
        var assignedColor = Colors.Blue;

        // Act
        image = new Image();
        image.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "BackgroundColor")
            {
                changedSignaled = true;
            }
        };
        image.IconBackgroundColor(assignedColor);


        // Assert
        image.BackgroundColor.Should().NotBeNull();
        image.BackgroundColor.Should().Be(assignedColor);
        changedSignaled.Should().BeTrue();
    }

    [Fact]
    public void IconBackgroundColorChangedToNull()
    {
        // Arrange
        Image image;
        Color assignedColor = null!;

        // Act
        image = new Image().IconBackgroundColor(Colors.Green);
        image.IconBackgroundColor(assignedColor);


        // Assert
        image.BackgroundColor.Should().BeNull();
    }
}
