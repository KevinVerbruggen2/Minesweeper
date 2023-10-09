using Model.MineSweeper;
using System;
using System.Globalization;
using System.Windows.Data;

namespace View.Converters
{
    internal class GameStatusConverter : IValueConverter
    {
        public Object Won { get; set; }
        public Object Lost { get; set; }
        public Object InProgress { get; set; }

        // returns the game status
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((GameStatus)value)
            {
                case GameStatus.Won:
                    return Won;
                case GameStatus.Lost:
                    return Lost;
                case GameStatus.InProgress:
                    return InProgress;
                default:
                    throw new ArgumentException("status not found");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}