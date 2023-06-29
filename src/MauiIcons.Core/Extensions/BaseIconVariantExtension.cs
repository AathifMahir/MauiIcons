using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiIcons.Core;
public abstract class BaseIconVariantExtension : BaseIconExtension, INotifyPropertyChanged
{
    Enum _variant;
    public virtual Enum Variant 
    {
        get => _variant;
        set
        {
            if (value != _variant)
            {
                _variant = value;
                IconFontFamily = GetVariantFontFamily(value);
                OnPropertyChanged();
            }
        }
    }
    protected abstract Dictionary<Enum, string> VariantType { get; set; }

    string _iconFontFamily;
    protected override string IconFontFamily 
    {
        get => _iconFontFamily; 
        set
        {
            if (value != _iconFontFamily)
            {
                _iconFontFamily = value;
                OnPropertyChanged();
            }
        } 
    }

    string GetVariantFontFamily(Enum variant)
    {
        if (variant is null || VariantType is null) return string.Empty;
        if (VariantType.ContainsKey(variant) && VariantType.TryGetValue(variant, out string fontFamily)) return fontFamily;
        return Icon.GetType().Name;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
