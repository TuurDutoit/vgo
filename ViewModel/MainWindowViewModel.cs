using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cells;

namespace ViewModel
{
    public class MainWindowViewModel
    {
        public Cell<object> CurrentScreen { get; }

        public MainWindowViewModel()
        {
            this.CurrentScreen = Cell.Create<object>(new MainViewModel(8, 8));
        }
    }
}
