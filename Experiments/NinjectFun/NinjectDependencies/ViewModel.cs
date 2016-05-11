using System;
using Ninject;

namespace Experiments.NinjectFun.NinjectDependencies
{
    public class ViewModel
    {
        [Inject]
        ITest _test;

        public ViewModel(int id)
        {
            Console.WriteLine(id);
        }
        public ViewModel(ITest test, int id)
        {
            Console.WriteLine(id);
            _test = test;
        }
        public void SayHello()
        {
            _test.HelloWrold();
        }
    }
}