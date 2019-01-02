using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class SimpleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _Action;

        public SimpleCommand(Action action)
        {
            this._Action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _Action();
        }
    }
}
