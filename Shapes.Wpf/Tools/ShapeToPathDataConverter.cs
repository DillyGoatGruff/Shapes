using Shapes.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Shapes.Wpf.Tools
{
    internal class ShapeToPathDataConverter : IValueConverter
    {
        public double StrokeThickness { get; set; } = 3;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double scalingFactor;
            switch (value)
            {
                case Circle:
                    return Geometry.Parse($"M {0 + StrokeThickness / 2},{50 + StrokeThickness / 2} A{50 - StrokeThickness / 2},{50 - StrokeThickness / 2} 0 1 1 {100 - StrokeThickness / 2},{50 - StrokeThickness / 2} A {50 - StrokeThickness / 2},{50 - StrokeThickness / 2} 0 1 1 {0 + StrokeThickness / 2},{50 + StrokeThickness / 2}");
                case Square s:
                    return Geometry.Parse($"M{StrokeThickness / 2},{StrokeThickness / 2} H{100 - StrokeThickness / 2} V{100 - StrokeThickness / 2} H{StrokeThickness / 2} Z");
                case Models.Rectangle r:
                    scalingFactor = 100 / Math.Max(r.Length.Value, r.Width.Value);
                    double scaledLength = r.Length.Value * scalingFactor - StrokeThickness / 2;
                    double scaledWidth = r.Width.Value * scalingFactor - StrokeThickness - 2;
                    return Geometry.Parse($"M{StrokeThickness / 2},{StrokeThickness / 2} H{scaledWidth} V{scaledLength} H{StrokeThickness / 2} Z");
                case Triangle t:
                    scalingFactor = 100 / Math.Max(Math.Max(t.Side1.Value, t.Side2.Value), t.Side3.Value);
                    double s1 = t.Side1.Value * scalingFactor;
                    double s2 = t.Side2.Value * scalingFactor;
                    double s3 = t.Side3.Value * scalingFactor;
                    //point 2 location
                    double x = (Math.Pow(s1, 2) + Math.Pow(s3, 2) - Math.Pow(s2, 2)) / (2 * s1);
                    double y = Math.Sqrt(Math.Pow(s3, 2) - Math.Pow(x, 2));
                    return Geometry.Parse($"M{StrokeThickness / 2},{StrokeThickness / 2} H{s1 - StrokeThickness / 2} L{x - StrokeThickness / 2},{y - StrokeThickness / 2} z");
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
