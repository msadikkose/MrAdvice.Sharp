using System;
using System.Collections.Generic;
using System.Text;

namespace MrAdvice.Sharp.Test.Aspects.OnMethodBoundaryAspectTests
{
    public class SomeTestClass
    {
        public int OnEntryProperty { get; set; }
        public int OnSuccessProperty { get; set; }
        public int OnExitProperty { get; set; }
        public int OnExceptionProperty { get; set; }

        [MethodBoundaryAspect]
        public static SomeTestClass GetSomeTestClass()
        {
            return new SomeTestClass();
        }
    }
}
