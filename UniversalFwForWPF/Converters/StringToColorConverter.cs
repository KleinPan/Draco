using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

using UniversalFwForWPF.Datas;

namespace UniversalFwForWPF.Converters
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CheckResultEnum status = (CheckResultEnum)value;

            if (status == CheckResultEnum.fail)
            {
                return new System.Windows.Media.SolidColorBrush(Color.FromRgb(252, 57, 90));//红色


            }

            else if (status == CheckResultEnum.pass)
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
