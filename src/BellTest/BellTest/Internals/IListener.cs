using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
