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
        public List<BoardRowViewModel> PRows { get { return Rows.Value; } }
        private Cell<ReversiGame> Game;
        private Cell<ReversiBoard> Board;
        private Cell<List<BoardRowViewModel>> Rows;

        public BoardViewModel(int width, int height)
        {
            this.Game = Cell.Create(new ReversiGame(width, height));
            this.Board = this.Game.Derive(game => game.Board);
            this.Rows = this.Board.Derive(board => {
                var rows = new List<BoardRowViewModel>();

                for (var i = 0; i < board.Height; i++)
                {
                    rows.Add(new BoardRowViewModel(i, board));
                }

                return rows;
            });
        }
    }
}
