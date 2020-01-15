using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.LayoutControl;
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
using TimerExpress.ViewModel;

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

        TimerViewModel VM;

        public MainWindow() {
            InitializeComponent();

            VM = ViewModelSource<TimerViewModel>.Create();
            this.DataContext = VM;

            EventManager.RegisterClassHandler(typeof(Tile), LoadedEvent, new RoutedEventHandler((d, e) => ((Tile)d).Padding = new Thickness(10)));
        }

        private void StartTile_Click(object sender, EventArgs e) {
            VM.Start();
        }

        private void StopTile_Click(object sender, EventArgs e) {
            if (VM.Timer.State == TimerState.Started) {
                VM.Pause();
            }
            else {
                VM.Stop();
            }
        }

        private void SettingsTile_Click(object sender, EventArgs e) {
            dpTimer.Visibility = Visibility.Collapsed;
            gridSettings.Visibility = Visibility.Visible;
        }

        private void CloseSettingsBtn_Click(object sender, RoutedEventArgs e) {
            timerMinuteLabel.Content = durationSettingBox.Text;
            gridSettings.Visibility = Visibility.Collapsed;
            dpTimer.Visibility = Visibility.Visible;
        }
    }
}
