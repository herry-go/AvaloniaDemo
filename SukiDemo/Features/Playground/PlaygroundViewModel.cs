﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls.Notifications;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Icons;
using SukiDemo.Utilities;
using SukiUI.Toasts;

namespace SukiDemo.Features.Playground;

internal partial class PlaygroundViewModel(ISukiToastManager toastManager) : DemoPageBase("Playground", MaterialIconKind.Pencil, -150)
{
    // Delay the toggle pane to handle System.InvalidOperationException: The observable can only be subscribed once.
    [RelayCommand]
    private async Task TogglePaneDelay() => await Task.Delay(500);
    
    public ObservableCollection<string> ButtonsElements { get; init; } =
    [
        XamlData.Buttons["ButtonFlat"],
        XamlData.Buttons["ButtonFlatRounded"],
        XamlData.Buttons["ButtonFlatLarge"],
        XamlData.Buttons["ButtonBasic"],
        XamlData.Buttons["ButtonBasicAccent"],
        XamlData.Buttons["ButtonNeutral"],
        XamlData.Buttons["ButtonOutlined"]
    ];

    public ObservableCollection<string> InputsElements { get; init; } =
    [
        XamlData.Inputs["TextBox"],
        XamlData.Inputs["ToggleSwitch"],
        XamlData.Inputs["ToggleButton"],
        XamlData.Inputs["Slider"],
        XamlData.Inputs["ComboBox"],
        XamlData.Inputs["CheckBox"],
        XamlData.Inputs["RadioButton"],
        XamlData.Inputs["NumericUpDown"],
        XamlData.Inputs["DatePicker"]
    ];

    public ObservableCollection<string> ProgressElements { get; init; } =
    [
        XamlData.Progress["WaveProgress"],
        XamlData.Progress["Stepper"],
        XamlData.Progress["CircleProgressBar"],
        XamlData.Progress["StepperAlternativeStyle"],
        XamlData.Progress["CircleProgressBarIndeterminate"],
        XamlData.Progress["Loading"],
        XamlData.Progress["ProgressBar60"],
        XamlData.Progress["ProgressBar50WithProgressText"],
        XamlData.Progress["ProgressBarIndeterminate"]
    ];

    public ObservableCollection<string> ListsElements { get; init; } =
    [
        XamlData.Lists["ListBox"],
        XamlData.Lists["TreeView"]
    ];

    public ObservableCollection<string> LayoutElements { get; init; } =
    [
        XamlData.Layout["GlassCard"],
        XamlData.Layout["GroupBox"],
        XamlData.Layout["Expander"],
        XamlData.Layout["TabControl"]
    ];

    public void DisplayError(string message)
    {
        toastManager.CreateToast()
            .OfType(NotificationType.Error)
            .WithTitle("Playground Error")
            .WithContent(message)
            .Dismiss().After(TimeSpan.FromSeconds(5))
            .Dismiss().ByClicking()
            .Queue();
    }
}