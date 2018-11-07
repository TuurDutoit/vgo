using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Reversi;
using DataStructures;

namespace ViewModel
{
    public class BoardRowViewModel
    {
        public List<BoardSquareViewModel> Squares { get; set; }

        public BoardRowViewModel(int rowIndex, ReversiBoard board)
        {
            Squares = new List<BoardSquareViewModel>();

            for(var i = 0; i < board.Width; i++)
            {
                var pos = new Vector2D(rowIndex, i);
                var p = board[pos];
                Squares.Add(new BoardSquareViewModel(p));
            }
        }
    }
}
