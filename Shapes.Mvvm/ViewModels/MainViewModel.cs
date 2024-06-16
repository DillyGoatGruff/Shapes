using MvvmToolKit;
using Shapes.Mvvm.Models.Shapes;
using Shapes.Mvvm.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Shapes.Mvvm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IShapesDataSource _shapesDataSource;
        private readonly ICalculatedAreaPresenter _calculateAreaPresenter;
        private readonly IAddShapePresenter _addShapePresenter;

        public ObservableCollection<IShape> Shapes { get; } = new ObservableCollection<IShape>();

        public ICommand CalculateAreaCommand { get; }
        public ICommand AddShapeCommand { get; }

        public MainViewModel(IShapesDataSource shapesDataSource,
                ICalculatedAreaPresenter calculateAreaPresenter,
                IAddShapePresenter addShapePresenter)
        {
            _shapesDataSource = shapesDataSource;
            _calculateAreaPresenter = calculateAreaPresenter;
            _addShapePresenter = addShapePresenter;
            Shapes = new ObservableCollection<IShape>(shapesDataSource.GetShapes());

            CalculateAreaCommand = new RelayCommand(CalculateArea);
            AddShapeCommand = new RelayCommand(AddShape);
        }


        private void CalculateArea()
        {
            _calculateAreaPresenter.PresentCalculatedAreas();
        }

        private void AddShape()
        {
            IShape? newShape = _addShapePresenter.Present();
            if (newShape == null)
            {
                return;
            }

            if (_shapesDataSource.AddNewShape(newShape))
            {
                Shapes.Add(newShape);
            }
            else
            {
                ///TODO: Notify user that the shape was not successfully saved.
            }
        }

    }
}
