using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cells;
using Model.Reversi;

namespace ViewModel
{
    public class BoardViewModel
    {
        internal Cell<ReversiGame> cGame;
        public List<BoardRowViewModel> Rows { get; }

        public BoardViewModel(Cell<ReversiGame> cGame)
        {
            this.cGame = cGame;
            this.Rows = new List<BoardRowViewModel>();

            for (var i = 0; i < cGame.Value.Board.Height; i++)
            {
                Rows.Add(new BoardRowViewModel(cGame, i));
            }
        }
    }
}
