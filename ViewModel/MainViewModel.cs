using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using Cells;
using Model.Reversi;

namespace ViewModel
{
    public class MainViewModel
    {
        public Cell<ReversiGame> cGame { get; }
        public History<ReversiGame> History { get; }
        public Cell<bool> cIsGameOver { get; }

        public MainViewModel(int width, int height)
        {
            this.cGame = Cell.Create(new ReversiGame(width, height));
            this.cIsGameOver = cGame.Derive(game => game.IsGameOver);
        }
    }
}
