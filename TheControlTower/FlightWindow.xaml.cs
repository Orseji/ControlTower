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
using System.Windows.Shapes;
using TheControlTower.events;
using TheControlTower.planes;

namespace TheControlTower
{
    /// <summary>
    /// Interaction logic for FlightWindow.xaml
    /// </summary>
    public delegate void TakeOffDelegate(object sender, TakeOffEvent toe);
    public partial class FlightWindow : Window
    {
        public event TakeOffDelegate takeOff;
        public FlightWindow()
        {
            InitializeComponent();
        }

        public void TakeOff()
        {
            Plane takeOffPlane = new Plane("aa", "Take off", DateTime.Now.ToString("hh:mm:ss"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            TakeOffEvent takeOffs = new TakeOffEvent(new Plane("a", "b", "c"));
            if (takeOffs != null)
            {
                takeOff(this, takeOffs);
            }
        }
    }
}
