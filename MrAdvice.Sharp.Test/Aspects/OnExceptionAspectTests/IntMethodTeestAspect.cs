using MrAdvice.Sharp.Aspects;
using MrAdvice.Sharp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrAdvice.Sharp.Test.Aspects.OnExceptionAspectTests
{
    public class IntMethodTeestAspect : OnExceptionAspect
    {
        public static int DefaultReturnVale = 10;
        public override void OnException(MethodExecutionArgs args)
        {
            args.SetReturnValue(DefaultReturnVale);
        }
    }
}
