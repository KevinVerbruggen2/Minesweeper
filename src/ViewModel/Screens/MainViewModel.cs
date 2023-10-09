using System.Windows.Input;
using Cells;

namespace ViewModel;

public class MainViewModel
{
    public MainViewModel()
    {
        // create a new cell of ScreenViewModel that can switch between screens
        CurrentScreen = Cell.Create<ScreenViewModel>(null);
        
        // create the SettingScreenViewModel
        SettingScreenViewModel = new SettingScreenViewModel(CurrentScreen);
        
        // create the MineSweeperScreenViewModel
        MineSweeperScreenViewModel = new MineSweeperScreenViewModel(CurrentScreen, SettingScreenViewModel);
        
        // set the current screen to the MineSweeperScreenViewModel
        CurrentScreen.Value = MineSweeperScreenViewModel;
    }
    
    public ICell<ScreenViewModel> CurrentScreen { get; }
    public MineSweeperScreenViewModel MineSweeperScreenViewModel { get; }
    public SettingScreenViewModel SettingScreenViewModel { get; }
}



    