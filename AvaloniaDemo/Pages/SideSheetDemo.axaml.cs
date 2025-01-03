using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaDemo.Models;

namespace AvaloniaDemo.Pages;

public partial class SideSheetDemo : UserControl {
    public SideSheetDemo() {
        InitializeComponent();
    }

    private void OpenSideInfoButton_OnClick(object? sender, RoutedEventArgs e) {
        var vm = DataContext as SideSheetDemoViewModel;
        if (vm == null)
            return;

        vm.SideInfoOpened = true;
    }
}