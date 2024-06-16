using Shapes.Mvvm.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Mvvm.Services
{
    public interface IAddShapePresenter
    {
        /// <summary>
        /// Displays the user interface to create a new shape.
        /// </summary>
        IShape? Present();

    }
}
