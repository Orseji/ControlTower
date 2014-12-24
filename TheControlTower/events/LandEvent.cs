using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TheControlTower.planes;

namespace TheControlTower.events
{
    public class LandEvent : EventArgs
    {   
        private string flightCode;
        private string status;
        private string time;
        public LandEvent()
        {

        }
        public LandEvent(Plane plane)
        {
            flightCode = plane.FlightCode;
            status = plane.Status;
            time = plane.Time;
        }
        public string FlightCode
        {
            get{ return flightCode; }
            set{ flightCode = value; }
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

        public void PlaySound()
        {
            try
            {
                Uri uri = new Uri(@"pack://application:,,,/Resources/audio1.wav");
                SoundPlayer mPlayer = new SoundPlayer(@"C:\Users\Orgi\Downloads\audio.wav");
                mPlayer.Play();
            }
            catch (NotSupportedException ex)
            {
                throw;
            }
            
        }
    }
}
