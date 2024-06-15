using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public interface IShape
    {
       
        ShapeType Type { get; set; }

        string Name { get; set; }

        double Area { get; }

        ShapeDimension[] Dimensions { get; }

    }
}
