using System.Windows.Input;

namespace ViewModel;

public class StartNewGame : ICommand
{
    public MineSweeperScreenViewModel MineSweeperScreen { get; set; }
    
    public StartNewGame(MineSweeperScreenViewModel viewModel)
    {
        this.MineSweeperScreen = viewModel;
    }
    
    public bool CanExecute(object parameter)
    {
        // you can always start a new game
        return true;
    }
    
    public void Execute(object parameter)
    {
        // start a new game via the MineSweeperScreenViewModel
        MineSweeperScreen.StartNewGame();
    }
    
    public event EventHandler CanExecuteChanged { add { } remove { } }
}