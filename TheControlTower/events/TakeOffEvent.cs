using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheControlTower.events
{
    public  delegate string ReturnMessage(string message);
    class TakeOffEvent : EventArgs
    {

    }
}
