using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using ShowMeTheXaml;
using SukiDemo.Common;
using SukiDemo.Features.ControlsLibrary;
using SukiDemo.Features.ControlsLibrary.Colors;
using SukiDemo.Features.ControlsLibrary.Dialogs;
using SukiDemo.Features.ControlsLibrary.StackPage;
using SukiDemo.Features.ControlsLibrary.TabControl;
using SukiDemo.Features.ControlsLibrary.Toasts;
using SukiDemo.Features.CustomTheme;
using SukiDemo.Features.Dashboard;
using SukiDemo.Features.Effects;
using SukiDemo.Features.Playground;
using SukiDemo.Features.Splash;
using SukiDemo.Features.Theming;
using SukiDemo.Services;
using SukiDemo.ViewModels;
using SukiDemo.Views;
using SukiUI.Dialogs;
using SukiUI.Toasts;
using SukiDemo.Common;

namespace SukiDemo;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    // public override void OnFrameworkInitializationCompleted()
    // {
    //     if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    //     {
    //         // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
    //         // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
    //         DisableAvaloniaDataAnnotationValidation();
    //         desktop.MainWindow = new MainWindow
    //         {
    //             DataContext = new MainWindowViewModel(),
    //         };
    //
    //     }
    //
    //     base.OnFrameworkInitializationCompleted();
    // }
    
    
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var services = new ServiceCollection();

            services.AddSingleton(desktop);

            var views = ConfigureViews(services);
            var provider = ConfigureServices(services);

            DataTemplates.Add(new Common.ViewLocator(views));
            
            XamlDisplayInternalData.RegisterXamlDisplayData();

            desktop.MainWindow = views.CreateView<SukiUIDemoViewModel>(provider) as Window;
        }

        base.OnFrameworkInitializationCompleted();
        
        //    Shadcn.Configure(Application.Current, ThemeVariant.Dark);
    }
    
    
        private static SukiViews ConfigureViews(ServiceCollection services)
    {
        return new SukiViews()

            // Add main view
            .AddView<SukiUIDemoView, SukiUIDemoViewModel>(services)

            // Add pages
            .AddView<SplashView, SplashViewModel>(services)
            .AddView<ThemingView, ThemingViewModel>(services)
            .AddView<PlaygroundView, PlaygroundViewModel>(services)
            .AddView<DashboardView, DashboardViewModel>(services)
            .AddView<ButtonsView, ButtonsViewModel>(services)
            .AddView<CardsView, CardsViewModel>(services)
            .AddView<CollectionsView, CollectionsViewModel>(services)
            .AddView<ContextMenusView, ContextMenusViewModel>(services)
            .AddView<DockView, DockViewModel>(services)
            .AddView<ExpanderView, ExpanderViewModel>(services)
            .AddView<IconsView, IconsViewModel>(services)
            .AddView<InfoBarView, InfoBarViewModel>(services)
            .AddView<MiscView, MiscViewModel>(services)
            .AddView<ProgressView, ProgressViewModel>(services)
            .AddView<PropertyGridView, PropertyGridViewModel>(services)
            .AddView<TextView, TextViewModel>(services)
            .AddView<TogglesView, TogglesViewModel>(services)
            .AddView<ToastsView, ToastsViewModel>(services)
            .AddView<TabControlView, TabControlViewModel>(services)
            .AddView<StackPageView, StackPageViewModel>(services)
            .AddView<DialogsView, DialogsViewModel>(services)
            .AddView<ColorsView, ColorsViewModel>(services)

            // Add additional views
            .AddView<DialogView, DialogViewModel>(services)
            .AddView<VmDialogView, VmDialogViewModel>(services)
            .AddView<RecursiveView, RecursiveViewModel>(services)
            .AddView<CustomThemeDialogView, CustomThemeDialogViewModel>(services);
    }

    private static ServiceProvider ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<ClipboardService>();
        services.AddSingleton<PageNavigationService>();
        services.AddSingleton<ISukiToastManager, SukiToastManager>();
        services.AddSingleton<ISukiDialogManager, SukiDialogManager>();

        return services.BuildServiceProvider();
    }    
        
        
    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}