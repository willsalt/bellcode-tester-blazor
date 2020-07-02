using System;
using System.Collections.Generic;
using System.Linq;

namespace BellTest.Internals
{
    public class CodeList : ICodeList
    {
        private readonly BellCode[] _codes = new BellCode[]
        {
            new BellCode("1", "Call Attention"),
            new BellCode("2", "Train Entering Section"),
            new BellCode("2-1", "Train Out Of Section"),
            new BellCode("2-1", "Obstruction Removed"),
            new BellCode("4", "Is Line Clear for Class A Passenger Train"),
            new BellCode("4-2", "Is Line Clear for Class A Passenger DMU"),
            new BellCode("3-1", "Is Line Clear for Class B Passenger Train"),
            new BellCode("3-1-2", "Is Line Clear for Class B Passenger DMU"),
            new BellCode("2-2-1", "Is Line Clear for Class C ECS Train"),
            new BellCode("2-2-1-2", "Is Line Clear for Class C ECS DMU"),
            new BellCode("5", "Is Line Clear for Class C Parcels Train"),
        };

        private static readonly Random _rnd = new Random();

        public BellCode GetRandomCode()
        {
            return _codes[_rnd.Next(_codes.Length)];
        }

        public IEnumerable<BellCode> GetAllCodes()
        {
            return _codes.ToArray();
        }
    }
}
