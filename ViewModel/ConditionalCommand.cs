using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cells;

namespace ViewModel
{
    class ConditionalCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Cell<bool> _cCanExecute;
        private Action _Action;

        public ConditionalCommand(Cell<bool> cCanExecute, Action action)
        {
            this._Action = action;
            this._cCanExecute = cCanExecute;
            this._cCanExecute.ValueChanged += () => CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _cCanExecute.Value;
        }

        public void Execute(object parameter)
        {
            _Action();
        }
    }
}
