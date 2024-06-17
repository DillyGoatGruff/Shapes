using MvvmToolKit;
using Shapes.Mvvm.Models;
using Shapes.Mvvm.Models.Shapes;
using Shapes.Mvvm.Services;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;

namespace Shapes.Mvvm.ViewModels
{
    public class AddEditShapeViewModel : ViewModelBase
    {
        private ShapeType? _selectedShapeType;
        private IShape? _newShape;
        private DimensionViewModel[] _dimensions;
        private bool _canSave;

        public ShapeType[] ShapeTypes { get; }

        public ShapeType? SelectedShapeType
        {
            get => _selectedShapeType;
            set
            {
                if (_selectedShapeType != value)
                {
                    _selectedShapeType = value;
                    if (_selectedShapeType != null)
                    {
                        NewShape = IShape.CreateShape(_selectedShapeType);
                    }
                    OnPropertyChanged();
                }
            }
        }

        public IShape? NewShape
        {
            get => _newShape;
            private set
            {
                if (_newShape != value)
                {
                    _newShape = value;
                    Dimensions = _newShape?.Dimensions.Select(x => new DimensionViewModel(x)).ToArray() ?? Array.Empty<DimensionViewModel>();
                    OnPropertyChanged();
                }
            }
        }

        public string ShapeName
        {
            get => _newShape?.Name ?? "";
            set
            {
                if (_newShape != null && _newShape.Name != value)
                {
                    _newShape.Name = value;
                    CanSave = IsInputAllValid();
                    OnPropertyChanged();
                }

            }
        }

        public DimensionViewModel[] Dimensions
        {
            get => _dimensions;

            [MemberNotNull(nameof(_dimensions))]
            set
            {
                if (_dimensions != value)
                {
                    _dimensions = value;
                    foreach (var dim in Dimensions)
                    {
                        dim.PropertyChanged += (sender, e) =>
                        {
                            CanSave = IsInputAllValid();
                            OnPropertyChanged(nameof(NewShape));
                            OnPropertyChanged(nameof(Dimensions));
                        };
                    }
                    CanSave = IsInputAllValid();
                    OnPropertyChanged();
                }
            }
        }

        public bool CanSave
        {
            get => _canSave;
            private set
            {
                if (_canSave != value)
                {
                    _canSave = value;
                    OnPropertyChanged();
                }
            }
        }

        public AddEditShapeViewModel(IShapesDataSource shapesDataSource)
        {
            ShapeTypes = shapesDataSource.GetShapeTypes();
            Dimensions = Array.Empty<DimensionViewModel>();
            SelectedShapeType = ShapeTypes.FirstOrDefault();
        }

        private bool IsInputAllValid()
        {
            if (NewShape is null) return false;
            else if (string.IsNullOrWhiteSpace(ShapeName)) return false;
            else if (NewShape.Area <= 0) return false;
            else if (double.IsNaN(NewShape.Area)) return false;

            return true;
        }

        public void SetShapeToEdit(IShape shape)
        {
            _selectedShapeType = ShapeTypes.FirstOrDefault(x => x.Id == shape.Type.Id);
            NewShape = shape;
            OnPropertyChanged(nameof(SelectedShapeType));
            OnPropertyChanged(nameof(NewShape));
        }
    }
}
