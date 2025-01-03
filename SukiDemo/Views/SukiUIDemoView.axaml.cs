using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using SukiUI.Controls;
using SukiUI.Enums;
using SukiUI.Models;
using System.Runtime.CompilerServices;
using SukiDemo.ViewModels;

namespace SukiDemo.Views;

public partial class SukiUIDemoView : SukiWindow
{
    public SukiUIDemoView()
    {
        InitializeComponent();

        if (RuntimeFeature.IsDynamicCodeCompiled == false)
        {
            Title += " (native)";
        }
    }

    private void ThemeMenuItem_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not SukiUIDemoViewModel vm) return;
        if (e.Source is not MenuItem mItem) return;
        if (mItem.DataContext is not SukiColorTheme cTheme) return;
        vm.ChangeTheme(cTheme);
    }

    private void BackgroundMenuItem_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not SukiUIDemoViewModel vm) return;
        if (e.Source is not MenuItem mItem) return;
        if (mItem.DataContext is not SukiBackgroundStyle cStyle) return;
    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        IsMenuVisible = !IsMenuVisible;
    }

    private void MakeFullScreenPressed(object? sender, PointerPressedEventArgs e)
    {
        WindowState = WindowState == WindowState.FullScreen ? WindowState.Normal : WindowState.FullScreen;
        IsTitleBarVisible = WindowState != WindowState.FullScreen;
    }
}