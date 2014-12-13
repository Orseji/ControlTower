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
            InitializeComponent();
            GridViewColumn gvc = new GridViewColumn();
            Binding flightCdeBinding = new Binding("flightCode");
            for (int i = 0; i < 50; i++)
            {
                flightDataLst.Items.Add(new Plane { FlightCode = "AFR2122", Status = "On Air", Time = "21" });
            }
        }

    }
}
