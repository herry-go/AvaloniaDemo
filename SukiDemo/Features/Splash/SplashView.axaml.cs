using Avalonia.Controls;
using Avalonia.Threading;
using SukiUI;

namespace SukiDemo.Features.Splash;

public partial class SplashView : UserControl
{
    public SplashView()
    {
        SukiTheme.GetInstance().OnBaseThemeChanged += _ =>
        {
            Dispatcher.UIThread.Post(() =>
            {
                TextBlockWithInline.InvalidateVisual();
            });
        };
        InitializeComponent();
    }
}