using Shapes.Mvvm.Models;
using Shapes.Mvvm.Models.Shapes;
using Shapes.Mvvm.ViewModels;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Shapes.Wpf.Tools
{
    internal class DimensionsToPathMultiConverter : IMultiValueConverter
    {
        public double StrokeThickness { get; set; } = 3;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
            {
                return values;
            }

            double[] dimensionValues;
            if (values[0] is not ShapeType shapeType)
            {
                return values;
            }
            else if (values[1] is IList<ShapeDimension> shapeDimensions)
            {
                dimensionValues = shapeDimensions.Select(x => x.Value).ToArray();
            }
            else if (values[1] is IList<DimensionViewModel> dimensionViewModels)
            {
                dimensionValues = dimensionViewModels.Select(x => x.Value).ToArray();
            }
            else
            {
                return values;
            }

            double scalingFactor;
            switch (shapeType.Name)
            {
                case nameof(Circle):
                    double radius = dimensionValues[0];
                    if (radius > 0)
                    {
                        return Geometry.Parse($"M {0 + StrokeThickness / 2},{50 + StrokeThickness / 2} A{50 - StrokeThickness / 2},{50 - StrokeThickness / 2} 0 1 1 {100 - StrokeThickness / 2},{50 - StrokeThickness / 2} A {50 - StrokeThickness / 2},{50 - StrokeThickness / 2} 0 1 1 {0 + StrokeThickness / 2},{50 + StrokeThickness / 2}");
                    }
                    break;
                case nameof(Square):
                    double side = dimensionValues[0];
                    if (side > 0)
                    {
                        return Geometry.Parse($"M{StrokeThickness / 2},{StrokeThickness / 2} H{100 - StrokeThickness / 2} V{100 - StrokeThickness / 2} H{StrokeThickness / 2} Z");
                    }
                    break;
                case nameof(Rectangle):
                    if (dimensionValues.Length == 2)
                    {
                        double length = dimensionValues[0];
                        double width = dimensionValues[1];
                        if (length > 0 && width > 0)
                        {
                            scalingFactor = 100 / Math.Max(length, width);
                            double scaledLength = length * scalingFactor - StrokeThickness / 2;
                            double scaledWidth = width * scalingFactor - StrokeThickness - 2;
                            return Geometry.Parse($"M{StrokeThickness / 2},{StrokeThickness / 2} H{scaledWidth} V{scaledLength} H{StrokeThickness / 2} Z");
                        }
                    }
                    break;
                case nameof(Triangle):
                    if (dimensionValues.Length == 3)
                    {
                        double side1 = dimensionValues[0];
                        double side2 = dimensionValues[1];
                        double side3 = dimensionValues[2];
                        if (side1 > 0 && side2 > 0 && side3 > 0)
                        {
                            scalingFactor = 100 / Math.Max(Math.Max(side1, side2), side3);
                            double s1 = side1 * scalingFactor;
                            double s2 = side2 * scalingFactor;
                            double s3 = side3 * scalingFactor;
                            //point 2 location
                            double x = (Math.Pow(s1, 2) + Math.Pow(s3, 2) - Math.Pow(s2, 2)) / (2 * s1);
                            double y = Math.Sqrt(Math.Pow(s3, 2) - Math.Pow(x, 2));
                            return Geometry.Parse($"M{StrokeThickness / 2},{StrokeThickness / 2} H{s1 - StrokeThickness / 2} L{x - StrokeThickness / 2},{y - StrokeThickness / 2} z");
                        }
                    }
                    break;
            }

            return values;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
