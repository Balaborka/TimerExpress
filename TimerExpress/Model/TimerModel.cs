using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TimerExpress {
    public class TimerModel : INotifyPropertyChanged {
        private int durationMin;
        public int DurationMin {
            get => durationMin;
            set {
                durationMin = value;
                NotifyPropertyChanged();
            }
        }

        private TimerState state = TimerState.Stopped;
        public TimerState State {
            get => state;
            set {
                state = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
