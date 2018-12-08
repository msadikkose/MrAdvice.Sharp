using ArxOne.MrAdvice.Advice;
using MrAdvice.Sharp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Aspects
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public abstract class OnMethodBoundaryAspect : Attribute, IMethodAsyncAdvice
    {

        [DebuggerHidden]
        public async Task Advise(MethodAsyncAdviceContext context)
        {
            MethodExecutionArgs args = new MethodExecutionArgs(context, null);
            try
            {
                OnEntry(args);
                await context.ProceedAsync();
                OnSuccess(args);
            }
            catch (Exception ex)
            {
                args.SetException(ex);
                OnException(args);
            }
            finally
            {
                OnExit(args);
            }
        }
        public virtual void OnEntry(MethodExecutionArgs args)
        {
        }

        public virtual void OnExit(MethodExecutionArgs args)
        {
        }

        public virtual void OnSuccess(MethodExecutionArgs args)
        {
        }

        public virtual void OnException(MethodExecutionArgs args)
        {
        }

       
    }
}
