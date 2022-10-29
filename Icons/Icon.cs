using System.ComponentModel;
using System.Diagnostics;

namespace Maui.Icons;

[TypeConverter(typeof(Converters.IconTypeConverter))]
public sealed class Icon
{
    public readonly string IconUri;

    public Icon()
    {
        IconUri = string.Empty;
    }
    public Icon(string icon)
    {
        IconUri = icon;
    }

    public override string ToString()
    {
        return IconUri;
    }

    public static Icon Parse(string value)
    {
        //return new Icon(icon);
        if (TryParse(value, out var c) && c != default)
            return c;

        throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Icon)}");
    }

    public static bool TryParse(string value, out Icon icon) => TryParse(value != null ? value.AsSpan() : default, out icon);

    private static bool TryParse(ReadOnlySpan<char> value, out Icon icon)
    {
        value.Trim();
        if (!value.IsEmpty)
        {
            if (value[0] != '.' || value[0] != 'u')
            {
                
                    var namedIcons = GetNamedFluentIcons(value);
                    if (namedIcons != null)
                    {
                        icon = namedIcons;
                        return true;
                    }
                icon = default;
                return false;
            }

            icon = value.ToString();
            return true;
        }
        icon = default;
        return false;
    }

    static Icon GetNamedFluentIcons(ReadOnlySpan<char> value)
    {
        Span<char> loweredValue = value.Length <= 128 ? stackalloc char[value.Length] : new char[value.Length];

        int charsWritten = value.ToLowerInvariant(loweredValue);
        Debug.Assert(charsWritten == value.Length);

        // this should use the C# feature https://github.com/dotnet/csharplang/issues/1881, when it is available
        // for now, we need to allocate the lowered string
        return loweredValue.ToString() switch
        {
            "default" => default,
            "globalnavbutton" => TestIcons.GlobalNavButton,
            "wifi" => TestIcons.Wifi,
            "bluetooth" => TestIcons.Bluetooth,
            "connect" => TestIcons.Connect,
            "internetsharing" => TestIcons.InternetSharing,
            "vpn" => TestIcons.VPN,
            "brightness" => TestIcons.Brightness,
            _ => null
        };
    }

    public static implicit operator Icon(string icon) => new(icon);
}
