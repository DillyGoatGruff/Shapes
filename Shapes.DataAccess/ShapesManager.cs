using Microsoft.EntityFrameworkCore;
using Shapes.Mvvm.Models;
using Shapes.Mvvm.Models.Shapes;
using Shapes.Mvvm.Services;

namespace Shapes.DataAccess
{
    public class ShapesManager : IShapesDataSource
    {
        static readonly string m_connectionString;
        static ShapesManager()
        {
            string exePath = System.Diagnostics.Process.GetCurrentProcess().MainModule!.FileName;
            string directory = Path.GetDirectoryName(exePath)!;
            string dbFileName = Path.Combine(directory, "Shapes.db");
            m_connectionString = $"Data Source={dbFileName}";
        }

        public bool AddNewShape(IShape shape)
        {
            try
            {
                using var context = new ShapesContext(m_connectionString);

                ShapeEntity shapeEntity;
                switch (shape)
                {
                    case Circle c:
                        shapeEntity = new ShapeEntity()
                        {
                            ShapeTypeId = c.Type.Id,
                            Name = c.Name,
                            Radius = c.Radius,
                        };
                        break;
                    case Square s:
                        shapeEntity = new ShapeEntity()
                        {
                            ShapeTypeId = s.Type.Id,
                            Name = s.Name,
                            Length = s.Side
                        };
                        break;
                    case Rectangle r:
                        shapeEntity = new ShapeEntity()
                        {
                            ShapeTypeId = r.Type.Id,
                            Name = r.Name,
                            Length = r.Length,
                            Width = r.Width,
                        };
                        break;
                    case Triangle t:
                        shapeEntity = new ShapeEntity()
                        {
                            ShapeTypeId = t.Type.Id,
                            Name = t.Name,
                            Length = t.Side1,
                            Width = t.Side2,
                            Height = t.Side3,
                        };
                        break;
                    default:
                        throw new ArgumentException($"Unknown shape ''to insert into database.");
                }

                context.Shapes.Add(shapeEntity);

                return context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public IShape[] GetShapes()
        {
            using var context = new ShapesContext(m_connectionString);
            IEnumerable<ShapeEntity> shapeEntities = context.Shapes.Include(x => x.ShapeType);
            IShape[] shapes = new IShape[shapeEntities.Count()];

            int i = 0;
            foreach (var s in shapeEntities)
            {
                ShapeType shapeType = new ShapeType(s.ShapeType.Id, s.ShapeType.Name);
                shapes[i++] = s.ShapeType.Name switch
                {
                    nameof(Circle) => new Circle(shapeType, s.Name, (double)s.Radius!.Value),
                    nameof(Square) => new Square(shapeType, s.Name, (double)s.Length!.Value),
                    nameof(Rectangle) => new Rectangle(shapeType, s.Name, (double)s.Length!.Value, (double)s.Width!.Value),
                    nameof(Triangle) => new Triangle(shapeType, s.Name, (double)s.Length!.Value, (double)s.Width!.Value, (double)s.Height!.Value),
                    _ => throw new ArgumentException($"Unknown Shape: '{s.ShapeType.Name}'")
                };
            }

            return shapes;
        }
    }
}
