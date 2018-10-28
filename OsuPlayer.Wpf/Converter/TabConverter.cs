﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Milkitic.OsuPlayer.Converter
{
    public static class HeaderParams
    {
        public static double Multiplier { get; set; } = 0.7;
    }
    public class TabHeaderLineX1Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double?)value * (1 - HeaderParams.Multiplier) / 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TabHeaderLineX2Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double?)value * (1 - HeaderParams.Multiplier) / 2 + (double?)value * HeaderParams.Multiplier;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
