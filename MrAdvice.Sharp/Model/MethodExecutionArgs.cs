using ArxOne.MrAdvice.Advice;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Model
{
    public class MethodExecutionArgs
    {
        public Exception Exception { get; private set; }

        public IList<object> Arguments { get; private set; }
        public bool HasReturnValue { get; private set; }
        public object ReturnValue { get; private set; }
        public MethodBase Method { get; private set; }
        public string TargetName { get; private set; }
        public bool IsTargetMethodAsync { get; private set; }
        private MethodAsyncAdviceContext Context { get; set; }
        public FlowBehavior FlowBehavior { get; set; }


        public MethodExecutionArgs(MethodAsyncAdviceContext context, Exception exception)
        {
            Context = context;
            Exception = exception;
            Arguments = context.Arguments;
            HasReturnValue = context.HasReturnValue;
            Method = context.TargetMethod;
            TargetName = context.TargetName;
            IsTargetMethodAsync = context.IsTargetMethodAsync;
            if(context.HasReturnValue)
                ReturnValue = context.ReturnValue;
        }

        public void SetReturnValue<T>(T returnValue)
        {
            if (IsTargetMethodAsync)
            {
                TaskCompletionSource<T> taskCompletionSource = GetTaskCompletionSource(returnValue);
                Task task  = taskCompletionSource.Task;
                Context.ReturnValue = task;
            }
            else
                Context.ReturnValue = returnValue;
        }
        private TaskCompletionSource<T> GetTaskCompletionSource<T>(T result)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(result);
            return tcs;
        }

    }
}