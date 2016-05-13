using Science.Core.BaseInterfaces;
using Science.Core.Logging;
using Science.Module.Core.BaseClasses;

namespace Science.Module.Core.BaseInterfaces
{
    public interface IModuleDataWorker<out TResult, in TArgs> : IDataWorker where TArgs : ModuleDataModel
    {
        ILogger Logger { get; set; }
        TResult Calculate(TArgs data);
    }
}