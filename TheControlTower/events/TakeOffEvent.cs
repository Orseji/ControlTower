using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheControlTower.planes;

namespace TheControlTower.events
{

    class TakeOffEvent : EventArgs
    {
        private string flightCode;
        private string status;
        private string time;

        public TakeOffEvent(Plane plane)
        {
            plane.FlightCode = flightCode;
            plane.Status = status;
            plane.Time = time;
        }
    }
}
