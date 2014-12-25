/*Namn: Orgi Sejdini
 * ID: AC8699
 * Date: 18/12/14
 */
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
    /// Flightwindow is also the publisher of the events 
    /// </summary>
    public delegate void TakeOffDelegate(object sender, TakeOffEvent toe);
    public delegate void ChangeRouteDelegate(object sender, ChangeRouteEvent cre);
    public delegate void LandDelegate(object sender, LandEvent le);
    public partial class FlightWindow : Window
    {
        /// <summary>
        /// Events that will be used to subscribe to the events. They are also used to check if there is any subscriber
        /// </summary>
        public event TakeOffDelegate takeOff;
        public event ChangeRouteDelegate changeRoute;
        public event LandDelegate land;
        public FlightWindow()
        {
            InitializeComponent();
            PopulateCmbBox();
        }
        /// <summary>
        /// Creates a plane that is taken as parameter in takeoffEvent
        /// </summary>
        /// <returns>return a takeOffEvent</returns>
        public TakeOffEvent TakeOff()
        {
            takeoffBtn.IsEnabled = false;
            changeRouteCmbBox.IsEnabled = true;
            landBtn.IsEnabled = true;
            Plane p = new Plane(this.Title, "Take Off", DateTime.Now.ToString("hh:mm:ss"));
            TakeOffEvent takeOffPlane = new TakeOffEvent(p);
            return takeOffPlane;
        }
        /// <summary>
        /// Creates a plane that is taken as parameter in landevent
        /// </summary>
        /// <returns></returns>
        public LandEvent Land()
        {
            takeoffBtn.IsEnabled = true;
            changeRouteCmbBox.IsEnabled = false;
            landBtn.IsEnabled = false;
            Plane p = new Plane(this.Title, "landed", DateTime.Now.ToString("hh:mm:ss"));
            LandEvent land = new LandEvent(p);
            this.Close();
            return land;
        }
        /// <summary>
        /// Creates a plane that is talen as parameter in changerouteevent
        /// </summary>
        /// <returns></returns>
        public ChangeRouteEvent ChangeRoute()
        {
            Plane p = new Plane(this.Title, "changed route to " + changeRouteCmbBox.SelectedItem.ToString(), DateTime.Now.ToString("hh:mm:ss"));
            ChangeRouteEvent changeRoutePlane = new ChangeRouteEvent(p);
            return changeRoutePlane;
        }

        /// <summary>
        /// When Land button is clicked it checks if there is any subscriber
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Land_Click(object sender, RoutedEventArgs e)
        {
            if (land != null)
            {
                land(this, Land());
            }
        }
        /// <summary>
        /// when takeOff button is clicked it checks if there is any subscriber
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TakeOff_Click(object sender, RoutedEventArgs e)
        {
            if (takeOff != null)
            {
                takeOff(this, TakeOff());
            }
        }
        /// <summary>
        /// Populates the cmbbox with route degrees
        /// </summary>
        private void PopulateCmbBox()
        {
            int degrees = 10;
            for (int i = 0; i < 40; i++)
            {
                degrees += 5;
                changeRouteCmbBox.Items.Add(degrees + "°");
            }
        }
        /// <summary>
        /// when changeroutecmbbox is changed it checks if there is any subscriber
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (changeRoute != null)
            {
                changeRoute(this, ChangeRoute());
            }
        }
    }
}
