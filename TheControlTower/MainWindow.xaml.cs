/*Namn: Orgi Sejdini
 * ID: AC8699
 * Date: 20/12/14
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheControlTower.events;
using TheControlTower.planes;
using TheControlTower.sounds;

namespace TheControlTower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// It is also the subscriber of the FlightWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        private FlightWindow flghtWndw;
        PlaySound sound = new PlaySound();
        public MainWindow()
        {
            InitializeComponent();
            Binding flightCdeBinding = new Binding("flightCode");
            GridViewColumn gvc = new GridViewColumn();
        }
        /// <summary>
        /// Adds the plane in the list when send plane to runway is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ValidateUsersInput();
        }
        /// <summary>
        /// Converts the bitmap to imgsource
        /// This one is taken from google 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ImageSource ToBitmapSource(Bitmap source)
        {
            IntPtr hBitmap = source.GetHbitmap();
            ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            source.Dispose();
            return wpfBitmap;
        }
        /// <summary>
        /// Adds takeoff into the list when the button takeoff in FlightWindow is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="tke"></param>
        public void OnTakeOff(object sender, TakeOffEvent tke)
        {
            flightDataLst.Items.Add(tke);
        }
        /// <summary>
        /// Adds ChangeRoute into the list when the combobox in FlightWindow is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="cre"></param>
        public void OnChangeRoute(object sender, ChangeRouteEvent cre)
        {
            flightDataLst.Items.Add(cre);
        }
        /// <summary>
        /// Adds landevent into the list when the button land in FlightWindow is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="le"></param>
        public void OnLand(object sender, LandEvent le)
        {
            flightDataLst.Items.Add(le);
        }

        /// <summary>
        /// Validator that is used for validating if input is made
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool InputValidator(string input)
        {
            bool inputOk;
            if (string.IsNullOrEmpty(input))
            {
                inputOk = false;
            }
            else
            {
                inputOk = true;
            }
            return inputOk;
        }
        /// <summary>
        /// Creates an instance of the publisher, FlightWindow
        /// an the subscriber subscribes to the events. 
        /// </summary>
        private void ShowPlaneWindow()
        {
            flghtWndw = new FlightWindow();
            flghtWndw.Title = flightCode.Text;
            flghtWndw.takeOff += OnTakeOff;
            flghtWndw.changeRoute += OnChangeRoute;
            flghtWndw.land += OnLand;
            flghtWndw.land += sound.OnLand;

            if (flightCode.Text.Trim().StartsWith("AA", StringComparison.OrdinalIgnoreCase))
            {
                flghtWndw.planeImg.Source = ToBitmapSource(Properties.Resources.img1);
            }
            else if (flightCode.Text.Trim().StartsWith("AFR", StringComparison.OrdinalIgnoreCase))
            {
                flghtWndw.planeImg.Source = ToBitmapSource(Properties.Resources.img2);
            }
            else if (flightCode.Text.Trim().StartsWith("OE", StringComparison.OrdinalIgnoreCase))
            {
                flghtWndw.planeImg.Source = ToBitmapSource(Properties.Resources.img3);
            }
            else
            {
                flghtWndw.planeImg.Source = ToBitmapSource(Properties.Resources.img4);
            }

            flghtWndw.Show();
        }
        /// <summary>
        /// Validates if the user has made inputs to the textfield. If so creates a plane and adds it in the flightDataLst
        /// </summary>
        private void ValidateUsersInput()
        {
            if (InputValidator(flightCode.Text))
            {
                Plane plane = new Plane(flightCode.Text, "sent to runway", DateTime.Now.ToString("hh:mm:ss"));
                flightDataLst.Items.Add(plane);
                ShowPlaneWindow();
                flightCode.Text = string.Empty;

            }
            else
            {
                MessageBox.Show("The flight code is required", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                flightCode.Focus();
            }
        }
    }
}
