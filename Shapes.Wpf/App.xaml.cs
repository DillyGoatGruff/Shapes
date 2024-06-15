using Microsoft.Extensions.DependencyInjection;
using Shapes.DataAccess;
using Shapes.Wpf.ViewModels;
using System.Configuration;
using System.Data;
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
                .AddSingleton<IShapesDataSource, ShapesManager>()
                .AddSingleton<MainViewModel>()
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
