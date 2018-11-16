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
        public String Name1 { get; }
        public String Name2 { get; }
        private Cell<ReversiGame> cGame { get; }

        public MainViewModel(int width, int height, String name1, String name2)
        {
            var game = new ReversiGame(width, height);
            this.cGame = Cell.Create(game);
            this.BoardVM = new BoardViewModel(cGame);
            this.Name1 = name1;
            this.Name2 = name2;
        }
    }
}
