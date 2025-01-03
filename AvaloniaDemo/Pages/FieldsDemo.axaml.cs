using Avalonia.Controls;
using AvaloniaDemo.ViewModels;

namespace AvaloniaDemo.Pages;

public partial class FieldsDemo : UserControl {
    public FieldsDemo() {
        InitializeComponent();

        DataContext = new TextFieldsViewModel();
    }
}