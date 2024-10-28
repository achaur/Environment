using System;
using System.Windows.Data;
using System.Globalization;

namespace Environment.Windows
{
    /// <summary>
    /// Returns first error if any input has error. Usable for error message if any error in binded controls
    /// </summary>
    public class InvertBooleanConverter : IValueConverter, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                bool boolValue = (bool)value;
                
                return !boolValue;
            }
            catch(Exception) 
            {
                return false;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
