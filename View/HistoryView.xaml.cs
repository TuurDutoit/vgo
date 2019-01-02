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
    /// Interaction logic for HistoryView.xaml
    /// </summary>
    public partial class HistoryView : UserControl
    {
        public HistoryViewModel VM { get; }

        public HistoryView(Cell<ReversiGame> cGame)
        {
            InitializeComponent();
            this.VM = new HistoryViewModel(cGame);

            this.DataContext = this;
        }
    }
}
