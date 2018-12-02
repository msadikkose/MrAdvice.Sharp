using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Test.Aspects.OnExceptionAspectTests
{
    [TestClass]
    public class OnExceptionAspectTest
    {
        private readonly int bar = 1;

        [TestMethod]
        public void Void_Method_Exception_Handled()
        {
            SomeClass someClass = new SomeClass();
            someClass.SomeVoidMethod(bar);
            Assert.AreEqual(bar, someClass.Bar);
        }

        [TestMethod]
        public async Task Async_Task_Method_Exception_Handled()
        {
            SomeClass someClass = new SomeClass();
            await someClass.SomeVoidMethodAsync(bar);
            Assert.AreEqual(bar, someClass.Bar);
        }

        [TestMethod]
        public void Int_Method_Exception_Handled()
        {
            SomeClass someClass = new SomeClass();
            int result = someClass.ReturnIntegerMethod();
            Assert.AreEqual(IntMethodTestAspect.DefaultReturnVale, result);
        }

        [TestMethod]
        public async Task Async_Int_Method_Exception_Handled()
        {
            SomeClass someClass = new SomeClass();
            int result = await someClass.ReturnIntegerMethodAsync();
            Assert.AreEqual(IntMethodTestAspect.DefaultReturnVale, result);
        }

        [TestMethod]
        public void Void_Method_Exception_Handled_And_Throwed()
        {
            SomeClass someClass = new SomeClass();
            Assert.ThrowsException<AggregateException>(() => someClass.SomeVoidMethodAndThrow(bar));
            Assert.AreEqual(bar, someClass.Bar);
        }

        [TestMethod]
        public async Task Async_Task_Method_Exception_Handled_And_Throwed()
        {
            SomeClass someClass = new SomeClass();
            await Assert.ThrowsExceptionAsync<Exception>(async () => await someClass.SomeVoidMethodThrowAsync(bar));
            Assert.AreEqual(bar, someClass.Bar);
        }
    }
}