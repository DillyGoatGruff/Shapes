namespace Shapes.Mvvm.Models.Shapes
{
    public class Circle : IShape
    {
        public int Id { get; private set; }

        public ShapeType Type { get; set; }

        public string Name { get; set; }

        public ShapeDimension Radius { get; set; }

        public ShapeDimension[] Dimensions { get; }

        public double Area => Math.PI * Math.Pow(Radius, 2);

        public Circle(int id, ShapeType type, string name, double radius)
        {
            Id = id;
            Type = type;
            Name = name;
            Radius = new ShapeDimension("Radius", radius);

            Dimensions = [Radius];
        }

        public IShape Clone()
        {
            return new Circle(Id, Type, Name, Radius);
        }

        public void UpdateIdAfterSave(int id)
        {
            Id = id;
        }
    }
}
