﻿using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;

namespace SukiDemo.Features.ControlsLibrary;

public partial class PropertyGridViewModel() : DemoPageBase("PropertyGrid", MaterialIconKind.Grid)
{
    [ObservableProperty] private FormViewModel? _form = new();
}