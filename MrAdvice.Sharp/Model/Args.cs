using ArxOne.MrAdvice.Advice;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Model
{
    public abstract class Args
    {
        public IList<object> Arguments { get; protected set; }
        public bool HasReturnValue { get; protected set; }
        public object ReturnValue { get; protected set; }
        public MethodBase Method { get; protected set; }
        public string MethodName { get; protected set; }
        public bool IsTargetMethodAsync { get; protected set; }
        protected MethodAsyncAdviceContext Context { get; set; }

        public void SetReturnValue<T>(T returnValue)
        {
            if (IsTargetMethodAsync)
            {
                TaskCompletionSource<T> taskCompletionSource = GetTaskCompletionSource(returnValue);
                Task task = taskCompletionSource.Task;
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