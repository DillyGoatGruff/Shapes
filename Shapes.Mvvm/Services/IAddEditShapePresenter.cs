using Shapes.Mvvm.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Mvvm.Services
{
    public interface IAddEditShapePresenter
    {
        /// <summary>
        /// Displays the user interface to create a new shape.
        /// </summary>
        /// <returns>The created shape. <see langword="null"/> if the user cancels the shape creation.</returns>
        IShape? PresentShapeCreation();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape">The shape to be editted.</param>
        /// <returns>The edited shape. <see langword="null"/> if the user cancels the shape editting.</returns>
        IShape? PresentShapeEdit(IShape shape);

    }
}
