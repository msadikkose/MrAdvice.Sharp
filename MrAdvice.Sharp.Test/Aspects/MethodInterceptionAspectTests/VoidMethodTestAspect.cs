using MrAdvice.Sharp.Aspects;
using MrAdvice.Sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Test.Aspects.MethodInterceptionAspectTests
{
    public class VoidMethodTestAspect:MethodInterceptionAspect
    {
        
        public const int defaultInputParameter = 10;
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var inputArg = args.Arguments.First();
            args.Arguments[0] = defaultInputParameter;
            base.OnInvoke(args);
            //or you can use args.Proceed()
        }

        public override async Task OnInvokeAsync(MethodInterceptionArgs args)
        {
            var inputArg = args.Arguments.First();
            args.Arguments[0] = defaultInputParameter;
            await args.ProceedAsync();
            //or you can use await base.OnInvokeAsync(args);
        }
    }
}
