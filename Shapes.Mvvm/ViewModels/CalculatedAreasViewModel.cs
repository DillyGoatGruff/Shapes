using MvvmToolKit;
using Shapes.Mvvm.Models.Shapes;
using System.Collections.ObjectModel;

namespace Shapes.Mvvm.ViewModels
{
    public class CalculatedAreasViewModel : ViewModelBase
    {

        public ObservableCollection<IShape> Shapes { get; }

        public double TotalArea { get; }

        public CalculatedAreasViewModel(MainViewModel mainViewModel)
        {
            Shapes = mainViewModel.Shapes;
            TotalArea = Shapes.Sum(x => x.Area);
        }
    }
}
