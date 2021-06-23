﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace UniversalFwForWPF.Converters
{
    public class IntToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {


            int source = System.Convert.ToInt32(value);
            int para = System.Convert.ToInt32(parameter);

            if (source == para)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int source = System.Convert.ToInt32(value);
            int para = System.Convert.ToInt32(parameter);

            if (source == para)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
