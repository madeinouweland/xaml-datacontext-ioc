using System;
using Windows.UI.Xaml.Data;

namespace DataContextIoC
{
    public class DataContextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // argument value is typed. Return as-is
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // argument value is object. Return as-is
            return value;
        }
    }
}
