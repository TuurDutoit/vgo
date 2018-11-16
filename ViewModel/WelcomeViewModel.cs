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
    public class WelcomeViewModel
    {
        public List<int> Widths { get; }
        public List<int> Heights { get; }
        public Cell<String> cName1 { get; }
        public Cell<String> cName2 { get; }
        public Cell<int> cWidth { get; }
        public Cell<int> cHeight { get; }
        public ICommand GoToScreen { get; }
        private GoToScreenAction _goToScreen;
        private Cell<bool> _canStart;
        public delegate void GoToScreenAction(object newScreen);

        public WelcomeViewModel(GoToScreenAction goToScreen)
        {
            this.Widths = new List<int>();
            this.Heights = new List<int>();
            this.cName1 = Cell.Create("Tuur");
            this.cName2 = Cell.Create("Thomas");
            this.cWidth = Cell.Create(8);
            this.cHeight = Cell.Create(8);
            this._goToScreen = goToScreen;
            this._canStart = Cell.Derived(cName1, cName2, cWidth, cHeight, (name1, name2, w, h) =>
                !String.IsNullOrWhiteSpace(name1) &&
                !String.IsNullOrWhiteSpace(name2) &&
                ReversiBoard.IsValidWidth(w) &&
                ReversiBoard.IsValidHeight(h)
            );
            this.GoToScreen = new ConditionalCommand(_canStart, navigate);

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

        private void navigate()
        {
            _goToScreen(new MainViewModel(cWidth.Value, cHeight.Value, cName1.Value, cName2.Value));
        }
    }
}
