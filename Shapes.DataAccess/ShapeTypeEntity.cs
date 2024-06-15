using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.DataAccess
{
    public class ShapeTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<ShapeEntity> Shapes { get; set; } = default!;
    }
}
