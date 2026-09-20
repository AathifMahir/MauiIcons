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
    private const int BatchSize = 200;
    private const double ScrollThreshold = 200;

    private List<IconItem> _allIcons = [];
    private List<IconItem> _filteredIcons = [];
    private int _loadedCount;
    private bool _isLoadingBatch;

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
                _allIcons = value?.Icons.OrderBy(i => i.Name).ToList() ?? [];
                ApplyFilter(SearchText);
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

        _loadedCount = 0;
        FilteredIcons.Clear();
        LoadNextBatch();
        _ = IconsScrollView?.ScrollToAsync(0, 0, false);
    }

    private void LoadNextBatch()
    {
        if (_loadedCount >= _filteredIcons.Count)
        {
            return;
        }

        var nextBatch = _filteredIcons.Skip(_loadedCount).Take(BatchSize);
        foreach (var icon in nextBatch)
        {
            FilteredIcons.Add(icon);
        }

        _loadedCount = FilteredIcons.Count;
        UpdateResultCount();
    }

    private async void IconsScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {
        if (_isLoadingBatch || _loadedCount >= _filteredIcons.Count)
        {
            return;
        }

        var distanceToBottom = IconsScrollView.ContentSize.Height
                               - IconsScrollView.Height
                               - e.ScrollY;

        if (distanceToBottom > ScrollThreshold)
        {
            return;
        }

        _isLoadingBatch = true;
        try
        {
            LoadNextBatch();

            // Laisse le layout se remettre a jour avant d'autoriser un nouveau batch.
            await Task.Yield();
        }
        finally
        {
            _isLoadingBatch = false;
        }
    }

    private async void IconItem_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is not Element { BindingContext: IconItem item })
        {
            return;
        }

        await Clipboard.SetTextAsync(item.Name);

        CopyToastLabel.Text = $"{item.Name} copied";
        CopyToast.IsVisible = true;
        await CopyToast.FadeTo(1, 150);
        await Task.Delay(1200);
        await CopyToast.FadeTo(0, 250);
        CopyToast.IsVisible = false;
    }

    private void UpdateResultCount()
    {
        ResultCountText = $"{_loadedCount} icon(s) displayed out of {_filteredIcons.Count}";
    }
}
