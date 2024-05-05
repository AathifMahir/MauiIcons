using MauiIcons.Fluent;

namespace MauiIcons.Sample;

public partial class BindingPage : ContentPage
{
	public BindingPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private Color _color = Colors.Red;
    public Color MyColor
    {
        get => _color;
        set
        {
            if (value != _color)
            {
                _color = value;
                OnPropertyChanged();
            }
        }
    }

    private FluentIcons _icon = FluentIcons.Accessibility16;

    public FluentIcons MyIcon
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

    private void Button_Clicked(object sender, EventArgs e)
    {
        MyColor = MyColor == Colors.Red ? Colors.Green : Colors.Red;
        MyIcon = MyIcon == FluentIcons.Accessibility16 ? FluentIcons.AddCircle24 : FluentIcons.Accessibility16;
    }
}