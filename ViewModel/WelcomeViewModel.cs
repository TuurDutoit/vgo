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
    public class WelcomeViewModel
    {
        public List<int> Widths { get; }
        public List<int> Heights { get; }
        public Cell<int> cWidth { get; }
        public Cell<int> cHeight { get; }
        public Cell<bool> cCanStart;

        public WelcomeViewModel()
        {
            this.Widths = new List<int>();
            this.Heights = new List<int>();
            this.cWidth = Cell.Create(8);
            this.cHeight = Cell.Create(8);
            this.cCanStart = Cell.Derived(cWidth, cHeight, (w, h) =>
                ReversiBoard.IsValidWidth(w) &&
                ReversiBoard.IsValidHeight(h) &&
                (w != 2 || h != 2)
            );

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
    }
}
