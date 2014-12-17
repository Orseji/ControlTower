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
using TheControlTower.planes;

namespace TheControlTower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Binding flightCdeBinding = new Binding("flightCode");
            InitializeComponent();
            GridViewColumn gvc = new GridViewColumn();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Plane plane = new Plane(flightCode.Text, "sent to runway", DateTime.Now.ToString("hh:mm:ss"));
            flightDataLst.Items.Add(plane);
            FlightWindow flghtWndw = new FlightWindow();
            flghtWndw.Show();
        }

    }
}
