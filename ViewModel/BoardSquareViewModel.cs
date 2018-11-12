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
        public Cell<bool> cIsValidMove { get; private set; }
        public ICommand PutStone { get; private set; }
        private Cell<ReversiGame> _cGame;
        private Vector2D _Position;

        public BoardSquareViewModel(Cell<ReversiGame> cGame, Vector2D position)
        {
            this._cGame = cGame;
            this._Position = position;
            this.cOwner = cGame.Derive(game => game.Board[position]);
            this.cIsValidMove = cGame.Derive(game => game.Board.IsValidMove(position, game.CurrentPlayer));
            this.PutStone = new ConditionalCommand(
                cIsValidMove,
                () => _cGame.Value = _cGame.Value.PutStone(_Position)
            );
        }
    }
}
