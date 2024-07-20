using MauiIcons.Core;
using MauiIcons.Cupertino;
using MauiIcons.FontAwesome.Brand;

namespace MauiIcons.Sample;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        // Temporary Workaround for url styled namespace in xaml
        _ = new MauiIcon();
        BindingContext = this;
    }

    private CupertinoIcons _icon = CupertinoIcons.Airplane;

    public CupertinoIcons MyIcon
    {
        get => _icon;
        set
        {
            if (value != _icon)
            {
                _icon = value;
                OnPropertyChanged();
            }
        }
    }

    private FontAwesomeBrandIcons _icon1 = FontAwesomeBrandIcons.Microsoft;

    public FontAwesomeBrandIcons MyIcon1 
    { 
        get => _icon1;
        set
        {
            if (value != _icon1)
            {
                _icon1 = value;
                OnPropertyChanged();
            }
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        MyIcon = MyIcon == CupertinoIcons.Airplane ? CupertinoIcons.Alarm : CupertinoIcons.Airplane;
        MyIcon1 = MyIcon1 == FontAwesomeBrandIcons.Microsoft ? FontAwesomeBrandIcons.Apple : FontAwesomeBrandIcons.Microsoft;
    }
}

