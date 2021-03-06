﻿using Ninject.Parameters;
using Science.Core.BaseInterfaces;
using Science.Module.Core.BaseClasses;

namespace Science.Module.Core.BaseInterfaces
{
    public interface IModuleManager
    {
        IModuleDataWorker<T1, T2> GetModuleDataWorker<T1, T2>() where T2 : ModuleDataModel;
        T GetModuleDataWorker<T>(T type, IParameter[] parameters = null) where T : class, IDataWorker;
    }
}