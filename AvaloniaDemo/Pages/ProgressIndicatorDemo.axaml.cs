using Avalonia.Controls;
using AvaloniaDemo.ViewModels;

namespace AvaloniaDemo.Pages;

public partial class ProgressIndicatorDemo : UserControl {
    public ProgressIndicatorDemo() {
        InitializeComponent();

        DataContext = new ProgressIndicatorDemoViewModel();
    }
}