using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MrAdvice.Sharp.Test.Aspects.MethodInterceptionAspectTests
{
    public class SomeTestClass
    {
        public int Bar { get; set; }

        [VoidMethodTestAspect]
        public void SomeVoidMethod(int bar)
        {
            Bar = bar;
        }

        [VoidMethodTestAspect]
        public async Task SomeVoidMethodAsync(int bar)
        {
            await Task.Delay(100);
            Bar = bar;
        }


        [IntMethodTestAspect]
        public int ReturnIntegerMethod(int bar)
        {
            Bar = bar;
            return 1000000;
        }


        [IntMethodTestAspect]
        public async Task<int> ReturnIntegerMethodAsync(int bar)
        {
            Bar = bar;
            await Task.Delay(100);
            return 1000000;
        }

    }
}
