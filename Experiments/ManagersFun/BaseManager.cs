using Ninject;

namespace ForTests.ManagersFun
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