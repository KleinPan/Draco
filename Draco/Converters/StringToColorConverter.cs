using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

using Draco.Datas;

namespace Draco.Converters
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string res = value.ToString();
            if (res == "Fail")
            {
                return new System.Windows.Media.SolidColorBrush(Color.FromRgb(252, 57, 90));//红色


            }

            else if (res == "Pass")
            {
                return new System.Windows.Media.SolidColorBrush(Color.FromRgb(112, 255, 1));//绿色
            }
            else
            {
                return new System.Windows.Media.SolidColorBrush(Color.FromRgb(0, 0, 0));//黑色

            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
