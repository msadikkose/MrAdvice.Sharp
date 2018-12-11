using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrAdvice.Sharp.Test.Aspects.MethodImplementationAspectTests
{
    [TestClass]
    public class MethodImplementationAspectTest
    {
        [TestMethod]
        public void Method_Implementation_Success()
        {
            SomeTestClass someTest = new SomeTestClass();

            someTest.Property = 10;
            someTest.OtherProperty = 5;

            int result = someTest.DummyCalculation(someTest);
            Assert.AreEqual(400, result);
            Assert.AreEqual(20, someTest.Property);
            Assert.AreEqual(20, someTest.OtherProperty);

        }
    }
}
