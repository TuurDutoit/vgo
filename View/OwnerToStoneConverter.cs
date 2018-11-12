using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using Model.Reversi;

namespace View
{
    class OwnerToStoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Ellipse stone = new Ellipse();
            stone.Stroke = Brushes.Black;
            stone.StrokeThickness = 2;
            stone.Width = 25;
            stone.Height = 25;

            if (value != null && value is Player)
            {
                if((Player)value == Player.BLACK)
                {
                    stone.Fill = Brushes.Black;
                }
                else
                {
                    stone.Fill = Brushes.White;
                }
            }
            else
            {
                stone.Visibility = Visibility.Hidden;
            }

            return stone;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
