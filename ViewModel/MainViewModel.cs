using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cells;
using Model.Reversi;

namespace ViewModel
{
    public class MainViewModel
    {
        public BoardViewModel BoardVM { get; }
        private Cell<ReversiGame> cGame { get; }

        public MainViewModel(int width, int height)
        {
            var game = new ReversiGame(width, height);
            this.cGame = Cell.Create(game);
            this.BoardVM = new BoardViewModel(cGame);
        }
    }
}
