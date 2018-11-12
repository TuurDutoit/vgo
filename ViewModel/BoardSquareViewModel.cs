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
        public Cell<Player> cOwner { get; private set; }
        public Cell<bool> cHasStone { get; private set; }
        public Cell<String> cPlayerColor { get; private set; }
        public Cell<bool> cIsValidMove { get; private set; }
        public ICommand PutStone { get; private set; }
        private Cell<ReversiGame> _cGame;
        private Vector2D _Position;

        public BoardSquareViewModel(Cell<ReversiGame> cGame, Vector2D position)
        {
            this._cGame = cGame;
            this._Position = position;
            this.cOwner = cGame.Derive(game => game.Board[position]);
            this.cHasStone = cOwner.Derive(owner => owner != null);
            this.cPlayerColor = cOwner.Derive(owner => owner == Player.BLACK ? "black" : "white");
            this.cIsValidMove = cGame.Derive(game => game.Board.IsValidMove(position, game.CurrentPlayer));
            this.PutStone = new PutStoneCommand(cIsValidMove, PutStoneAction);
        }

        private void PutStoneAction()
        {
            _cGame.Value = _cGame.Value.PutStone(_Position);
        }

        private class PutStoneCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private Action _PutStone;
            private Cell<bool> _cIsValidMove;

            public PutStoneCommand(Cell<bool> cIsValidMove, Action putStone)
            {
                this._PutStone = putStone;
                this._cIsValidMove = cIsValidMove;
                this._cIsValidMove.ValueChanged += () => CanExecuteChanged(this, EventArgs.Empty);
            }

            public bool CanExecute(object parameter)
            {
                return _cIsValidMove.Value;
            }

            public void Execute(object parameter)
            {
                _PutStone();
            }
        }
    }
}
