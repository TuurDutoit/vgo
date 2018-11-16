using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cells;

namespace ViewModel
{
    public class History<T>
    {
        public ICommand UndoCommand { get; }
        public ICommand RedoCommand { get; }
        private IList<T> _Steps;
        private Cell<int> _cCurrentIndex;
        private Cell<bool> _cCanUndo;
        private Cell<bool> _cCanRedo;
        private Cell<T> _Cell;

        public History()
        {
            this._Steps = new List<T>();
            this._cCurrentIndex = Cell.Create(-1);
            this._cCanUndo = _cCurrentIndex.Derive(index => index > 0);
            this._cCanRedo = _cCurrentIndex.Derive(index => index < _Steps.Count() - 1);
            this.UndoCommand = new ConditionalCommand(_cCanUndo, Undo);
            this.RedoCommand = new ConditionalCommand(_cCanRedo, Redo);
        }

        public History(Cell<T> cell) : this()
        {
            Watch(cell);
        }

        public void Watch(Cell<T> cell)
        {
            if(this._Cell != null)
            {
                throw new Exception("This History is already watching a cell.");
            }

            this._Cell = cell;
            cell.ValueChanged += OnChange;

            if(cell.Value != null)
            {
                _Steps.Add(cell.Value);
                _cCurrentIndex.Value = 0;
            }
        }

        public void Undo()
        {
            if(_cCanUndo.Value)
            {
                _cCurrentIndex.Value -= 1;
                _Cell.Value = _Steps.ElementAt(_cCurrentIndex.Value);
            }
        }

        public void Redo()
        {
            if (_cCanRedo.Value)
            {
                _cCurrentIndex.Value += 1;
                _Cell.Value = _Steps.ElementAt(_cCurrentIndex.Value);
            }
        }

        private void OnChange()
        {
            T step = _Cell.Value;

            if(_Steps.Contains(step))
            {
                _cCurrentIndex.Value = _Steps.IndexOf(step);
            }
            else
            {
                int index = _cCurrentIndex.Value;
                for(int i = _Steps.Count() - 1; i > index; i--)
                {
                    _Steps.RemoveAt(i);
                }

                _Steps.Add(step);
                _cCurrentIndex.Value = _Steps.Count() - 1;
            }
        }
    }
}
