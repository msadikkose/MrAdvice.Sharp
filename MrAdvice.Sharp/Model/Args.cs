using ArxOne.MrAdvice.Advice;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Model
{
    public abstract class Args
    {
        public IList<object> Arguments { get;  }
        public bool HasReturnValue { get;  }
        public object ReturnValue { get;  }
        public MethodBase Method { get;  }
        public string MethodName { get;  }
        public bool IsTargetMethodAsync { get; }
        protected MethodAsyncAdviceContext AsyncContext { get;  set; }
        protected MethodAdviceContext Context { get;  set; }

        public Args(MethodAsyncAdviceContext context)
        {
            AsyncContext = context;
            Arguments = context.Arguments;
            HasReturnValue = context.HasReturnValue;
            Method = context.TargetMethod;
            MethodName = context.TargetName;
            IsTargetMethodAsync = context.IsTargetMethodAsync;
            if (context.HasReturnValue)
                ReturnValue = context.ReturnValue;
        }
        public Args(MethodAdviceContext context)
        {
            Context = context;
            Arguments = context.Arguments;
            HasReturnValue = context.HasReturnValue;
            Method = context.TargetMethod;
            MethodName = context.TargetName;
            IsTargetMethodAsync = context.IsTargetMethodAsync;
            if (context.HasReturnValue)
            {
                ReturnValue = context.ReturnValue;
            }
        }

        public void SetReturnValue<T>(T returnValue)
        {
            if (IsTargetMethodAsync)
            {
                TaskCompletionSource<T> taskCompletionSource = GetTaskCompletionSource(returnValue);
                Task task = taskCompletionSource.Task;
                if (AsyncContext != null)
                    AsyncContext.ReturnValue = task;
                else if(Context != null)
                    Context.ReturnValue = task ;
            }
            else
            {
                if (AsyncContext != null)
                    AsyncContext.ReturnValue = returnValue;
                else if (Context != null)
                    Context.ReturnValue = returnValue;
            }
        }
        private TaskCompletionSource<T> GetTaskCompletionSource<T>(T result)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(result);
            return tcs;
        }
    }
}