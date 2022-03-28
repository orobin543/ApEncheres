using System;
using System.Collections.Generic;
using System.Text;

namespace ApEnchere.Services
{
    public class TimerEventArgs : EventArgs
    {
        public TimeSpan TempsRestant { get; set; }

    }
}
