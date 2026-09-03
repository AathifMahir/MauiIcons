using System.Collections.ObjectModel;
using MauiIcons.Core;
using MauiIcons.Fluent;

namespace MauiIcons.Sample;

public class IconItem
{
    public FluentIcons Icon { get; set; }
    public string Name { get; set; } = string.Empty;
}

public partial class IconBrowserPage : ContentPage
{
    private readonly List<IconItem> _allIcons;
    private List<IconItem> _filteredIcons;

    public ObservableCollection<IconItem> FilteredIcons { get; } = [];

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

        _allIcons = Enum.GetValues<FluentIcons>()
            .Select(icon => new IconItem { Icon = icon, Name = icon.ToString() })
            .ToList();
        _filteredIcons = _allIcons;

        BindingContext = this;

        ApplyFilter(null);
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
