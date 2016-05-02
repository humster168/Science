using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Science.Core.CustomAttributes;
using Science.Core.Misc;

namespace Science.Core.MVVM.ViewModels
{
    public class ViewModelBase : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ConcurrentStack<int> _operationsInProggress = new ConcurrentStack<int>();

        public bool IsBusy
        {
            get { return _operationsInProggress.Count > 0; }
        }

        public bool IsFree
        {
            get { return _operationsInProggress.Count == 0; }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                //UI thread save
                UiThread.Invoke(() => handler(this, new PropertyChangedEventArgs(propertyName)));
            }

            PropertyInfo property = GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);

            if (property == null)
            {
                return;
            }

            var commands = Attribute.GetCustomAttributes(property, typeof(CommandDependencyAttribute))
                .Cast<CommandDependencyAttribute>()
                .Select(
                    cda => GetType().GetProperty(cda.CommandPropertyName, BindingFlags.Instance | BindingFlags.Public))
                .Where(cp => cp != null)
                .Select(cp => cp.GetValue(this))
                .OfType<ICommand>()
                .ToArray();

            foreach (var command in commands)
            {
                var relayCommand = command as RelayCommand;

                if (relayCommand != null)
                {
                    UiThread.Invoke(() => relayCommand.Execute(true));
                }
            }
        }

        protected OperationBusier StartOperation()
        {
            _operationsInProggress.Push(1);
            OnPropertyChanged("IsBusy");
            OnPropertyChanged("IsFree");

            return new OperationBusier(this, vm =>
            {
                int i;
                _operationsInProggress.TryPop(out i);
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsFree");
            });
        }

        protected class OperationBusier : IDisposable
        {
            private bool _isDisposed;
            private readonly ViewModelBase _vm;
            private readonly Action<ViewModelBase> _onDispose;

            public OperationBusier(ViewModelBase vm, Action<ViewModelBase> onDispose)
            {
                _vm = vm;
                _onDispose = onDispose;
            }

            public void End()
            {
                Dispose();
            }

            public void Dispose()
            {
                if (!_isDisposed)
                {
                    _onDispose(_vm);
                    _isDisposed = true;
                }
            }
        }
    }
}
