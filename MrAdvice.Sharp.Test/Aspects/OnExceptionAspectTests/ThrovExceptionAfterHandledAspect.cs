using MrAdvice.Sharp.Aspects;
using MrAdvice.Sharp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrAdvice.Sharp.Test.Aspects.OnExceptionAspectTests
{
    public class ThrovExceptionAfterHandledAspect : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            args.FlowBehavior = FlowBehavior.ThrowException;
        }
    }
}
