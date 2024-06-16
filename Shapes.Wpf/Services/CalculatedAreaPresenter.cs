using Microsoft.Extensions.DependencyInjection;
using Shapes.Wpf.Windows.CalculatedAreas;
using System.Windows;

namespace Shapes.Wpf.Services
{
    internal class CalculatedAreaPresenter : ICalculatedAreaPresenter
    {
        public void PresentCalculatedAreas()
        {
            CalculatedAreasView calculatedAreaControl = new CalculatedAreasView() { DataContext = App.ServiceProvider.GetRequiredService<CalculatedAreasViewModel>() };
            calculatedAreaControl.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            //Limit height and width to something reasonable to fit on screen, but allow it to size it perfectly if it is reasonable
            if (calculatedAreaControl.DesiredSize.Height > 750)
            {
                calculatedAreaControl.Height = 750;
            }

            if (calculatedAreaControl.DesiredSize.Width > 750)
            {
                calculatedAreaControl.Width = 750;
            }

            Window wnd = new Window();
            wnd.Title = "Calculated Area";
            wnd.Content = calculatedAreaControl;
            wnd.Owner = Application.Current.MainWindow;
            wnd.SizeToContent = SizeToContent.WidthAndHeight;
            wnd.ShowInTaskbar = false;
            wnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            wnd.ShowDialog();
        }
    }
}
