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
        public Player Player { get; }
        public Cell<bool> cIsCurrentPlayer { get; }
        public Cell<int> cStones { get; }
        public Cell<int> cTotalSquares { get; }

        public PlayerViewModel(Cell<ReversiGame> cGame, Player player)
        {
            this.Player = player;
            this.cIsCurrentPlayer = cGame.Derive(game => game.CurrentPlayer == player);
            this.cStones = cGame.Derive(game => game.Board.CountStones(player));
            this.cTotalSquares = cGame.Derive(game => game.Board.Width * game.Board.Height);
        }
    }
}
