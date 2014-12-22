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

namespace TheControlTower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FlightWindow flghtWndw = new FlightWindow();
        public MainWindow()
        {
            Binding flightCdeBinding = new Binding("flightCode");
            InitializeComponent();
            GridViewColumn gvc = new GridViewColumn();
            flghtWndw.takeOff += OnTakeOff;
            flghtWndw.changeRoute += OnChangeRoute;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ValidateUsersInput();
        }
        /// <summary>
        /// Converts the bitmap to imgsource
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

        public void OnTakeOff(object sender, TakeOffEvent tke)
        {
            flightDataLst.Items.Add(tke);
        }

        public void OnChangeRoute(object sender, ChangeRouteEvent cre)
        {
            flightDataLst.Items.Add(cre);
        }
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

        private void ValidateUsersInput()
        {
            if (InputValidator(flightCode.Text))
            {
                Plane plane = new Plane(flightCode.Text, "sent to runway", DateTime.Now.ToString("hh:mm:ss"));
                flightDataLst.Items.Add(plane);
                flghtWndw.Title = flightCode.Text;
                if (flightCode.Text.Trim().StartsWith("AA"))
                {
                    flghtWndw.planeImg.Source = ToBitmapSource(Properties.Resources.img1);
                }
                else if (flightCode.Text.Trim().StartsWith("AFR"))
                {
                    flghtWndw.planeImg.Source = ToBitmapSource(Properties.Resources.img2);
                }
                else if (flightCode.Text.Trim().StartsWith("OE"))
                {
                    flghtWndw.planeImg.Source = ToBitmapSource(Properties.Resources.img3);
                }
                else
                {
                    flghtWndw.planeImg.Source = ToBitmapSource(Properties.Resources.img4);
                }
                flghtWndw.Show();
            }
            else
            {
                MessageBox.Show("The flight code is required", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                flightCode.Focus();
            }
        }
    }
}
