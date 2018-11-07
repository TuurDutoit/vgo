using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Model.Reversi;
using Cells;
using DataStructures;
using System.Windows.Input;

namespace ViewModel
{
    public class BoardSquareViewModel
    {
        public Cell<Player> Owner { get; set; }
        public ICommand PutStone { get; set; }

        public BoardSquareViewModel(Player owner)
        {
            this.Owner = Cell.Create(owner);
            this.PutStone = new PutStoneCommand(Owner);
        }

        private class PutStoneCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private Cell<Player> _Owner;

            public PutStoneCommand(Cell<Player> owner)
            {
                this._Owner = owner;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                this._Owner.Value = Player.BLACK;
            }
        }
    }
}
