using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrAdvice.Sharp.Test.Aspects.OnMethodBoundaryAspectTests
{
    [TestClass]
    public class OnMethodBoundaryAspectTest
    {
        [TestMethod]
        public void Set_Return_Value_Properties_Success()
        {
            var returnValue = SomeTestClass.GetSomeTestClass();

            Assert.AreEqual(1, returnValue.OnEntryProperty);
            Assert.AreEqual(1, returnValue.OnSuccessProperty);
            Assert.AreEqual(1, returnValue.OnExitProperty);
            Assert.AreEqual(0, returnValue.OnExceptionProperty);
        }
    }
}
