using MvvmToolKit;
using Shapes.Wpf.Windows.Main;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Wpf.Windows.CalculatedAreas
{
    internal class CalculatedAreasViewModel : ViewModelBase
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
