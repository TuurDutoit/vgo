using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace View
{
    /// <summary>
    /// Interaction logic for GameOverView.xaml
    /// </summary>
    public partial class GameOverView : UserControl
    {
        public String WinnerName { get; }
        public ICommand CloseCommand { get; }
        public ICommand RestartCommand { get; }

        public GameOverView(String winnerName)
        {
            InitializeComponent();
            this.WinnerName = winnerName;
            this.CloseCommand = new SimpleCommand(() => Window.GetWindow(this).Close());
            this.RestartCommand = new SimpleCommand(() => Window.GetWindow(this).Content = new WelcomeView());

            this.DataContext = this;
        }
    }

    public class NameToMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value is String)
            {
                return ((String)value) + " has won this game!";
            }

            return "It's a tie!";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
