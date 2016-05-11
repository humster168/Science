using Ninject;

namespace Experiments.ModuleManagersFun
{
    public class BaseManager
    {
        protected IKernel Kernel;
        public BaseManager(IKernel kernel)
        {
            Kernel = kernel;
        }
    }
}