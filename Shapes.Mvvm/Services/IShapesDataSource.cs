using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Mvvm.Models.Shapes;

namespace Shapes.Mvvm.Services
{
    public interface IShapesDataSource
    {
        IShape[] GetShapes();

        bool AddNewShape(IShape shape);

    }
}
