using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cells;

namespace ViewModel
{
    public class HistoryViewModel
    {
        public History<ReversiGame> History { get; }
        public Cell<int> cTotalSquares { get; }
        public Cell<int> cTotalStones { get; }

        public HistoryViewModel(Cell<ReversiGame> cGame)
        {
            this.History = new History<ReversiGame>(cGame);
            this.cTotalStones = cGame.Derive(game => game.Board.CountStones(Player.WHITE) + game.Board.CountStones(Player.BLACK));
            this.cTotalSquares = cGame.Derive(game => game.Board.Width * game.Board.Height);
        }
    }
}
