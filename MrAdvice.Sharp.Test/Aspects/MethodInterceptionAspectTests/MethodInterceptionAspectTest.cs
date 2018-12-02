using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Test.Aspects.MethodInterceptionAspectTests
{
    [TestClass]
    public class MethodInterceptionAspectTest
    {
        readonly int bar = 1;
        [TestMethod]
        public void Void_Method_Intercepted_Parameter_Changed()
        {
            SomeTestClass someClass = new SomeTestClass();
            someClass.SomeVoidMethod(bar);
            Assert.AreEqual(VoidMethodTestAspect.defaultInputParameter, someClass.Bar);
        }

        [TestMethod]
        public async Task Async_Task_Method_Intercepted_Parameter_Changed()
        {
            SomeTestClass someClass = new SomeTestClass();
            await someClass.SomeVoidMethodAsync(bar);
            Assert.AreEqual(VoidMethodTestAspect.defaultInputParameter, someClass.Bar);
        }



        [TestMethod]
        public void Int_Method_Exception_Handled()
        {
            SomeTestClass someClass = new SomeTestClass();
            int result = someClass.ReturnIntegerMethod(bar);
            Assert.AreEqual(IntMethodTestAspect.defaultInputParameter, someClass.Bar);
            Assert.AreEqual(IntMethodTestAspect.defaultReturnParameter, result);
        }

        [TestMethod]
        public async Task Async_Int_Method_Exception_Handled()
        {
            SomeTestClass someClass = new SomeTestClass();
            int result = await someClass.ReturnIntegerMethodAsync(bar);
            Assert.AreEqual(IntMethodTestAspect.defaultInputParameter, someClass.Bar);
            Assert.AreEqual(IntMethodTestAspect.defaultReturnParameter, result);
        }

    }
}
