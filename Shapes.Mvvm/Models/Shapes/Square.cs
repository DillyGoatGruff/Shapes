namespace Shapes.Mvvm.Models.Shapes
{
    public class Square : IShape
    {
        public int Id { get; private set; }

        public ShapeType Type { get; set; }

        public string Name { get; set; }

        public ShapeDimension[] Dimensions { get; }

        public ShapeDimension Side { get; set; }

        public double Area => Math.Pow(Side, 2);

        public Square(int id, ShapeType type, string name, double side)
        {
            Id = id;
            Type = type;
            Name = name;
            Side = new ShapeDimension("Side", side);

            Dimensions = [Side];
        }

        public IShape Clone()
        {
            return new Square(Id, Type, Name, Side);
        }

        public void UpdateIdAfterSave(int id)
        {
            Id = id;
        }
    }
}
