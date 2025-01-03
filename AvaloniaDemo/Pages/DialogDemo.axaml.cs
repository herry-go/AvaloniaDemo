﻿using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using AvaloniaDemo.Models;
using AvaloniaDemo.ViewModels;
using DialogHostAvalonia;

namespace AvaloniaDemo.Pages;

public partial class DialogDemo : UserControl {
    public DialogDemo() {
        InitializeComponent();
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e) {
        // Lazy Initialize view model
        DataContext ??= new DialogDemoViewModel();

        base.OnApplyTemplate(e);
    }

    private void OpenDialogWithView(object? sender, RoutedEventArgs e) {
        DialogHost.Show(Resources["Sample2View"]!, "MainDialogHost");
    }

    private void OpenDialogWithModel(object? sender, RoutedEventArgs e) {
        // View that associated with this model defined at DialogContentTemplate in DialogDemo.axaml
        DialogHost.Show(new Sample2Model(new Random().Next(0, 100)), "MainDialogHost");
    }

    private void OpenMoreDialogHostExamples(object? sender, RoutedEventArgs e) {
        Process.Start(new ProcessStartInfo { FileName = "https://github.com/AvaloniaUtils/DialogHost.Avalonia", UseShellExecute = true });
    }
}