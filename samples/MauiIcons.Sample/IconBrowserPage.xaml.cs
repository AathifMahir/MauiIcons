using System.Collections.ObjectModel;
using MauiIcons.Core;
using MauiIcons.Cupertino;
using MauiIcons.Fluent;
using MauiIcons.Fluent.Filled;
using MauiIcons.FontAwesome;
using MauiIcons.FontAwesome.Brand;
using MauiIcons.FontAwesome.Solid;
using MauiIcons.Material;
using MauiIcons.Material.Outlined;
using MauiIcons.Material.Rounded;
using MauiIcons.Material.Sharp;
using MauiIcons.SegoeFluent;

namespace MauiIcons.Sample;

public class IconItem
{
    public Enum Icon { get; set; } = FluentIcons.AccessTime24;
    public string Name { get; set; } = string.Empty;
}

public class IconSet
{
    public string Name { get; set; } = string.Empty;
    public List<IconItem> Icons { get; set; } = [];

    public static IconSet FromEnum<TEnum>(string name) where TEnum : struct, Enum
    {
        return new IconSet
        {
            Name = name,
            Icons = Enum.GetValues<TEnum>()
                .Select(icon => new IconItem { Icon = icon, Name = icon.ToString() })
                .ToList()
        };
    }
}

public partial class IconBrowserPage : ContentPage
{
    private List<IconItem> _allIcons = [];
    private List<IconItem> _filteredIcons = [];

    public ObservableCollection<IconItem> FilteredIcons { get; } = [];

    public ObservableCollection<IconSet> IconSets { get; } =
    [
        IconSet.FromEnum<FluentIcons>("Fluent"),
        IconSet.FromEnum<FluentFilledIcons>("Fluent Filled"),
        IconSet.FromEnum<MaterialIcons>("Material"),
        IconSet.FromEnum<MaterialOutlinedIcons>("Material Outlined"),
        IconSet.FromEnum<MaterialRoundedIcons>("Material Rounded"),
        IconSet.FromEnum<MaterialSharpIcons>("Material Sharp"),
        IconSet.FromEnum<SegoeFluentIcons>("Segoe Fluent"),
        IconSet.FromEnum<CupertinoIcons>("Cupertino"),
        IconSet.FromEnum<FontAwesomeIcons>("Font Awesome"),
        IconSet.FromEnum<FontAwesomeSolidIcons>("Font Awesome Solid"),
        IconSet.FromEnum<FontAwesomeBrandIcons>("Font Awesome Brand"),
    ];

    private IconSet? _selectedIconSet;
    public IconSet? SelectedIconSet
    {
        get => _selectedIconSet;
        set
        {
            if (value != _selectedIconSet)
            {
                _selectedIconSet = value;
                OnPropertyChanged();
                _allIcons = value?.Icons ?? [];
                ApplyFilter(null);
            }
        }
    }

    private string _searchText = string.Empty;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (value != _searchText)
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }
    }

    private string _resultCountText = string.Empty;
    public string ResultCountText
    {
        get => _resultCountText;
        set
        {
            if (value != _resultCountText)
            {
                _resultCountText = value;
                OnPropertyChanged();
            }
        }
    }

    public IconBrowserPage()
    {
        InitializeComponent();
        BindingContext = this;

        SelectedIconSet = IconSets[0];
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        ApplyFilter(e.NewTextValue);
    }

    private void ApplyFilter(string? searchText)
    {
        _filteredIcons = string.IsNullOrWhiteSpace(searchText)
            ? _allIcons
            : _allIcons.Where(i => i.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();

        FilteredIcons.Clear();
        foreach (var icon in _filteredIcons)
        {
            FilteredIcons.Add(icon);
        }
        UpdateResultCount();
    }

    private void UpdateResultCount()
    {
        ResultCountText = $"{_filteredIcons.Count} icon(s) displayed out of {_allIcons.Count}";
    }
}
