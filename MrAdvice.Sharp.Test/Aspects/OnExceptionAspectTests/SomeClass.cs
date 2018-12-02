using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Test.Aspects.OnExceptionAspectTests
{
  
    public class SomeClass
    {
        public int Bar { get; set; }
        [VoidMethodTestAspect]
        public void SomeVoidMethod(int bar)
        {
            Bar = bar;
            throw new Exception();
        }

        [VoidMethodTestAspect]
        public async Task SomeVoidMethodAsync(int bar)
        {
            await Task.Delay(100);
            Bar = bar;
            throw new Exception();
        }

        [IntMethodTestAspect]
        public int ReturnIntegerMethod()
        {
            throw new Exception();
        }


        [IntMethodTestAspect]
        public async Task<int> ReturnIntegerMethodAsync()
        {
            await Task.Delay(10);
            throw new Exception();
        }


        [ThrovExceptionAfterHandledAspect]
        public void SomeVoidMethodAndThrow(int bar)
        {
            Bar = bar;
            throw new Exception();
        }

        [ThrovExceptionAfterHandledAspect]
        public async Task SomeVoidMethodThrowAsync(int bar)
        {
            await Task.Delay(100);
            Bar = bar;
            throw new Exception();
        }

    }
}
