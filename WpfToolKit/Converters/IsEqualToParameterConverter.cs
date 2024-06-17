using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfToolkit.Converters
{
    public class IsEqualToParameterConverter : IValueConverter
    {
        public object EqualsValue { get; set; } = true;
        public object NotEqualsValue { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null && parameter is null)
            {
                return EqualsValue;
            }

            if (value?.Equals(parameter)  == true)
            {
                return EqualsValue;
            }

            return NotEqualsValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
