using System;
using Microsoft.Practices.ServiceLocation;
using Science.Core.Managers;
using Science.Core.Misc;

namespace Science.Core.MVVM.ViewModels
{
    public abstract class ChildViewModelBase : ViewModelBase, IChildViewModel
    {
        private IViewModelManager<IChildViewModel> ViewModelManager { get;}

        public ChildViewModelBase()
        {
            ViewModelManager = ServiceLocator.Current.GetInstance<IViewModelManager<IChildViewModel>>();
        }

        private bool? _modalResult;
        private string _title;
        private RelayCommand _closeCommand;

        public IChildViewModel Parent { get; set; }

        public bool ModalResult { get { return _modalResult.GetValueOrDefault(); } }

        public bool IsClosed { get; protected set; }

        public string Title
        {
            get { return _title; }
            protected set
            {
                if (value == _title) return;
                _title = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CloseCommand
        {
            get
            {
                return _closeCommand ??
                    (_closeCommand = new RelayCommand(i=> true, o => Close(true)));
            }
        }

        public void Show()
        {
            UiThread.Invoke(() => ViewModelManager.ShowViewModel(this));
        }

        public void Close(bool modalResult = false)
        {
            if (OnClosing(modalResult))
            {
                IsClosed = true;
                _modalResult = modalResult;
                UiThread.Invoke(() => ViewModelManager.CloseViewModel(this));
                OnClosed();
            }
        }

        protected virtual bool OnClosing(bool modalResult)
        {
            return true;
        }

        protected virtual void OnClosed()
        {
            var handler = Closed;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler Closed;
    }
}