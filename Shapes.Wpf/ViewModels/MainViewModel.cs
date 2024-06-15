using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Wpf.ViewModels
{
    internal class MainViewModel
    {
        private readonly IShapesDataSource _shapesDataSource;

        public ObservableCollection<IShape> Shapes { get; } = new ObservableCollection<IShape>();

        public MainViewModel(IShapesDataSource shapesDataSource)
        {
            _shapesDataSource = shapesDataSource;
            Shapes = new ObservableCollection<IShape>(shapesDataSource.GetShapes());
        }


    }
}
