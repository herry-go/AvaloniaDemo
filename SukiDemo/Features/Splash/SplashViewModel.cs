using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Icons;
using SukiDemo.Features.Dashboard;
using SukiDemo.Services;

namespace SukiDemo.Features.Splash;

public partial class SplashViewModel(PageNavigationService nav) : DemoPageBase("Welcome", MaterialIconKind.Hand, int.MinValue)
{
    [ObservableProperty] private bool _dashBoardVisited;
    
    [RelayCommand]
    private void OpenDashboard()
    {
        DashBoardVisited = true;
        nav.RequestNavigation<DashboardViewModel>();
    }
}