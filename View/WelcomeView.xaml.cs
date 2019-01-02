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
using Xceed.Wpf.Toolkit;
using Cells;
using ViewModel;
using Model.Reversi;

namespace View
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class WelcomeView : UserControl
    {
        public WelcomeViewModel VM { get; }
        public Cell<String> cName1 { get; }
        public Cell<String> cName2 { get; }
        public Cell<Color> cColor1 { get; }
        public Cell<Color> cColor2 { get; }
        public ICommand Start { get; }

        public WelcomeView()
        {
            InitializeComponent();
            this.VM = new WelcomeViewModel();
            this.cName1 = Cell.Create("Tuur");
            this.cName2 = Cell.Create("Thomas");
            this.cColor1 = Cell.Create(Colors.Black);
            this.cColor2 = Cell.Create(Colors.White);

            Cell<bool> cCanStart = Cell.Derived(VM.cCanStart, cName1, cName2, cColor1, cColor2, (validSize, n1, n2, c1, c2) =>
                validSize &&
                !String.IsNullOrWhiteSpace(n1) &&
                !String.IsNullOrWhiteSpace(n2) &&
                c1 != null &&
                c2 != null
            );

            this.Start = new ConditionalCommand(cCanStart, start);
            this.DataContext = this;
        }

        private void start()
        {
            this.setStoneColors();
            Window win = Window.GetWindow(this);
            win.Content = new MainView(VM.cWidth.Value, VM.cHeight.Value, cName1.Value, cName2.Value);
        }

        private void setStoneColors()
        {
            Style originalStyle = (Style)Application.Current.FindResource("StoneStyle");
            Style stoneStyle = new Style();
            stoneStyle.TargetType = typeof(Ellipse);
            stoneStyle.BasedOn = originalStyle;
            stoneStyle.Triggers.Add(getTriggerForPlayerColor(Player.BLACK, cColor1.Value));
            stoneStyle.Triggers.Add(getTriggerForPlayerColor(Player.WHITE, cColor2.Value));
            Application.Current.Resources["StoneStyle"] = stoneStyle;
        }

        private DataTrigger getTriggerForPlayerColor(Player player, Color color)
        {
            DataTrigger trigger = new DataTrigger();
            trigger.Binding = new Binding();
            trigger.Value = player;
            Setter setter = new Setter(Shape.FillProperty, new SolidColorBrush(color));
            trigger.Setters.Add(setter);

            return trigger;
        }
    }
}
