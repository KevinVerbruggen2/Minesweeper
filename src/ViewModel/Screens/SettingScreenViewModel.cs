using System.ComponentModel;
using System.Windows.Input;
using Cells;
using Model.MineSweeper;

namespace ViewModel;

public class SettingScreenViewModel : ScreenViewModel, INotifyPropertyChanged
{
    public int MaxBoardSize { get; set; }
    public int MinBoardSize { get; set; }
    
    // Private fields for board size, flood state, and mine probability
    private int boardSize;
    private bool isFlooded;
    private double mineProbability;
    
    // game difficulty commands
    public ICommand SetEasyGameDifficulty { get; }
    public ICommand SetMediumGameDifficulty { get; }
    public ICommand SetHardGameDifficulty { get; }
    
    // PropertyChanged event for notifying property changes
    public event PropertyChangedEventHandler PropertyChanged;
    
    public SettingScreenViewModel(ICell<ScreenViewModel> currentScreen) : base(currentScreen)
    {
        // set the value for SwitchToMineSweeper
        SwitchToMineSweeper = new SwitchScreenCommand(() => CurrentScreen.Value = new MineSweeperScreenViewModel(CurrentScreen, this));
        
        // Set the default value for MaxBoardSize and MinBoardSize
        MaxBoardSize = IGame.MaximumBoardSize;
        MinBoardSize = IGame.MinimumBoardSize;
        
        // Set the game difficulty commands
        SetEasyGameDifficulty = new SetGameDifficultyCommand(this, GameDifficulty.Easy);
        SetMediumGameDifficulty = new SetGameDifficultyCommand(this, GameDifficulty.Medium);
        SetHardGameDifficulty = new SetGameDifficultyCommand(this, GameDifficulty.Hard);

        // Set the default value for BoardSize
        BoardSize = 7;
        
        // Set the default value for IsFlooded
        IsFlooded = true;
        
        // Set the default value for MineProbability
        MineProbability = 0.2;
    }
    
    public enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }
    
    public ICommand SwitchToMineSweeper { get;}
    
    // Flood state property
    public bool IsFlooded
    {
        get { return isFlooded; }
        set
        {
            if (isFlooded != value)
            {
                isFlooded = value;
                RaisePropertyChanged(nameof(IsFlooded));
            }
        }
    }

    // Board size property
    public int BoardSize
    {
        get { return boardSize; }
        set
        {
            if (boardSize != value)
            {
                boardSize = value;
                RaisePropertyChanged(nameof(BoardSize));
            }
        }
    }
    
    // Mine probability property
    public double MineProbability
    {
        get { return mineProbability; }
        set
        {
            if (!mineProbability.Equals(value))
            {
                mineProbability = value;
                RaisePropertyChanged(nameof(MineProbability));
            }
        }
    }
    
    // Raise the PropertyChanged event
    protected virtual void RaisePropertyChanged(string propertyName)
    {
        // Raise the PropertyChanged event, passing the name of the property whose value has changed.
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}