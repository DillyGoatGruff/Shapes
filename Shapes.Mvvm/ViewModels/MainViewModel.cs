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
        private readonly IAddEditShapePresenter _addShapePresenter;

        public ObservableCollection<IShape> Shapes { get; } = new ObservableCollection<IShape>();

        public ICommand CalculateAreaCommand { get; }
        public ICommand AddShapeCommand { get; }
        public ICommand EditShapeCommand { get; }
        public ICommand DeleteShapeCommand { get; }

        public MainViewModel(IShapesDataSource shapesDataSource,
                ICalculatedAreaPresenter calculateAreaPresenter,
                IAddEditShapePresenter addShapePresenter)
        {
            _shapesDataSource = shapesDataSource;
            _calculateAreaPresenter = calculateAreaPresenter;
            _addShapePresenter = addShapePresenter;
            Shapes = new ObservableCollection<IShape>(shapesDataSource.GetShapes());

            CalculateAreaCommand = new RelayCommand(CalculateArea);
            AddShapeCommand = new RelayCommand(AddShape);
            EditShapeCommand = new RelayCommand<IShape>(param => EditShape(param!));
            DeleteShapeCommand = new RelayCommand<IShape>(param => DeleteShape(param!));
        }


        private void CalculateArea()
        {
            _calculateAreaPresenter.PresentCalculatedAreas();
        }

        private void AddShape()
        {
            IShape? newShape = _addShapePresenter.PresentShapeCreation();
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

        private void EditShape(IShape shape)
        {
            IShape? edittedShape = _addShapePresenter.PresentShapeEdit(shape.Clone());
            if (edittedShape == null)
            {
                return;
            }

            if (_shapesDataSource.UpdateShape(edittedShape))
            {
                int index = Shapes.IndexOf(shape);
                Shapes[index] = edittedShape;
            }
            else
            {
                ///TODO: Notify user that the shape was not successfully updated.
            }
        }

        private void DeleteShape(IShape shape)
        {
            if (_shapesDataSource.DeleteShape(shape))
            {
                int index = Shapes.IndexOf(shape);
                Shapes.Remove(shape);
            }
            else
            {
                ///TODO: Notify user that the shape was not successfully deleted.
            }
        }
    }
}
