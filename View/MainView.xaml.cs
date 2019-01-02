using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;
using Model.Reversi;

namespace View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainViewModel VM;
        public PlayerView vPlayer1 { get; }
        public PlayerView vPlayer2 { get; }
        public UserControl vHistory { get; }
        public UserControl vBoard { get; }
        private String _Name1;
        private String _Name2;

        public MainView(int width, int height, String name1, String name2)
        {
            InitializeComponent();
            this.VM = new MainViewModel(width, height);
            this.vPlayer1 = new PlayerView(VM.cGame, Player.BLACK, name1);
            this.vPlayer2 = new PlayerView(VM.cGame, Player.WHITE, name2);
            this.vHistory = new HistoryView(VM.cGame);
            this.vBoard = new BoardView(VM.cGame);
            this._Name1 = name1;
            this._Name2 = name2;

            VM.cIsGameOver.ValueChanged += gameOver;

            DataContext = this;
        }

        private void gameOver()
        {
            String winnerName;

            if (vPlayer1.VM.cStones.Value == vPlayer2.VM.cStones.Value)
            {
                winnerName = null;
            }
            else if(vPlayer1.VM.cStones.Value > vPlayer2.VM.cStones.Value)
            {
                winnerName = _Name1;
            }
            else
            {
                winnerName = _Name2;
            }

            Window win = Window.GetWindow(this);
            win.Content = new GameOverView(winnerName);
        }
    }
}
