using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MSTnTAPP.Converter
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is bool)
            {
                if((bool)value)
                {
                    return Color.White;
                }

                return Color.FromHex("#e2e8ee");
            }
            
            return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // This is not needed at this point, this is used to convert the other way around
            // so from color to true or false
            throw new NotImplementedException();
        }
    }
}
