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
    /// Interaction logic for TileBarControl.xaml
    /// </summary>
    public partial class TileBarControl : UserControl {

        public TileBarControl() {
            this.DataContext = this;

            InitializeComponent();
        }

        private void Hide_Click(object sender, RoutedEventArgs e) {

        }

        private void Close_Click(object sender, RoutedEventArgs e) {

        }
 
    }
}
