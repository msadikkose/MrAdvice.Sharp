using ArxOne.MrAdvice.Advice;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Model
{
    public class MethodExecutionArgs:Args
    {
        public Exception Exception { get; private set; }

        public FlowBehavior FlowBehavior { get; set; }

        public MethodExecutionArgs(MethodAsyncAdviceContext context, Exception exception)
        {
            Context = context;
            Exception = exception;
            Arguments = context.Arguments;
            HasReturnValue = context.HasReturnValue;
            Method = context.TargetMethod;
            MethodName = context.TargetName;
            IsTargetMethodAsync = context.IsTargetMethodAsync;
            if(context.HasReturnValue)
                ReturnValue = context.ReturnValue;
        }

        internal void SetException(Exception ex)
        {
            Exception = ex;
        }

    }
}