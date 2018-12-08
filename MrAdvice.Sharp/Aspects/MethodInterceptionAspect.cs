using ArxOne.MrAdvice.Advice;
using MrAdvice.Sharp.Model;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Aspects
{
    [AttributeUsage(AttributeTargets.Method| AttributeTargets.Class)]
    public abstract class MethodInterceptionAspect : Attribute, IMethodAsyncAdvice
    {
        [DebuggerHidden]
        public async Task Advise(MethodAsyncAdviceContext context)
        {
            MethodInterceptionArgs args = new MethodInterceptionArgs(context);
            if (args.IsTargetMethodAsync)
                await OnInvokeAsync(args);
            else
                OnInvoke(args);
        }

        public virtual void OnInvoke(MethodInterceptionArgs args)
        {
            args.Proceed();
        }

        public virtual async Task OnInvokeAsync(MethodInterceptionArgs args)
        {
            await args.ProceedAsync();
        }
    }
}