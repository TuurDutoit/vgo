using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Cells;
using Model.Reversi;

namespace ViewModel
{
    public class WelcomeViewModel : Screen
    {
        public List<int> Widths { get; }
        public List<int> Heights { get; }
        public Cell<String> cName1 { get; }
        public Cell<String> cName2 { get; }
        public Cell<Color> cColor1 { get; }
        public Cell<Color> cColor2 { get; }
        public Cell<int> cWidth { get; }
        public Cell<int> cHeight { get; }
        public ICommand GoToMainView { get; }
        private Cell<bool> _cCanStart;

        public WelcomeViewModel()
        {
            this.Widths = new List<int>();
            this.Heights = new List<int>();
            this.cName1 = Cell.Create("Tuur");
            this.cName2 = Cell.Create("Thomas");
            this.cColor1 = Cell.Create(Colors.Black);
            this.cColor2 = Cell.Create(Colors.White);
            this.cWidth = Cell.Create(8);
            this.cHeight = Cell.Create(8);
            this._cCanStart = Cell.Derived(cName1, cName2, cWidth, cHeight, (name1, name2, w, h) =>
                !String.IsNullOrWhiteSpace(name1) &&
                !String.IsNullOrWhiteSpace(name2) &&
                ReversiBoard.IsValidWidth(w) &&
                ReversiBoard.IsValidHeight(h) &&
                (w != 2 || h != 2)
            );
            this.GoToMainView = new ConditionalCommand(_cCanStart, goToMainView);

            for(int i = 0; i < 30; i++)
            {
                if(ReversiBoard.IsValidWidth(i))
                {
                    Widths.Add(i);
                }
                if(ReversiBoard.IsValidHeight(i))
                {
                    Heights.Add(i);
                }
            }
        }

        private void goToMainView()
        {
            Navigate(new MainViewModel(cWidth.Value, cHeight.Value, cName1.Value, cName2.Value, cColor1.Value, cColor2.Value));
        }
    }
}
