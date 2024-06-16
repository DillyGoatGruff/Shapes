using Microsoft.Extensions.DependencyInjection;
using Shapes.Mvvm.Models.Shapes;
using Shapes.Mvvm.Services;
using Shapes.Mvvm.ViewModels;
using System.Windows;

namespace Shapes.Wpf.Windows.AddShape
{
    internal class AddShapePresenter : IAddShapePresenter
    {
        public IShape? Present()
        {
            AddShapeViewModel addShapeVm = App.ServiceProvider.GetRequiredService<AddShapeViewModel>();
            AddShapeView addShapeControl = new AddShapeView() { DataContext = addShapeVm};
            addShapeControl.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            //Limit height and width to something reasonable to fit on screen, but allow it to size it perfectly if it is reasonable

            Window wnd = new Window();
            wnd.Title = "Add Shape";
            wnd.Content = addShapeControl;
            wnd.Owner = Application.Current.MainWindow;
            wnd.SizeToContent = SizeToContent.WidthAndHeight;
            wnd.ShowInTaskbar = false;
            wnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (wnd.ShowDialog() == true)
            {
                return addShapeVm.NewShape;
            }

            return null;
        }
    }
}
