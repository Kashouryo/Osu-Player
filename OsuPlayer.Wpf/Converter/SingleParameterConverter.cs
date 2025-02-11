﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Milky.OsuPlayer.Converter
{
    public class SingleParameterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolean;
            switch (parameter)
            {
                case string s:
                    boolean = bool.Parse(s);
                    break;
                case bool b:
                    boolean = b;
                    break;
                default:
                    boolean = System.Convert.ToBoolean(parameter);
                    break;
            }

            if (targetType == typeof(bool))
            {
                switch (value)
                {
                    case string s:
                        return boolean ? !string.IsNullOrEmpty(s) : string.IsNullOrEmpty(s);
                    default:
                        throw new NotImplementedException();
                }

            }

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class KeyValueLogic
    {
        public Type SourceType { get; set; }
        public Type TargetType { get; set; }

    }

    public interface ISourceTargetLogic
    {
        Type SourceType { get; set; }
        Type TargetType { get; set; }

        object Convert();
        object NegativeConvert();
    }
}