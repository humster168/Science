using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Science.Core.MVVM.ViewModels;
using Science.Core.MVVM.Views;

namespace Science.Core.Managers
{
    public abstract class ViewManagerBase<TChildViewModel> : IViewManager<TChildViewModel> where TChildViewModel : IViewModel
    {
        protected ViewManagerBase(IViewModelManager<TChildViewModel> vmManager)
        {
            vmManager.ViewModelShown += OnViewModelShown;
            vmManager.ViewModelClosed += OnViewModelClosed;
        }

        private void OnViewModelShown(object sender, ViewModelEventArgs<TChildViewModel> e)
        {
            ShowViewForViewModel(e.ViewModel);
        }

        private void OnViewModelClosed(object sender, ViewModelEventArgs<TChildViewModel> e)
        {
            CloseViewForViewModel(e.ViewModel);
        }

        public abstract void ShowViewForViewModel(TChildViewModel viewModel);

        public abstract void CloseViewForViewModel(TChildViewModel viewModel);

        protected IView ResolveView(Type viewModelType)
        {
            var contractName = GetViewContractName(viewModelType);
            var view = ResolveView(contractName);
            return view;
        }

        protected IView ResolveView(string contractName)
        {
            var view = ServiceLocator.Current.GetInstance<IView>(contractName);
            return view;
        }

        protected string GetViewContractName(Type viewModelType)
        {
            string contractName = viewModelType.Name.Replace("ViewModel", "View");

            if (viewModelType.IsGenericType)
            {
                List<string> parts = viewModelType.GetGenericArguments()
                    .Select(t => t.Name)
                    .ToList();

                var indexOfGenParam = viewModelType.Name.IndexOf('`');
                var vmTypeName = viewModelType.Name.Substring(0, indexOfGenParam);
                parts.Add(vmTypeName.Replace("ViewModel", "View"));

                contractName = string.Join("_", parts);
            }

            return contractName;
        }
    }
}