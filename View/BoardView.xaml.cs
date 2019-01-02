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
using Cells;
using ViewModel;
using Model.Reversi;

namespace View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class BoardView : UserControl
    {
        public BoardViewModel VM { get; }

        public BoardView(Cell<ReversiGame> cGame)
        {
            InitializeComponent();
            this.VM = new BoardViewModel(cGame);

            this.DataContext = this;
        }
    }
}
