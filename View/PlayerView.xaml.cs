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
using Cells;
using ViewModel;
using Model.Reversi;

namespace View
{
    /// <summary>
    /// Interaction logic for PlayerView.xaml
    /// </summary>
    public partial class PlayerView : UserControl
    {
        public PlayerViewModel VM { get; }
        public String PlayerName { get; }

        public PlayerView(Cell<ReversiGame> cGame, Player player, String name)
        {
            InitializeComponent();
            this.VM = new PlayerViewModel(cGame, player);
            this.PlayerName = name;

            this.DataContext = this;
        }
    }
}
