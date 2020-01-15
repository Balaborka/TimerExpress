using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TimerExpress {
    public class StateToVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (parameter.ToString() == "startTile") {
                if ((TimerState)value == TimerState.Started)
                    return "Collapsed";
                return "Visible";
            }
            if (parameter.ToString() == "stopTile") {
                if ((TimerState)value == TimerState.Stopped)
                    return "Collapsed";
                return "Visible";
            }
            if ((TimerState)value == TimerState.Stopped)
                return "Visible";
            return "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
