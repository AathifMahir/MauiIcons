using System.ComponentModel;
using System.Globalization;

namespace Maui.Icons.Converters;
public sealed class IconTypeConverter : TypeConverter
{
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object fromValue)
    {
        return Icon.Parse(fromValue?.ToString());
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (value is not Icon icon || icon == null)
            throw new NotSupportedException();

        return icon;
    }
    //public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    //    => new(new[]
    //    {
    //             "GlobalNavButton",
    //        "Wifi",
    //"Bluetooth",
    //"Connect",
    //"InternetSharing",
    //"VPN",
    //"Brightness",
    //"MapPin",
    //"QuietHours",
    //"Airplane",
    //"Tablet",
    //"QuickNote",
    //"RememberedDevice",
    //"ChevronDown",
    //"ChevronUp",
    //"Edit",
    //"Add",
    //"Cancel",
    //"More",
    //"Settings",
    //"Video",
    //"Mail",
    //"People",
    //"Phone",
    //"Pin",
    //"Shop",
    //"Stop",
    //"Link",
    //"Filter",
    //"AllApps",
    //"Zoom",
    //"ZoomOut",
    //"Microphone",
    //"Search",
    //"Camera",
    //"Attach",
    //"Send",
    //"SendFill",
    //"WalkSolid",
    //"InPrivate",
    //"FavoriteList",
    //"PageSolid",
    //"Forward",
    //"Back",
    //"Refresh",
    //"Share",
    //"Lock",
    //"ReportHacked",
    //"EMI",
    //"FavoriteStar",
    //"FavoriteStarFill",
    //"ReadingMode",
    //"Favicon",
    //"Remove",
    //"Checkbox",
    //"CheckboxComposite",
    //"CheckboxFill",
    //"CheckboxIndeterminate",
    //"CheckboxCompositeReversed",
    //"CheckMark",
    //"BackToWindow",
    //"FullScreen",
    //"ResizeTouchLarger",
    //"ResizeTouchSmaller",
    //"ResizeMouseSmall",
    //"ResizeMouseMedium",
    //"ResizeMouseWide",
    //"ResizeMouseTall",
    //"ResizeMouseLarge",
    //"SwitchUser",
    //"Print",
    //"Up",
    //"Down",
    //"OEM",
    //"Delete",
    //"Save",
    //"Mute",
    //"BackSpaceQWERTY",
    //"ReturnKey",
    //"UpArrowShiftKey",
    //"Cloud",
    //"Flashlight",
    //"RotationLock",
    //"CommandPrompt",
    //"SIPMove",
    //"SIPUndock",
    //"SIPRedock",
    //"EraseTool",
    //"UnderscoreSpace",
    //"GripperTool",
    //"Dialpad",
    //"PageLeft",
    //"PageRight",
    //"MultiSelect",
    //"KeyboardLeftHanded",
    //"KeyboardRightHanded",
    //"KeyboardClassic",
    //"KeyboardSplit",
    //"Volume",
    //"Play",
    //"Pause",
    //"ChevronLeft",
    //"ChevronRight",
    //"InkingTool",
    //    });

    public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        => false;

    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        => true;

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        => sourceType == typeof(string);

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        => destinationType == typeof(string);
}
