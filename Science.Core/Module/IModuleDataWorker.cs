using Science.Core.BaseInterfaces;

namespace Science.Core.Module
{
    public interface IModuleDataWorker<out TResult, in TArgs> : IDataWorker where TArgs : ModuleDataModel
    {
        TResult Calculate(TArgs data);
    }
}