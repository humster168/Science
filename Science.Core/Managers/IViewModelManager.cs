﻿using System;
using Science.Core.MVVM.ViewModels;

namespace Science.Core.Managers
{
    public interface IViewModelManager<TVm> where TVm : IViewModel
    {
        void ShowViewModel(TVm viewModel);
        void CloseViewModel(TVm viewModel);

        event EventHandler<ViewModelEventArgs<TVm>> ViewModelShown;
        event EventHandler<ViewModelEventArgs<TVm>> ViewModelClosed;
    }
}