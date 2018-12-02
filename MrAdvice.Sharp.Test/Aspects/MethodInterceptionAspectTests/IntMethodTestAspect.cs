using MrAdvice.Sharp.Aspects;
using MrAdvice.Sharp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Test.Aspects.MethodInterceptionAspectTests
{
    public class IntMethodTestAspect:MethodInterceptionAspect
    {
        public const int defaultInputParameter = 10;
        public const int defaultReturnParameter = 20;
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            args.Arguments[0] = defaultInputParameter;
            base.OnInvoke(args);
            //or you can use args.Proceed()
            args.SetReturnValue(defaultReturnParameter);
        }

        public override async Task OnInvokeAsync(MethodInterceptionArgs args)
        {
            args.Arguments[0] = defaultInputParameter;
            await args.ProceedAsync();
            //or you can use await base.OnInvokeAsync(args);
            args.SetReturnValue(defaultReturnParameter);
        }
    }
}
