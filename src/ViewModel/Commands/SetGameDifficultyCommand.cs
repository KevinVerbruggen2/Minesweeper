using System.Windows.Input;

namespace ViewModel;

public class SetGameDifficultyCommand : ICommand
{
    
    private SettingScreenViewModel settingScreenViewModel;
    private SettingScreenViewModel.GameDifficulty gameDifficulty;
    
    public SetGameDifficultyCommand (SettingScreenViewModel settingScreenViewModel, SettingScreenViewModel.GameDifficulty gameDifficulty)
    {
        this.settingScreenViewModel = settingScreenViewModel;
        this.gameDifficulty = gameDifficulty;
    }
    
    public bool CanExecute(object parameter)
    {
        return true;
    }
    
    public void Execute(object parameter)
    {
        switch (gameDifficulty)
        {
            case SettingScreenViewModel.GameDifficulty.Easy:
                settingScreenViewModel.BoardSize = 5;
                settingScreenViewModel.MineProbability = 0.1;
                break;
            case SettingScreenViewModel.GameDifficulty.Medium:
                settingScreenViewModel.BoardSize = 10;
                settingScreenViewModel.MineProbability = 0.15;
                break;
            case SettingScreenViewModel.GameDifficulty.Hard:
                settingScreenViewModel.BoardSize = 15;
                settingScreenViewModel.MineProbability = 0.2;
                break;
        }
    }
    
    public event EventHandler CanExecuteChanged;
}