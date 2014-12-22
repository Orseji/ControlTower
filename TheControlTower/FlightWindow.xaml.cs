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
    public delegate void ChangeRouteDelegate(object sender, ChangeRouteEvent cre);
    public partial class FlightWindow : Window
    {
        public event TakeOffDelegate takeOff;
        public event ChangeRouteDelegate changeRoute;
        public FlightWindow()
        {
            InitializeComponent();
            PopulateCmbBox();
        }
        private void LoadWindow()
        {
           
        }
        public TakeOffEvent TakeOff()
        {
            Plane p = new Plane(this.Title, "Take off", DateTime.Now.ToString("hh:mm:ss"));
             TakeOffEvent takeOffPlane = new TakeOffEvent(p);
             return takeOffPlane;
        }
        public ChangeRouteEvent ChangeRoute()
        {
            Plane p = new Plane(this.Title, "changed route to " + changeRouteCmbBox.SelectedItem.ToString(), DateTime.Now.ToString("hh:mm:ss"));
            ChangeRouteEvent changeRoutePlane = new ChangeRouteEvent(p);
            return changeRoutePlane;
        }
        private void Land_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void TakeOff_Click(object sender, RoutedEventArgs e)
        {
            if (takeOff != null)
            {
                takeOff(this, TakeOff());
            }
        }
        private void PopulateCmbBox()
        {
            int degrees = 10;
            for (int i = 0; i < 5; i++)
            {
                degrees += 5;
                changeRouteCmbBox.Items.Add(degrees + "°");
            }
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (changeRoute != null)
            {
                changeRoute(this, ChangeRoute());
            }
        }
    }
}
