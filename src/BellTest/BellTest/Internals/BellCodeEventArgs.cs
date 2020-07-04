using System;

namespace BellTest.Internals
{
    public class BellCodeEventArgs : EventArgs
    {
        public DateTime CodeReceivedTime { get; set; }

        public string Code { get; set; }
    }
}
