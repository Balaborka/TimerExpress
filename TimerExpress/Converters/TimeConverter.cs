using System;
using System.Globalization;
using System.Windows.Data;

namespace TimerExpress {
    public class TimeConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if ((int)value < 10)
                value = "0" + value;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
