using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public interface IShape
    {
       
        public ShapeType Type { get; set; }

        public string Name { get; set; }

        public ShapeDimension[] Dimensions { get; }

    }
}
