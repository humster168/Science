using Science.Core.BaseInterfaces;
using Science.Module.Core.BaseClasses;

namespace Science.Module.Core.BaseInterfaces
{
    public interface IModuleDataWorker<out TResult, in TArgs> : IDataWorker where TArgs : ModuleDataModel
    {
        TResult Calculate(TArgs data);
    }
}