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
using ViewModel;

namespace View
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:View"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:View;assembly=View"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:EndScreen/>
    ///
    /// </summary>
    public class EndScreen : Control
    {
        static EndScreen()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EndScreen), new FrameworkPropertyMetadata(typeof(EndScreen)));
        }

        public EndScreen()
        {
            if(CloseCommand == null)
            {
                CloseCommand = new SimpleCommand(() => Window.GetWindow(this).Close());
            }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title",
            typeof(String),
            typeof(EndScreen));

        public String Title
        {
            get
            {
                return (String)this.GetValue(TitleProperty);
            }
            set
            {
                this.SetValue(TitleProperty, value);
            }
        }

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message",
            typeof(String),
            typeof(EndScreen));

        public String Message
        {
            get
            {
                return (String)this.GetValue(MessageProperty);
            }
            set
            {
                this.SetValue(MessageProperty, value);
            }
        }

        public static readonly DependencyProperty CloseLabelProperty = DependencyProperty.Register("CloseLabel",
            typeof(String),
            typeof(EndScreen),
            new PropertyMetadata("Close"));

        public String CloseLabel
        {
            get
            {
                return (String)this.GetValue(CloseLabelProperty);
            }
            set
            {
                this.SetValue(CloseLabelProperty, value);
            }
        }

        public static readonly DependencyProperty CloseCommandProperty = DependencyProperty.Register("CloseCommand",
            typeof(ICommand),
            typeof(EndScreen));

        public ICommand CloseCommand
        {
            get
            {
                return (ICommand)this.GetValue(CloseCommandProperty);
            }
            set
            {
                this.SetValue(CloseCommandProperty, value);
            }
        }

        public static readonly DependencyProperty OtherLabelProperty = DependencyProperty.Register("OtherLabel",
            typeof(String),
            typeof(EndScreen));

        public String OtherLabel
        {
            get
            {
                return (String)this.GetValue(OtherLabelProperty);
            }
            set
            {
                this.SetValue(OtherLabelProperty, value);
            }
        }

        public static readonly DependencyProperty OtherCommandProperty = DependencyProperty.Register("OtherCommand",
            typeof(ICommand),
            typeof(EndScreen));

        public ICommand OtherCommand
        {
            get
            {
                return (ICommand)this.GetValue(OtherCommandProperty);
            }
            set
            {
                this.SetValue(OtherCommandProperty, value);
            }
        }
    }
}
