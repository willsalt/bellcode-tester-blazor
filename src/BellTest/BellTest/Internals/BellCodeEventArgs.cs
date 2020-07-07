using System;

namespace BellTest.Internals
{
    public class BellCodeEventArgs : EventArgs
    {
        public DateTime CodeReceivedTime { get; private set; }

        public string Code { get; private set; }

        public BellCodeEventArgs(DateTime receivedAt, string code)
        {
            CodeReceivedTime = receivedAt;
            Code = code;
        }
    }
}
