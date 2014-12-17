using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheControlTower.planes
{
    /// <summary>
    /// Class plane
    /// </summary>
    class Plane
    {
        private string flightCode;
        private string status;
        private string time;

        public Plane()
        {
        }
        public Plane(string flightCode, string status, string time)
        {
            this.flightCode = flightCode;
            this.status = status;
            this.time = time;
        }

        public string FlightCode
        {
            get { return flightCode; }
            set { flightCode = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public override string ToString()
        {
            string format = string.Format("{0, 15} {1, 15} {2, 15}", this.flightCode, this.status, this.time);
            return format;
        }
    }
}
