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
        public PlayerViewModel Player1VM { get; }
        public PlayerViewModel Player2VM { get; }
        private Cell<ReversiGame> cGame { get; }

        public MainViewModel(int width, int height, String name1, String name2)
        {
            var game = new ReversiGame(width, height);
            this.cGame = Cell.Create(game);
            this.BoardVM = new BoardViewModel(cGame);
            this.Player1VM = new PlayerViewModel(cGame, Player.BLACK, name1);
            this.Player2VM = new PlayerViewModel(cGame, Player.WHITE, name2);
        }
    }
}
