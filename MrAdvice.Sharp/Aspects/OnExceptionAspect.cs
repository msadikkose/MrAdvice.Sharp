using ArxOne.MrAdvice.Advice;
using MrAdvice.Sharp.Model;
using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace  MrAdvice.Sharp.Aspects
{
    //[DebuggerNonUserCode]
    //[DebuggerStepThrough]
   
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public abstract class OnExceptionAspect : Attribute, IMethodAsyncAdvice
    {
        [DebuggerHidden]
        public  async Task Advise(MethodAsyncAdviceContext context)
        {
            try
            {
                await context.ProceedAsync();
            }
            catch (Exception ex)
            {
                MethodExecutionArgs args = new MethodExecutionArgs(context, ex);
                OnException(args);
                if (args.FlowBehavior == FlowBehavior.RethrowException)
                    throw;
                if (args.FlowBehavior == FlowBehavior.ThrowException)
                    throw ex;
            }
        }

        public virtual void  OnException(MethodExecutionArgs args)
        {

        }
    }
}