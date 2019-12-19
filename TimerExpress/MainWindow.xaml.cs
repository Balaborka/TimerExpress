using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

namespace TimerExpress {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow {
        public override void OnApplyTemplate() {
            base.OnApplyTemplate();
            DockPanel t = (DockPanel)GetTemplateChild("PART_WindowHeaderContentAndStatusPanel");
            t.Background = Brushes.LightGreen;
            ThemedWindowHeader header = (ThemedWindowHeader)GetTemplateChild("PART_HeaderBorder");
            header.Background = Brushes.LightGreen;
            ThemedWindowContentBorder contentBorder = (ThemedWindowContentBorder)GetTemplateChild("PART_ContentBackgroundBorder");
            contentBorder.BorderBrush = Brushes.LightGreen;
        }
        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;
        }

        private void StartTile_Click(object sender, EventArgs e) {
            myTimer.Start();
        }

        private void StopTile_Click(object sender, EventArgs e) {
            if (myTimer.State == TimerState.Started) {
                myTimer.Pause();
            }
            else {
                myTimer.Stop();
            }
        }

        private void SettingsTile_Click(object sender, EventArgs e) {

        }
    }
    public class StateToVisibilitySettingsConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value.ToString() == "Stopped")
                return "Visible";
            return "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    public class StateToVisibilityStartConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value.ToString() == "Started")
                return "Collapsed";
            return "Visible";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    public class StateToVisibilityStopConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value.ToString() == "Stopped")
                return "Collapsed";
            return "Visible";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
