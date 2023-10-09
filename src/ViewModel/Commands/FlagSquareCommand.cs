using System.Diagnostics;
using System.Windows.Input;
using Cells;
using Model.MineSweeper;

namespace ViewModel
{
    public class FlagSquareCommand : ICommand
    {
        private readonly SquareViewModel _viewModel;
        private readonly ICell<IGame> _game;

        public FlagSquareCommand(SquareViewModel viewModel, ICell<IGame> game)
        {
            _viewModel = viewModel;
            _game = game;
        }

        public bool CanExecute(object parameter)
        {
            // can only flag covered squares in an in-progress game
            return _game.Value.IsSquareCovered(_viewModel.Position) && _game.Value.Status == GameStatus.InProgress;
        }

        public void Execute(object parameter)
        {
            // flag square
            // Debug.WriteLine("Flagging square at position: " + _viewModel.Position);
            _game.Value = _game.Value.ToggleFlag(_viewModel.Position);
        }

        public event EventHandler CanExecuteChanged;
    }
}