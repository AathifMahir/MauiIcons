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
                IconFontFamily = NotifyVariantChanges();
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

    public string NotifyVariantChanges()
    {
        if (VariantType is null) return default;
        if (!VariantType.ContainsKey(Variant)) return default;
        VariantType.TryGetValue(Variant, out string fontFamily);
        return fontFamily;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
