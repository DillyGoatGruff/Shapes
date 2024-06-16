using MvvmToolKit;
using Shapes.Wpf.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Shapes.Wpf.Windows.Main
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly IShapesDataSource _shapesDataSource;
        private readonly ICalculatedAreaPresenter _calculateAreaPresenter;

        public ObservableCollection<IShape> Shapes { get; } = new ObservableCollection<IShape>();

        public ICommand CalculateAreaCommand { get; }

        public MainViewModel(IShapesDataSource shapesDataSource, ICalculatedAreaPresenter calculateAreaPresenter)
        {
            _shapesDataSource = shapesDataSource;
            _calculateAreaPresenter = calculateAreaPresenter;
            Shapes = new ObservableCollection<IShape>(shapesDataSource.GetShapes());

            CalculateAreaCommand = new RelayCommand(CalculateArea);
        }


        private void CalculateArea()
        {
            _calculateAreaPresenter.PresentCalculatedAreas();
        }

    }
}
