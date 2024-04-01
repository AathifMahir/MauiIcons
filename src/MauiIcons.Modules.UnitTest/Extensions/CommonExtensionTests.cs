using MauiIcons.Fluent.Filled;
using MauiIcons.Cupertino;
using MauiIcons.Core;

namespace MauiIcons.Modules.UnitTest.Extensions;
public class CommonExtensionTests : BaseHandlerTest
{
    [Fact]
    public void Icon()
    {
        // Arrange
        Image image;
        var icon = FluentFilledIcons.Accessibility16Filled.ToImageSource();
        var iconCode = "\uF102";
        FontImageSource source;

        // Act
        image = new Image { Source = icon };
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
        var assignedIcon = CupertinoIcons.Airplane.ToImageSource();
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
        image.Source = assignedIcon;
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
        var assignedIcon = CupertinoIcons.Airplane.ToImageSource(iconColor: assignedColor);
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
        image.Source = assignedIcon;
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
        var assignedIcon = CupertinoIcons.Airplane.ToImageSource();
        var assignedColoredIcon = CupertinoIcons.Airplane.ToImageSource(iconColor: Colors.Green);
        FontImageSource source;

        // Act
        image = new Image { Source = assignedColoredIcon };
        image.Source = assignedIcon;
        source = (FontImageSource)image.Source;


        // Assert
        image.Source.Should().NotBeNull();
        source.Color.Should().Be(Colors.Black);
    }


    [Fact]
    public void IconSizeChanged()
    {
        // Arrange
        Image image;
        bool changedSignaled = false;
        var assignedSize = 25.0;
        var assignedIcon = CupertinoIcons.Airplane.ToImageSource(iconSize: assignedSize);
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
        image.Source = assignedIcon;
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
        var defaultIcon = CupertinoIcons.Airplane.ToImageSource();
        var assignedIcon = CupertinoIcons.Airplane.ToImageSource(iconSize: 40);
        FontImageSource source;

        // Act
        image = new Image { Source = assignedIcon };
        image.Source = defaultIcon;
        source = (FontImageSource)image.Source;

        // Assert
        image.Source.Should().NotBeNull();
        source.Size.Should().Be(defaultSize);
    }
}
