using Model.MineSweeper;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace View.Converters
{
    // returns whether the text of the square should be visible or not
    internal class SquareStatusTextVisibility:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // get the status of the square
            Square square = (Square)value;
            SquareStatus squareStatus = square.Status;

            // if the square is covered, flagged or a mine, the text should not be visible
            if (squareStatus == SquareStatus.Covered || squareStatus == SquareStatus.Flagged || squareStatus==SquareStatus.Mine)
            {
                return Visibility.Hidden;
            }

            // if the square is uncovered and has no neighboring mines, the text should not be visible
            if (squareStatus == SquareStatus.Uncovered && square.NeighboringMineCount==0)
            {
                return Visibility.Hidden;
            }
            
            // otherwise the text should be visible (uncovered and has neighboring mines)
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}