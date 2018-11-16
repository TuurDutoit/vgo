using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Cells;

namespace ViewModel
{
    public class MainWindowViewModel : INavigator
    {
        public Cell<IScreen> CurrentScreen { get; }
        private Window _Window;
        private Action _CloseWindow;

        public MainWindowViewModel(Window window)
        {
            this.CurrentScreen = Cell.Create<IScreen>(null);
            this.CurrentScreen.ValueChanged += () => this.CurrentScreen.Value.SetNavigator(this);
            this.CurrentScreen.Value = new WelcomeViewModel();
            this._Window = window;
            this._CloseWindow = window.Close;
        }

        public void Navigate(IScreen screen)
        {
            CurrentScreen.Value = screen;
        }

        public void Close()
        {
            this._CloseWindow();
        }
    }

    public interface INavigator
    {
        void Navigate(IScreen screen);
        void Close();
    }

    public interface IScreen
    {
        void SetNavigator(INavigator navigator);
    }

    public abstract class Screen : IScreen
    {
        protected INavigator Navigator;

        public void SetNavigator(INavigator navigator)
        {
            this.Navigator = navigator;
        }

        protected void Navigate(IScreen screen)
        {
            if(this.Navigator != null)
            {
                this.Navigator.Navigate(screen);
            }
        }

        protected void Close()
        {
            if(this.Navigator != null)
            {
                this.Navigator.Close();
            }
        }
    }
}
