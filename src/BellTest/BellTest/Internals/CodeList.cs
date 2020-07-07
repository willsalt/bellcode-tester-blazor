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
            new BellCode("1-2", "Pick up the phone"),
            new BellCode("2", "Train Entering Section"),
            new BellCode("2-1", "Train Out Of Section"),
            new BellCode("2-1", "Obstruction Removed"),
            new BellCode("4", "Is Line Clear for Class A Express Passenger Train?"),
            new BellCode("4-2", "Is Line Clear for Class A Express Passenger DMU?"),
            new BellCode("3-1", "Is Line Clear for Class B Ordinary Passenger Train?"),
            new BellCode("1-3", "Is Line Clear for Class B Branch Passenger Train?"),
            new BellCode("3-1-2", "Is Line Clear for Class B Ordinary Passenger DMU?"),
            new BellCode("3-1-3", "Is Line Clear for Class B Ordinary Passenger Autotrain?"),
            new BellCode("2-5-1", "Is Line Clear for Class B Footplate Experience Train?"),
            new BellCode("2-5-1-3", "Is Line Clear for Class B Footplate Experience Autotrain?"),
            new BellCode("2-2-1", "Is Line Clear for Class C ECS Train?"),
            new BellCode("2-2-1-2", "Is Line Clear for Class C ECS DMU?"),
            new BellCode("2-2-1-3", "Is Line Clear for Class C ECS Autotrain?"),
            new BellCode("5", "Is Line Clear for Class C Parcels or Fully Fitted Freight Train?"),
            new BellCode("3-2", "Is Line Clear for Class F Non-Stop Unfitted Freight Train?"),
            new BellCode("2-3", "Is Line Clear for Class G Light Engine or Engines?"),
            new BellCode("1-1-3", "Is Line Clear for Class G Engine and no more than two Brake Vans?"),
            new BellCode("1-4", "Is Line Clear for Class H Stopping Unfitted Freight Train?"),
            new BellCode("2-2-3", "Is Line Clear for Class H Freight, Ballast or Special Train requiring to stop in section?"),
            new BellCode("2-1-2", "Is Line Clear for Trolley requiring to occupy the line"),
            new BellCode("3-5-5", "Warning Acceptance"),
            new BellCode("2-2", "Engine assisting in rear"),
            new BellCode("2-3-1", "Engine with one or two brake vans assisting in rear"),
            new BellCode("3-3", "Blocking Back"),
            new BellCode("5-2", "Release Token"),
            new BellCode("2-5", "Token Replaced"),
            new BellCode("7", "Stop and Examine Train"),
            new BellCode("9", "Train Entering Section Without Tail Lamp"),
            new BellCode("4-5", "Train Passed Without Tail Lamp"),
            new BellCode("6", "Obstruction Danger"),
            new BellCode("5-5-5", "Opening Signalbox"),
            new BellCode("7-5-5", "Closing Signalbox"),
            new BellCode("5-5-7", "Switching Signalbox Out"),
            new BellCode("16", "Testing Bells and Instruments"),
            new BellCode("4-4-4-4", "Transferring Tokens"),
            new BellCode("8-2", "Distant Signal Defective"),
            new BellCode("2-8", "Home Signal Defective"),
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
