using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;

namespace SukiDemo.Features.ControlsLibrary;

public partial class CollectionsViewModel : DemoPageBase
{
    public AvaloniaList<string> SimpleContent { get; } = [];
    public DataGridCollectionView DataGridContent { get; }
    public AvaloniaList<Node> TreeViewContent { get; } = [];
    [ObservableProperty] private string _selectedSimpleContent;
    [ObservableProperty] private bool _isDataGridColumnsResizable;

    public CollectionsViewModel() : base("Collections", MaterialIconKind.ListBox)
    {
        SimpleContent.AddRange(Enumerable.Range(1, 50).Select(x => $"Option {x}"));
        DataGridContent = new DataGridCollectionView(Enumerable.Range(1, 50).Select(x => new DataGridContentViewModel(x)));
        DataGridContent.GroupDescriptions.Add(new DataGridPathGroupDescription("Group"));
        //DataGridContent.AddRange(Enumerable.Range(1, 50).Select(x => new DataGridContentViewModel(x)));
        SelectedSimpleContent = SimpleContent.First();
        TreeViewContent.AddRange(
            Enumerable.Range(1, 10).Select(x => new Node($"Outer {x}",
                Enumerable.Range(1, 5).Select(y => new Node($"Inner {y}",
                    Enumerable.Range(1, 2).Select(z => new Node($"Innermost {z}")))))));
    }
}

public partial class DataGridContentViewModel(int value) : ObservableObject
{
    [ObservableProperty] private string _stringColumn = $"Content {value}";
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(Group))] private int _intColumn = value;
    [ObservableProperty] private bool _boolColumn = Random.Shared.Next(0, 2) == 0;
    public string Group => IntColumn % 2 == 0 ? "Even" : "Odd";
}

public partial class Node(string value, IEnumerable<Node>? subNodes = null) : ObservableObject
{
    public AvaloniaList<Node> SubNodes { get; } = new(subNodes ?? Array.Empty<Node>());
    [ObservableProperty] private string _value = value;
}