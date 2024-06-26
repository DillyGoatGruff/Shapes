﻿namespace Shapes.Mvvm.Models.Shapes
{
    public class Triangle : IShape
    {
        public int Id { get; private set; }

        public ShapeType Type { get; set; }

        public string Name { get; set; }

        public ShapeDimension[] Dimensions { get; }

        public ShapeDimension Side1 { get; }
        public ShapeDimension Side2 { get; }
        public ShapeDimension Side3 { get; }

        public double Area
        {
            get
            {
                double s = (Side1 + Side2 + Side3) / 2;
                return Math.Sqrt(s * (s - Side1) * (s - Side2) * (s - Side3));
            }
        }

        public Triangle(int id, ShapeType shapeType, string name, double side1, double side2, double side3)
        {
            Id = id;
            Type = shapeType;
            Name = name;
            Side1 = new ShapeDimension("Side1", side1);
            Side2 = new ShapeDimension("Side2", side2);
            Side3 = new ShapeDimension("Side3", side3);

            Dimensions = [Side1, Side2, Side3];
        }

        public IShape Clone()
        {
            return new Triangle(Id, Type, Name, Side1, Side2, Side3);
        }

        public void UpdateIdAfterSave(int id)
        {
            Id = id;
        }
    }
}
