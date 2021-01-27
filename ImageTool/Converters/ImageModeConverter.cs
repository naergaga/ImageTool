using ImageTool.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace ImageTool.Converters
{
    class ImageModeConverter : IValueConverter
    {
        private static Dictionary<string, ImageMode> map = new Dictionary<string, ImageMode>() {
            {"0",ImageMode.Rotate },
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ImageMode)value == map[(string)parameter];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return map[(string)parameter];
        }
    }
}
