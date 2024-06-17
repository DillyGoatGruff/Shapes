namespace Shapes.Mvvm.Models.Shapes
{
    public class Rectangle : IShape
    {
        public int Id { get; private set; }

        public ShapeType Type { get; set; }

        public string Name { get; set; }

        public ShapeDimension[] Dimensions { get; }

        public ShapeDimension Length { get; set; }
        public ShapeDimension Width { get; set; }

        public double Area => Length * Width;

        public Rectangle(int id, ShapeType type, string name, double length, double width)
        {
            Id = id;
            Type = type;
            Name = name;
            Length = new ShapeDimension("Length", length);
            Width = new ShapeDimension("Width", width);

            Dimensions = [Length, Width];
        }

        public IShape Clone()
        {
            return new Rectangle(Id, Type, Name, Length, Width);
        }

        public void UpdateIdAfterSave(int id)
        {
            Id = id;
        }
    }
}
