using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace TimerExpress.ViewModel {
    [POCOViewModel]
    public class TimerViewModel {

        [ServiceProperty(Key = "ServiceWithDefaultNotifications")]
        protected virtual INotificationService DefaultNotificationService { get { return null; } }
        protected INotifyIconService NotifyIconService { get { return this.GetService<INotifyIconService>(); } }


        public virtual TimerModel Timer { get; set; }
        public virtual int IncrementMin { get; set; }
        public virtual int IncrementSec { get; set; }

        DispatcherTimer dt;

        public TimerViewModel() {
            Timer = new TimerModel();

            IncrementMin = 45;
            Timer.DurationMin = IncrementMin;

            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
        }

        public void Start() {
            if (Timer.State == TimerState.Started)
                return;
            else if (Timer.State == TimerState.Stopped)
                IncrementMin = Timer.DurationMin;
            dt.Start();

            NotifyIconService.SetStatusIcon("Started");
        }

        public void Pause() {
            if (Timer.State == TimerState.Paused)
                return;
            dt.Stop();
            Timer.State = TimerState.Paused;

            NotifyIconService.SetStatusIcon("Paused");
        }

        public void Stop() {
            dt.Stop();
            IncrementMin = Timer.DurationMin;
            IncrementSec = 0;
            Timer.State = TimerState.Stopped;

            NotifyIconService.SetStatusIcon("Stopped");
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
            Timer.State = TimerState.Started;
        }

        public void ShowDefaultNotification() {
            INotification notification = DefaultNotificationService.CreatePredefinedNotification("ALARM", "Time is running out!", String.Format("Hurry Up!"), new BitmapImage(new Uri("Images/OMG.png", UriKind.Relative)));
            notification.ShowAsync();
        }
    }
}
