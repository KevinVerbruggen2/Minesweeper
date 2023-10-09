using System.Windows.Input;
using Cells;
using Model.MineSweeper;

namespace ViewModel;

public class MineSweeperScreenViewModel : ScreenViewModel
{
    public SettingScreenViewModel SettingScreenViewModel { get; }
    public ICommand SwitchToSettingScreen { get; }
    public ICommand StartNewGameCommand { get;  }
    public ICommand GetHint { get; }
    public GameViewModel GameViewModel { get; set; }
    public MineSweeperScreenViewModel(ICell<ScreenViewModel> currentScreen, SettingScreenViewModel settingScreenViewModel) : base(currentScreen)
    {
        // save the SettingScreenViewModel (this is needed to save the settings values)
        SettingScreenViewModel = settingScreenViewModel;
        
        // create a new GameViewModel with a new game and this MineSweeperScreenViewModel
        GameViewModel = new GameViewModel(GetNewGame(), this);
        
        // create the commands
        SwitchToSettingScreen = new SwitchScreenCommand(() => CurrentScreen.Value = SettingScreenViewModel);
        GetHint = new GetHintCommand(GameViewModel);
        StartNewGameCommand = new StartNewGame(this);
    }
    
    public void StartNewGame()
    {
        // set the current game (in viewmodel) to a new game
        GameViewModel.currentGame.Value = GetNewGame();
    }
    
    public IGame GetNewGame()
    {
        // create a new game with the settings from the SettingScreenViewModel
        return IGame.CreateRandom(SettingScreenViewModel.BoardSize, SettingScreenViewModel.MineProbability, SettingScreenViewModel.IsFlooded);
    }
}