using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheControlTower.planes;

namespace TheControlTower.events
{

    public class TakeOffEvent : EventArgs
    {
        private string flightCode;
        private string status;
        private string time;
        public TakeOffEvent()
        {

        }

        public TakeOffEvent(Plane plane)
        {
             flightCode = plane.FlightCode;
            status = plane.Status;
            time = plane.Time;
        }
    }
}
