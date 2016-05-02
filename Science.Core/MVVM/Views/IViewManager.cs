using Science.Core.MVVM.ViewModels;

namespace Science.Core.MVVM.Views
{
    public interface IViewManager<in TVm> where TVm : IViewModel
    {
        void ShowViewForViewModel(TVm viewModel);
        void CloseViewForViewModel(TVm viewModel);
    }
}