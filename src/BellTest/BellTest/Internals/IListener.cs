using System;
using System.Collections.Generic;

namespace BellTest.Internals
{
    public interface IListener
    {
        event BellCodeEventHandler BellCodeParsed;

        void RecordPush();

        void RecordRelease();

        IEnumerable<DateTime> GetData();
    }
}
