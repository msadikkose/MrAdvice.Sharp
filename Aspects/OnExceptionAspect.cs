using ArxOne.MrAdvice.Advice;
using MrAdvice.Sharp.Model;
using System;
using System.Threading.Tasks;


namespace  MrAdvice.Sharp.Aspects
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public abstract class OnExceptionAspect : Attribute, IMethodAsyncAdvice
    {
        public async Task Advise(MethodAsyncAdviceContext context)
        {
            try
            {
                await context.ProceedAsync();
            }
            catch (Exception ex)
            {
                MethodExecutionArgs args = new MethodExecutionArgs(context, ex);
                OnException(args);
            }
        }

        public abstract void OnException(MethodExecutionArgs args);
    }
}