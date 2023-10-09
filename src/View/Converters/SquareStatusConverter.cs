using System;
using System.Globalization;
using System.Windows.Data;
using Model.MineSweeper;

namespace View.Converters
{
    public class SquareStatusConverter : IValueConverter
    {
        public object Uncovered { get; set; }
        public object Covered { get; set; }
        public object Flagged { get; set; }
        public object Mine { get; set; }

        // returns the status of the square
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SquareStatus status)
            {
                switch (status)
                {
                    case SquareStatus.Flagged:
                        return Flagged;
                    case SquareStatus.Covered:
                        return Covered;
                    case SquareStatus.Mine:
                        return Mine;
                    case SquareStatus.Uncovered:
                        return Uncovered;
                    default:
                        throw new ArgumentException("status not found");
                }
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}