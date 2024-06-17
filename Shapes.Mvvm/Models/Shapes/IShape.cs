using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Mvvm.Models.Shapes
{
    public interface IShape
    {
        public int Id { get; }

        ShapeType Type { get; set; }

        string Name { get; set; }

        double Area { get; }

        ShapeDimension[] Dimensions { get; }

        /// <summary>
        /// Creates a new shape with all the same values as the current shape.
        /// </summary>
        /// <returns>The new shape.</returns>
        IShape Clone();

        void UpdateIdAfterSave(int id);

        public static IShape CreateShape(ShapeType type) => type.Name switch
        {
            nameof(Circle) => new Circle(-1, type, nameof(Circle), 0),
            nameof(Square) => new Square(-1, type, nameof(Square), 0),
            nameof(Rectangle) => new Rectangle(-1, type, nameof(Rectangle), 0, 0),
            nameof(Triangle) => new Triangle(-1, type, nameof(Triangle), 0, 0, 0),
            _ => throw new NotImplementedException($"Unknown shape type: '{type.Name}'")
        };

    }
}
