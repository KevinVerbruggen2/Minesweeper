using System.Windows.Input;
using Model.MineSweeper;

namespace ViewModel;

public class GetHintCommand : ICommand
{
    private readonly GameViewModel _viewModel;
    
    public GetHintCommand(GameViewModel viewModel)
    {
        _viewModel = viewModel;
    }
    
    public event EventHandler CanExecuteChanged { add { } remove { } }
    
    public bool CanExecute(object parameter)
    {
        // you can only get a hint if the game is in progress
        return _viewModel.currentGame.Value.Status == GameStatus.InProgress;
    }
    
    public void Execute(object parameter)
    {
        _viewModel.GetHint();
    }
}