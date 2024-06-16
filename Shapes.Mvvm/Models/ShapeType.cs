using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Mvvm.Models
{
    public class ShapeType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ShapeType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
