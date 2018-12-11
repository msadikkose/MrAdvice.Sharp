using MrAdvice.Sharp.Aspects;
using MrAdvice.Sharp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrAdvice.Sharp.Test.Aspects.MethodImplementationAspectTests
{
    public class TestAspect : MethodImplementationAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var someTest = args.Arguments[0] as SomeTestClass;
            someTest.Property = 20;
            someTest.OtherProperty = 20;
            args.SetReturnValue(someTest.Property*someTest.OtherProperty);
        }
    }
}
