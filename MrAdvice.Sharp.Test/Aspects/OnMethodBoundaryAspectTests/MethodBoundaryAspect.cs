using MrAdvice.Sharp.Aspects;
using MrAdvice.Sharp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrAdvice.Sharp.Test.Aspects.OnMethodBoundaryAspectTests
{
    public class MethodBoundaryAspect : OnMethodBoundaryAspect
    {
        SomeTestClass SomeTestClass = new SomeTestClass();
        public override void OnEntry(MethodExecutionArgs args)
        {
            SomeTestClass.OnEntryProperty = 1;
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            SomeTestClass.OnSuccessProperty = 1;
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            SomeTestClass.OnExitProperty = 1;
            args.SetReturnValue(SomeTestClass);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            SomeTestClass.OnExceptionProperty = 1;
        }

    }
}
