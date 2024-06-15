using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class Triangle : IShape
    {
        public ShapeType Type { get; set; }
        public string Name { get; set; }

        public ShapeDimension[] Dimensions { get; }

        public ShapeDimension Side1 { get; }
        public ShapeDimension Side2 { get; }
        public ShapeDimension Side3 { get; }

        public Triangle(ShapeType shapeType, string name, double side1, double side2, double side3)
        {
            Type = shapeType;
            Name = name;
            Side1 = new ShapeDimension("Side1", side1);
            Side2 = new ShapeDimension("Side2", side2);
            Side3 = new ShapeDimension("Side3", side3);

            Dimensions = [Side1, Side2, Side3];
        }
    }
}
