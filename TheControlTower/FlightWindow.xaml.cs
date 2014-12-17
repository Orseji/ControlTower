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

namespace TheControlTower
{
    /// <summary>
    /// Interaction logic for FlightWindow.xaml
    /// </summary>
    public delegate void TakeOffDelegate(object sender, TakeOffEvent toe);
    public partial class FlightWindow : Window
    {
        public event TakeOffDelegate TakeOffEvnt;
        public FlightWindow()
        {
            InitializeComponent();
        }

        public void OnTakeOff(TakeOffEvent takeOffEvent)
        {
            if (TakeOffEvnt != null)
            {
                TakeOffEvnt(this, takeOffEvent);
            }
        }
    }
}
