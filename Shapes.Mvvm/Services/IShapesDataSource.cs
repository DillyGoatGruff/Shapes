using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Mvvm.Models;
using Shapes.Mvvm.Models.Shapes;

namespace Shapes.Mvvm.Services
{
    public interface IShapesDataSource
    {
        IShape[] GetShapes();

        ShapeType[] GetShapeTypes();

        /// <summary>
        /// Saves new shape. Updates <see cref="IShape.ID"/> upon save.
        /// </summary>
        /// <param name="shape">The shape to add.</param>
        /// <returns><see langword="true"/> if sucessfully saved.</returns>
        bool AddNewShape(IShape shape);

        /// <summary>
        /// Saves new edited shape.
        /// </summary>
        /// <param name="shape">The shape to update.</param>
        /// <returns><see langword="true"/> if sucessfully saved.</returns>
        bool UpdateShape(IShape shape);

        /// <summary>
        /// Deletes shape.
        /// </summary>
        /// <param name="shape">The shape to delete.</param>
        /// <returns><see langword="true"/> if sucessfully deleted.</returns>
        bool DeleteShape(IShape shape);

    }
}
