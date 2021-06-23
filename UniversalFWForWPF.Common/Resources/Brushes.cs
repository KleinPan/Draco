﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace UniversalFWForWPF.Common.Resources
{
    public sealed class Brushes
    {
        public static SolidColorBrush MethodColor
        {
            get
            {
                SolidColorBrush solidColorBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 116, 83, 37));
                solidColorBrush.Freeze();
                return solidColorBrush;
            }
        }
    }
}
