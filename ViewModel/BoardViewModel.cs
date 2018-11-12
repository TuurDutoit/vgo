using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Reversi;
using Cells;
using DataStructures;

namespace ViewModel
{
    public class BoardViewModel
    {
        internal Cell<ReversiGame> cGame;
        public List<BoardRowViewModel> Rows { get; }

        public BoardViewModel(int width, int height)
        {
            var game = new ReversiGame(width, height);
            this.cGame = Cell.Create(game);
            this.Rows = new List<BoardRowViewModel>();

            for (var i = 0; i < game.Board.Height; i++)
            {
                Rows.Add(new BoardRowViewModel(cGame, i));
            }
        }
    }
}
