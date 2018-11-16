using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cells;
using Model.Reversi;

namespace ViewModel
{
    public class MainViewModel : Screen
    {
        public BoardViewModel BoardVM { get; }
        public PlayerViewModel Player1VM { get; }
        public PlayerViewModel Player2VM { get; }
        public Cell<int> cTotalStones { get; }
        public Cell<int> cTotalSquares { get; }
        public History<ReversiGame> History { get; }
        private Cell<ReversiGame> _cGame { get; }
        private Cell<bool> _cIsGameOver { get; }
        private String _Name1;
        private String _Name2;
        private Player _Player1 = Player.BLACK;
        private Player _Player2 = Player.WHITE;

        public MainViewModel(int width, int height, String name1, String name2)
        {
            this._cGame = Cell.Create(new ReversiGame(width, height));
            this.BoardVM = new BoardViewModel(_cGame);
            this.Player1VM = new PlayerViewModel(_cGame, Player.BLACK, name1);
            this.Player2VM = new PlayerViewModel(_cGame, Player.WHITE, name2);
            this.cTotalStones = _cGame.Derive(game => game.Board.CountStones(_Player1) + game.Board.CountStones(_Player2));
            this.cTotalSquares = _cGame.Derive(game => game.Board.Width * game.Board.Height);
            this.History = new History<ReversiGame>(_cGame);
            this._cIsGameOver = _cGame.Derive(game => game.IsGameOver);
            this._cIsGameOver.ValueChanged += GameOver;
            this._Name1 = name1;
            this._Name2 = name2;
        }

        private void GameOver()
        {
            int p1Score = _cGame.Value.Board.CountStones(_Player1);
            int p2Score = _cGame.Value.Board.CountStones(_Player2);
            String winnerName = p1Score == p2Score ? null : p1Score > p2Score ? _Name1 : _Name2;
            Navigate(new GameOverViewModel(winnerName));
        }


    }
}
