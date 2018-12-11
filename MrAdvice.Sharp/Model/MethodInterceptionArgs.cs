using ArxOne.MrAdvice.Advice;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Model
{
    public class MethodInterceptionArgs : Args
    {
        public MethodInterceptionArgs(MethodAsyncAdviceContext context):base(context)
        {
           
        }
        public MethodInterceptionArgs(MethodAdviceContext context):base(context)
        {
           
        }

        public void Proceed()
        {
            AsyncContext?.ProceedAsync();
        }

        public async Task ProceedAsync()
        {
            await AsyncContext?.ProceedAsync();
        }
    }
}