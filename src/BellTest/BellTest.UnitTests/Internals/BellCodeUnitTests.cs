using BellTest.Internals;
using BellTest.UnitTests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BellTest.UnitTests.Internals
{
    [TestClass]
    public class BellCodeUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void BellCodeClass_Constructor_SetsCodePropertyToValueOfFirstParameter()
        {
            string testParam0 = _rnd.NextBellCode();
            string testParam1 = _rnd.NextString();

            BellCode testOutput = new BellCode(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.Code);
        }

        [TestMethod]
        public void BellCodeClass_Constructor_SetsDescriptionPropertyToValueOfSecondParameter()
        {
            string testParam0 = _rnd.NextBellCode();
            string testParam1 = _rnd.NextString();

            BellCode testOutput = new BellCode(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Description);
        }

        [TestMethod]
        public void BellCodeClass_ToStringMethod_ReturnsValueOfDescriptionProperty()
        {
            string testData0 = _rnd.NextBellCode();
            string testData1 = _rnd.NextString();
            BellCode testObject = new BellCode(testData0, testData1);

            string testOutput = testObject.ToString();

            Assert.AreEqual(testObject.Description, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
