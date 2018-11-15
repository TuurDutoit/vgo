using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cells;

namespace ViewModel
{
    public class WelcomeViewModel
    {
        public Cell<String> cName1 { get; }
        public Cell<String> cName2 { get; }
        public Cell<String> cWidth { get; }
        public Cell<String> cHeight { get; }
        public ICommand GoToScreen { get; }
        private GoToScreenAction _goToScreen;
        private Cell<bool> _canStart;
        public delegate void GoToScreenAction(object newScreen);

        public WelcomeViewModel(GoToScreenAction goToScreen)
        {
            this.cName1 = Cell.Create("");
            this.cName2 = Cell.Create("");
            this.cWidth = Cell.Create("8");
            this.cHeight = Cell.Create("8");
            this._goToScreen = goToScreen;
            this._canStart = Cell.Derived(cName1, cName2,
                (name1, name2) => !String.IsNullOrWhiteSpace(name1) && !String.IsNullOrWhiteSpace(name2));
            this.GoToScreen = new ConditionalCommand(_canStart, navigate);
        }

        private void navigate()
        {
            int width;
            int height;
            int.TryParse(cWidth.Value, out width);
            int.TryParse(cHeight.Value, out height);
            _goToScreen(new MainViewModel(width, height));
        }
    }
}
