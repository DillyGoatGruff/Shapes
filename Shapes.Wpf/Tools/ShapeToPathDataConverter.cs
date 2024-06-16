using Shapes.Mvvm.Models.Shapes;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Shapes.Wpf.Tools
{
    internal class ShapeToPathDataConverter : IValueConverter
    {
        private readonly DimensionsToPathMultiConverter _dimensionsToPathMultiConverter = new DimensionsToPathMultiConverter();
        
        public double StrokeThickness 
        { 
            get => _dimensionsToPathMultiConverter.StrokeThickness; 
            set => _dimensionsToPathMultiConverter.StrokeThickness = value; 
        }
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not IShape shape)
            {
                return value;
            }

            return _dimensionsToPathMultiConverter.Convert([shape.Type, shape.Dimensions], targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
