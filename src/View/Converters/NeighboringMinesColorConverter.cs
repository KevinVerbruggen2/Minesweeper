using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace View.Converters
{
    public class NeighboringMinesColorConverter : IValueConverter
    {
        // returns a different color depending on the number of neighboring mines
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int neighboringMinesCount)
            {
                switch (neighboringMinesCount)
                {
                    case 0:
                        return Brushes.Green; // Color for 0 neighboring mines
                    case 1:
                        return Brushes.Blue; // Color for 1 neighboring mine
                    case 2:
                        return Brushes.Red; // Color for 2 neighboring mines
                    case 3:
                        return Brushes.Orange; // Color for 3 neighboring mines
                    case 4:
                        return Brushes.Purple; // Color for 4 neighboring mines
                    case 5:
                        return Brushes.DarkGreen; // Color for 5 neighboring mines
                    case 6:
                        return Brushes.DarkBlue; // Color for 6 neighboring mines
                    case 7:
                        return Brushes.DarkRed; // Color for 7 neighboring mines
                    case 8:
                        return Brushes.DarkOrange; // Color for 8 neighboring mines
                }
            }

            // Return a default color if the value is not valid or doesn't match any case
            return Brushes.Black; // Default color
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}