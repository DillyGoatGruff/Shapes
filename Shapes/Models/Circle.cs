﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class Circle : IShape
    {

        public ShapeType Type { get; set; }
        public string Name { get; set; }

        public ShapeDimension Radius { get; set; }

        public ShapeDimension[] Dimensions { get; }

        public Circle(ShapeType type, string name, double radius)
        {
            Type = type;
            Name = name;
            Radius = new ShapeDimension("Radius", radius);

            Dimensions = [Radius];
        }

    }
}
