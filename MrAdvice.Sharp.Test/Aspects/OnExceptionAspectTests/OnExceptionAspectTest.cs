using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MrAdvice.Sharp.Test.Aspects.OnExceptionAspectTests
{
    [TestClass]
    public class OnExceptionAspectTest
    {
        [TestMethod]
        public void Void_Method_Exception_Handled()
        {
            SomeClass someClass = new SomeClass();
            someClass.SomeMethod();
        }
    }
}
