using System;
using System.Collections.Generic;
using System.Text;

namespace MrAdvice.Sharp.Test.Aspects.MethodImplementationAspectTests
{
    public class SomeTestClass
    {
        public int Property { get; set; }
        public int OtherProperty { get; set; }

        [TestAspect]
        public int DummyCalculation(SomeTestClass someTest)
        {
            return someTest.Property * OtherProperty;
        }
    }
}
