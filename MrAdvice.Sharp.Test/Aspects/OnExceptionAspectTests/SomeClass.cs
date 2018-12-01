using System;
using System.Collections.Generic;
using System.Text;

namespace MrAdvice.Sharp.Test.Aspects.OnExceptionAspectTests
{
    [TestAspect]
    public class SomeClass
    {
        public void SomeMethod()
        {
            throw new NotImplementedException();
        }
    }
}
