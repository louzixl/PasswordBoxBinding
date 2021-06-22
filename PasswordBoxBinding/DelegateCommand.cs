using System;
using System.Windows.Input;

namespace PasswordBoxBinding
{
    public class DelegateCommand : ICommand
    {
        public bool CanExecute(object parameter) => CanExecuteAction?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => ExecuteAction?.Invoke(parameter);

        public event EventHandler CanExecuteChanged;

        public Action<object> ExecuteAction { get; set; }
        public Func<object, bool> CanExecuteAction { get; set; }
    }
}
