using MvvmToolKit;
using Shapes.Mvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Mvvm.ViewModels
{
    public class DimensionViewModel : ViewModelBase
    {
        private readonly ShapeDimension _shapeDimension;

        public string Name
        {
            get => _shapeDimension.Dimension;
            set
            {
                if (Name != value)
                {
                    _shapeDimension.Dimension = value;
                    OnPropertyChanged();
                }
            }
        }
        public double Value
        {
            get => _shapeDimension.Value;
            set
            {
                if (_shapeDimension.Value != value)
                {
                    if (value >= 0)
                    {
                        _shapeDimension.Value = value;
                    }
                    OnPropertyChanged();
                }
            }
        }

        public DimensionViewModel(ShapeDimension shapeDimension)
        {
            _shapeDimension = shapeDimension;
        }
    }
}
