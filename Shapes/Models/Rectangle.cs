using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class Rectangle : IShape
    {
        public ShapeType Type { get; set; }
        public string Name { get; set; }

        public ShapeDimension[] Dimensions { get; }

        public ShapeDimension Length { get; set; }
        public ShapeDimension Width { get; set; }

        public Rectangle(ShapeType type, string name, double length, double width)
        {
            Type = type;
            Name = name;
            Length = new ShapeDimension("Length", length);
            Width = new ShapeDimension("Width", width);

            Dimensions = [Length, Width];
        }
    }
}
