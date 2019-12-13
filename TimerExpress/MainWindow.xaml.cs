using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
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
    public partial class MainWindow : Window {

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
    }
}
