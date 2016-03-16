
using System;
using System.Globalization;
using System.Windows.Data;
using VkNet.Model.Attachments;

namespace ExmpleApp.PlayerModule.Converters
{

    public class DurationToTimeSpan : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TimeSpan.FromSeconds(System.Convert.ToDouble(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value;
        }
    }
}