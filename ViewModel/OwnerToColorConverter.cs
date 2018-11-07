using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Model.Reversi;

namespace ViewModel
{
    public class OwnerToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value is Player)
            {
                var p = (Player)value;

                if(p == Player.WHITE)
                {
                    return "white";
                }
                else if(p == Player.BLACK)
                {
                    return "black";
                }
            }

            return "transparent";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value is String)
            {
                var color = (String)value;

                if(color == "white")
                {
                    return Player.WHITE;
                }
                else if(color == "black")
                {
                    return Player.BLACK;
                }
            }

            return null;
        }
    }
}
