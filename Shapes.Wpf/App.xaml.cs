using Microsoft.Extensions.DependencyInjection;
using Shapes.DataAccess;
using Shapes.Mvvm.Services;
using Shapes.Mvvm.ViewModels;
using Shapes.Wpf.Windows.CalculatedAreas;
using Shapes.Wpf.Windows.Main;
using System.Windows;

namespace Shapes.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static IServiceProvider ServiceProvider { get; private set; } = default!;


        public App()
        {
            ServiceProvider = new ServiceCollection()
                .AddTransient<ICalculatedAreaPresenter, CalculatedAreaPresenter>()
                .AddSingleton<IShapesDataSource, ShapesManager>()
                .AddSingleton<MainViewModel>()
                .AddSingleton<CalculatedAreasViewModel>()
                .AddSingleton<MainWindow>(x =>
                {
                    return new MainWindow()
                    {
                        DataContext = x.GetRequiredService<MainViewModel>()
                    };
                })
                .BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceProvider.GetRequiredService<MainWindow>().Show();
        }

    }

}
