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
    public abstract class MethodImplementationAspect : Attribute, IMethodAdvice
    {
        [DebuggerHidden]
        public void Advise(MethodAdviceContext context)
        {
            MethodInterceptionArgs args = new MethodInterceptionArgs(context);
            OnInvoke(args);
        }

        public abstract void OnInvoke(MethodInterceptionArgs args);
       
    }
}
