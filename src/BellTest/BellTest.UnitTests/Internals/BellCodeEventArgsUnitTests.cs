using BellTest.Internals;
using BellTest.UnitTests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BellTest.UnitTests.Internals
{
    [TestClass]
    public class BellCodeEventArgsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void BellCodeEventArgsClass_Constructor_SetsCodeReceivedTimePropertyToFirstParameter()
        {
            DateTime testParam0 = _rnd.NextDateTime();
            string testParam1 = _rnd.NextBellCode();

            BellCodeEventArgs testOutput = new BellCodeEventArgs(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.CodeReceivedTime);
        }

        [TestMethod]
        public void BellCodeEventArgsClass_Constructor_SetsCodePropertyToSecondParameter()
        {
            DateTime testParam0 = _rnd.NextDateTime();
            string testParam1 = _rnd.NextBellCode();

            BellCodeEventArgs testOutput = new BellCodeEventArgs(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Code);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
