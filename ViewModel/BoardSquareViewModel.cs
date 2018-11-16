using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Cells;
using DataStructures;
using Model.Reversi;

namespace ViewModel
{
    public class BoardSquareViewModel
    {
        public Cell<Player> cOwner { get; }
        public Cell<bool> cHasStone { get; }
        public Cell<bool> cIsValidMove { get; }
        public ICommand PutStone { get; }
        private Cell<ReversiGame> _cGame;
        private Vector2D _Position;

        public BoardSquareViewModel(Cell<ReversiGame> cGame, Vector2D position)
        {
            this._cGame = cGame;
            this._Position = position;
            this.cOwner = cGame.Derive(game => game.Board[position]);
            this.cHasStone = cOwner.Derive(owner => owner != null);
            this.cIsValidMove = cGame.Derive(game => game.IsValidMove(position));
            this.PutStone = new ConditionalCommand(
                cIsValidMove,
                () => _cGame.Value = _cGame.Value.PutStone(_Position)
            );
        }
    }
}
