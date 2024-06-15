using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public static implicit operator double(ShapeDimension dimension) => dimension.Value;
        public static implicit operator decimal(ShapeDimension dimension) => (decimal)dimension.Value;
        
        public static double operator +(ShapeDimension dimension1, ShapeDimension dimension2 ) => dimension1.Value + dimension2.Value;
        public static double operator *(ShapeDimension dimension1, ShapeDimension dimension2 ) => dimension1.Value * dimension2.Value;
        public static double operator /(ShapeDimension dimension1, ShapeDimension dimension2 ) => dimension1.Value / dimension2.Value;
        public static double operator -(ShapeDimension dimension1, ShapeDimension dimension2 ) => dimension1.Value - dimension2.Value;
    }
}
