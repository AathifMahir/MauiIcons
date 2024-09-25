using MauiIcons.Core;
using MauiIcons.Cupertino;
using MauiIcons.FontAwesome.Brand;

namespace MauiIcons.Sample;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
        // Temporary Workaround for url styled namespace in xaml
        _ = new MauiIcon();

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

    private Color _labelColor = Colors.Coral;
    public Color MyLabelColor
    {
        get => _labelColor;
        set
        {
            if (value != _labelColor)
            {
                _labelColor = value;
                OnPropertyChanged();
            }
        }
    }

    bool _isPlaceHolder = true;
    public bool IsPlaceHolder
    {
        get => _isPlaceHolder;
        set
        {
            if (value != _isPlaceHolder)
            {
                _isPlaceHolder = value;
                OnPropertyChanged();
            }
        }
    }

    IList<string> _onPlatforms = ["WinUI", "Android"];
    public IList<string> OnPlatforms
    {
        get => _onPlatforms;
        set
        {
            if (value != _onPlatforms)
            {
                _onPlatforms = value;
                OnPropertyChanged();
            }
        }
    }

    IList<string> _onIdioms = ["Desktop", "Mobile"];
    public IList<string> OnIdioms
    {
        get => _onIdioms;
        set
        {
            if (value != _onIdioms)
            {
                _onIdioms = value;
                OnPropertyChanged();
            }
        }
    }

    private string _myPlaceHolder = "This is a Placeholder";

    public string MyPlaceHolder
    {
        get => _myPlaceHolder;
        set
        {
            if (value != _myPlaceHolder)
            {
                _myPlaceHolder = value;
                OnPropertyChanged();
            }
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        MyIcon = MyIcon == CupertinoIcons.Airplane ? CupertinoIcons.Alarm : CupertinoIcons.Airplane;
        MyIcon1 = MyIcon1 == FontAwesomeBrandIcons.Microsoft ? FontAwesomeBrandIcons.Apple : FontAwesomeBrandIcons.Microsoft;
        MyLabelColor = MyLabelColor == Colors.Coral ? Colors.Blue : Colors.Coral;
        IsPlaceHolder = !IsPlaceHolder;
        OnPlatforms = OnPlatforms.Contains("WinUI") ? ["Android"] : ["WinUI", "Android"];
        OnIdioms = OnIdioms.Contains("Desktop") ? ["Mobile"] : ["Desktop", "Mobile"];
        MyPlaceHolder = MyPlaceHolder == "This is a Placeholder" ? "This is a New Placeholder" : "This is a Placeholder";
    }
}

