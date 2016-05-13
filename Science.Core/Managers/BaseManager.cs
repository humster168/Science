using Ninject;

namespace Science.Core.Managers
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