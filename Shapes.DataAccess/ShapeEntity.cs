using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.DataAccess
{
    public class ShapeEntity
    {
        public int Id { get; set; }

        public int ShapeTypeId { get; set; }

        public string Name { get; set; } = default!;

        public decimal? Length { get; set; }

        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public decimal? Radius { get; set; }


        public ShapeTypeEntity ShapeType { get; set; } = default!;
    }
}
