using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public struct ShapeDimension
    {
        public string Dimension { get; set; }
        public double Value { get; set; }
     
        public ShapeDimension(string dimension, double value)
        {
            Dimension = dimension;
            Value = value;
        }
    }
}
