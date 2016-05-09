using Science.Core.MVVM.ViewModels;

namespace Science.Core.MVVM.Views
{
    public interface IViewManager<in TChildViewModel> where TChildViewModel : IViewModel
    {
        void ShowViewForViewModel(TChildViewModel viewModel);
        void CloseViewForViewModel(TChildViewModel viewModel);
    }
}