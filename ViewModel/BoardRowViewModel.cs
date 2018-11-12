using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cells;
using DataStructures;
using Model.Reversi;


namespace ViewModel
{
    public class BoardRowViewModel
    {
        public List<BoardSquareViewModel> Squares { get; }

        public BoardRowViewModel(Cell<ReversiGame> cGame, int rowIndex)
        {
            Squares = new List<BoardSquareViewModel>();

            for(var i = 0; i < cGame.Value.Board.Width; i++)
            {
                var pos = new Vector2D(rowIndex, i);
                Squares.Add(new BoardSquareViewModel(cGame, pos));
            }
        }
    }
}
