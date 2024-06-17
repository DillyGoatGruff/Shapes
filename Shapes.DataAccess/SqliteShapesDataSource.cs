using Microsoft.EntityFrameworkCore;
using Shapes.Mvvm.Models;
using Shapes.Mvvm.Models.Shapes;
using Shapes.Mvvm.Services;

namespace Shapes.DataAccess
{
    public class SqliteShapesDataSource : IShapesDataSource
    {
        static readonly string m_connectionString;
        static SqliteShapesDataSource()
        {
            string exePath = System.Diagnostics.Process.GetCurrentProcess().MainModule!.FileName;
            string directory = Path.GetDirectoryName(exePath)!;
            string dbFileName = Path.Combine(directory, "Shapes.db");
            m_connectionString = $"Data Source={dbFileName}";
        }

        private ShapeEntity CreateShapeEntity(IShape shape)
        {
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

            return shapeEntity;
        }

        /// <inheritdoc/>
        public bool AddNewShape(IShape shape)
        {
            try
            {
                ShapeEntity shapeEntity = CreateShapeEntity(shape);

                using var context = new ShapesContext(m_connectionString);

                context.Shapes.Add(shapeEntity);

                int recoredInserted = context.SaveChanges();
                if (recoredInserted > 0)
                {
                    shape.UpdateIdAfterSave(shapeEntity.Id);
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateShape(IShape shape)
        {
            try
            {
                ShapeEntity shapeEntity = CreateShapeEntity(shape);
                shapeEntity.Id = shape.Id;

                using var context = new ShapesContext(m_connectionString);

                context.Shapes.Update(shapeEntity);

                return context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteShape(IShape shape)
        {
            try
            {
                using var context = new ShapesContext(m_connectionString);

                context.Shapes.Remove(new ShapeEntity() { Id = shape.Id });
                return context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc/>
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
                    nameof(Circle) => new Circle(s.Id, shapeType, s.Name, (double)s.Radius!.Value),
                    nameof(Square) => new Square(s.Id, shapeType, s.Name, (double)s.Length!.Value),
                    nameof(Rectangle) => new Rectangle(s.Id, shapeType, s.Name, (double)s.Length!.Value, (double)s.Width!.Value),
                    nameof(Triangle) => new Triangle(s.Id, shapeType, s.Name, (double)s.Length!.Value, (double)s.Width!.Value, (double)s.Height!.Value),
                    _ => throw new ArgumentException($"Unknown Shape: '{s.ShapeType.Name}'")
                };
            }

            return shapes;
        }

        /// <inheritdoc/>
        public ShapeType[] GetShapeTypes()
        {
            using var context = new ShapesContext(m_connectionString);

            return context.ShapeTypes.Select(x => new ShapeType(x.Id, x.Name)).ToArray();
        }


    }
}
