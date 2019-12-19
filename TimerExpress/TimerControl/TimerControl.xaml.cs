using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TimerExpress {
    /// <summary>
    /// Interaction logic for TimerControl.xaml
    /// </summary>
   
    public partial class TimerControl : UserControl, INotifyPropertyChanged {

        public int DurationMin { get; set; }

        public TimerState State {
            get => state;
            private set {
                state = value;
                NotifyPropertyChanged();
            }
        }

        public int IncrementSec {
            get => incrementSec; 
            set {
                incrementSec = value;
                NotifyPropertyChanged();
            }
        }
        public int IncrementMin {
            get => incrementMin;
            set {
                incrementMin = value;
                NotifyPropertyChanged();
            }
        }

        private TimerState state;
        private int incrementSec;
        private int incrementMin;
        DispatcherTimer dt;
        INotifyIconService notifyIconService;


        public TimerControl() {
            InitializeComponent();
            this.DataContext = this;

            DurationMin = 45;
            IncrementSec = 0;

            IncrementMin = DurationMin;
            State = TimerState.Stopped;
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;

            notifyIconService = ServiceWithDefaultNotifyIcons;
        }

        public void ShowDefaultNotification() {
            INotification notification = ServiceWithDefaultNotifications.CreatePredefinedNotification("ALARM", "Time is running out!", String.Format("Hurry Up!"), new BitmapImage(new Uri("Images/OMG.png", UriKind.Relative)));
            notification.ShowAsync();
        }

        public void Start() {
            if (State == TimerState.Started)
                return;
            else if (State == TimerState.Stopped)
                IncrementMin = DurationMin;
            dt.Start();

            notifyIconService.SetStatusIcon("Started");
        }

        public void Pause() {
            if (State == TimerState.Paused)
                return;
            dt.Stop();
            State = TimerState.Paused;
            notifyIconService.SetStatusIcon("Paused");
        }

        public void Stop() {
            dt.Stop();
            IncrementMin = DurationMin;
            IncrementSec = 0;
            State = TimerState.Stopped;
            notifyIconService.SetStatusIcon("Stopped");
        }

        private void dtTicker(object sender, EventArgs e) {
            if (IncrementSec > 0) {
                IncrementSec--;
            }
            else {
                IncrementSec = 59;
                if (IncrementMin > 0)
                    IncrementMin--;
            }
            if (IncrementMin == 0 && IncrementSec == 0) {
                Stop();
                ShowDefaultNotification();
                return;
            }
            State = TimerState.Started;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum TimerState {
        Started,
        Paused,
        Stopped
    }

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
