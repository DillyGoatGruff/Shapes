using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Mvvm.Models.Shapes
{
    public interface IShape
    {

        ShapeType Type { get; set; }

        string Name { get; set; }

        double Area { get; }

        ShapeDimension[] Dimensions { get; }

        public static IShape CreateShape(ShapeType type) => type.Name switch
        {
            nameof(Circle) => new Circle(type, nameof(Circle), 0),
            nameof(Square) => new Square(type, nameof(Square), 0),
            nameof(Rectangle) => new Rectangle(type, nameof(Rectangle), 0, 0),
            nameof(Triangle) => new Triangle(type, nameof(Triangle), 0, 0, 0),
            _ => throw new NotImplementedException($"Unknown shape type: '{type.Name}'")
        };

    }
}
