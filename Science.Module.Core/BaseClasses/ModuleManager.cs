using System;
using Experiments.ModuleManagersFun;
using Ninject;
using Ninject.Parameters;
using Science.Core.BaseInterfaces;
using Science.Module.Core.BaseInterfaces;

namespace Science.Module.Core.BaseClasses
{
    public class ModuleManager : BaseManager, IModuleManager
    {
        public ModuleManager(IKernel kernel) : base(kernel)
        {

        }

        /// <summary>
        /// Search for module by params
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public IModuleDataWorker<T1, T2> GetModuleDataWorker<T1, T2>() where T2 : ModuleDataModel
        {
            var parsedDataWorker = Kernel.Get<IModuleDataWorker<T1, T2>>();
            if (parsedDataWorker != null)
                return parsedDataWorker;
            //todo: logger and custom exception treating
            throw new Exception($"Cannot find moduleDataWorker with params {typeof(T1)} and {typeof(T2)}");
        }

        /// <summary>
        /// Try to get DataWorker
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T GetModuleDataWorker<T>(T type, IParameter[] parameters = null) where T : class, IDataWorker
        {
            var dataWorker = Kernel.Get(typeof(T), parameters);
            var parsedDataWorker = dataWorker as T;
            if (parsedDataWorker != null)
                return parsedDataWorker;
            //todo: logger and custom exception treating
            throw new Exception($"Cannot find module of type {type}");
        }
    }
}