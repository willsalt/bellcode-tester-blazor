using BellTest.Internals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BellTest.UnitTests.Internals
{
    [TestClass]
    public class CodeListUnitTests
    {

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void CodeListClass_GetRandomCodeMethod_ReturnsNonNullValue()
        {
            CodeList testObject = new CodeList();

            BellCode testOutput = testObject.GetRandomCode();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void CodeListClass_GetRandomCodeMethod_ReturnsObjectWithValidCodeProperty()
        {
            CodeList testObject = new CodeList();

            BellCode testOutput = testObject.GetRandomCode();

            AssertStringIsValidBellCode(testOutput.Code);   
        }

        [TestMethod]
        public void CodeListClass_GetRandomCodeMethod_ReturnsObjectWithNonEmptyDescriptionProperty()
        {
            CodeList testObject = new CodeList();

            BellCode testOutput = testObject.GetRandomCode();

            Assert.IsFalse(string.IsNullOrWhiteSpace(testOutput.Description));
        }

        [TestMethod]
        public void CodeListClass_GetAllCodesMethod_ReturnsEnumerationWithContents()
        {
            CodeList testObject = new CodeList();

            IEnumerable<BellCode> testOutput = testObject.GetAllCodes();

            Assert.IsNotNull(testOutput);
            Assert.IsTrue(testOutput.Any());
        }

        [TestMethod]
        public void CodeListClass_GetAllCodesMethod_ReturnsEnumerationOfNonNullObjects()
        {
            CodeList testObject = new CodeList();

            IEnumerable<BellCode> testOutput = testObject.GetAllCodes();

            Assert.IsTrue(testOutput.All(c => c != null));
        }

        [TestMethod]
        public void CodeListClass_GetAllCodesMethod_ReturnsEnumerationOfObjectsWithValidCodeProperties()
        {
            CodeList testObject = new CodeList();

            IEnumerable<BellCode> testOutput = testObject.GetAllCodes();

            foreach (BellCode b in testOutput)
            {
                AssertStringIsValidBellCode(b.Code);
            }
        }

        [TestMethod]
        public void CodeListClass_GetAllCodesMethod_ReturnsEnumerationOfObjectsWithNonEmptyDescriptionProperties()
        {
            CodeList testObject = new CodeList();

            IEnumerable<BellCode> testOutput = testObject.GetAllCodes();

            Assert.IsTrue(testOutput.All(c => !string.IsNullOrWhiteSpace(c.Description)));
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

        private static void AssertStringIsValidBellCode(string code)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(code));
            string[] parts = code.Split('-');
            foreach (string grp in parts)
            {
                Assert.IsTrue(int.TryParse(grp, out _));
            }
        }
    }
}
