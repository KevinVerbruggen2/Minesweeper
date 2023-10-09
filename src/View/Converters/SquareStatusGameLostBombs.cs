using System;
using System.Globalization;
using System.Windows.Data;

namespace View.Converters;

public class SquareStatusGameLostBombs : IValueConverter
{
    public object Mine { get; set; }

    // returns true if the square is a mine and the game is lost
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Boolean b)
        {
            if (b)
            {
                return Mine;
            }
        }
        return null;
    }
    
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}