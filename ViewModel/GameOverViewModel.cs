using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cells;
using Model.Reversi;

namespace ViewModel
{
    public class GameOverViewModel : Screen
    {
        public String Info { get; }
        public ICommand CloseCommand { get; }
        public ICommand StartOverCommand { get; }

        public GameOverViewModel(String winnerName)
        {
            if(winnerName == null)
            {
                this.Info = "It's a tie!";
            }
            else
            {
                this.Info = winnerName + " has won this game!";
            }

            this.CloseCommand = new SimpleCommand(this.Close);
            this.StartOverCommand = new SimpleCommand(() => Navigate(new WelcomeViewModel()));
        }
    }
}
