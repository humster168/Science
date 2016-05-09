using System.Collections.Concurrent;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Science.Core.MVVM.ViewModels;

namespace Science.Core.Managers
{
    public class ChildViewManager : ViewManagerBase<IChildViewModel>
    {
        public ChildViewManager(IViewModelManager<IChildViewModel> vmManager, IServiceLocator serviceLocator)
            : base(vmManager, serviceLocator)
        {
        }

        public override void ShowViewForViewModel(IChildViewModel viewModel)
        {
            var view = ResolveView(viewModel.GetType());
            
            ((Window)view).Show();
        }

        public override void CloseViewForViewModel(IChildViewModel viewModel)
        {/*
            ChildViewPresenter presenter;

            if (_openedPresenters.TryRemove(viewModel, out presenter))
            {
                presenter.Close();
            }*/
        }
    }
}