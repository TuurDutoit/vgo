using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cells;
using Model.Reversi;

namespace ViewModel
{
    public class PlayerViewModel
    {
        public String Name { get; }
        public Player Player { get; }

        public PlayerViewModel(Cell<ReversiGame> cGame, Player player, String name)
        {
            this.Name = name;
            this.Player = player;
        }
    }
}
