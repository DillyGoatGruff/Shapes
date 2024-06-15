using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class Square : IShape
    {

        public ShapeType Type { get; set; }
        public string Name { get; set; }

        public ShapeDimension[] Dimensions { get; }

        public ShapeDimension Side { get; set; }

        public Square(ShapeType type, string name, double side)
        {
            Type = type;
            Name = name;
            Side = new ShapeDimension("Side", side);

            Dimensions = [Side];
        }

    }
}
