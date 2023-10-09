using System.Windows.Input;
using Cells;
using Model.MineSweeper;

namespace ViewModel;

public class UncoverSquareCommand : ICommand
{
    private readonly MineSweeperScreenViewModel _mineSweeperScreenViewModel;
    private readonly SquareViewModel _viewModel;
    private readonly ICell<IGame> _game;

    public UncoverSquareCommand(SquareViewModel viewModel, ICell<IGame> game, MineSweeperScreenViewModel mineSweeperScreenViewModel)
    {
        _mineSweeperScreenViewModel = mineSweeperScreenViewModel;
        _viewModel = viewModel;
        _game = game;
    }

    public bool CanExecute(object parameter)
    {
        // check if the square is covered and the game is in progress
        return _game.Value.IsSquareCovered(_viewModel.Position) && _game.Value.Status == GameStatus.InProgress;
    }

    public void Execute(object parameter)
    {
        // check if the game has started already
        if (Utils.HasGameUncoveredSquares(_game.Value))
        {
            // uncover the clicked square if the game has started already
            _game.Value = _game.Value.UncoverSquare(_viewModel.Position);
        }
        else
        {
            // uncover the clicked square
            _game.Value = _game.Value.UncoverSquare(_viewModel.Position);
            
            // regenerate game until the first square is not a mine (if the whole board is not covered with mines)
            while (_mineSweeperScreenViewModel.SettingScreenViewModel.MineProbability < 1.0 && _game.Value.Status == GameStatus.Lost)
            {
                // start a new game and uncover the clicked square
                _mineSweeperScreenViewModel.StartNewGame();
                _game.Value = _game.Value.UncoverSquare(_viewModel.Position);
            }
        }
    }

    public event EventHandler CanExecuteChanged;
}
