using ArxOne.MrAdvice.Advice;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Model
{
    public class MethodInterceptionArgs : Args
    {
        public MethodInterceptionArgs(MethodAsyncAdviceContext context)
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

        public void Proceed()
        {
            Context.ProceedAsync();
        }

        public async Task ProceedAsync()
        {
            await Context.ProceedAsync();
        }
    }
}