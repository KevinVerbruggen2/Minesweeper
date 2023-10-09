using System;
using System.Windows.Controls;
using System.Windows.Threading;
using Model.MineSweeper;
using ViewModel;

namespace View.Screens;

public partial class MineSweeperScreen : UserControl
{
    public GameViewModel GameViewModel { get; set; }
    private DispatcherTimer timer;
    private TimeSpan elapsed;
    public MineSweeperScreen()
    {
        InitializeComponent();
        
        // retrieve the GameViewModel from the DataContext
        GameViewModel = (GameViewModel)DataContext;
        
        // create a new timer and start it
        timer = new DispatcherTimer();
        
        // set the timer interval to 1 second
        timer.Interval = TimeSpan.FromSeconds(1);
        
        // set the timer tick event handler
        timer.Tick += Timer_Tick;
        
        // start the timer
        timer.Start();
    }
    
    private void Timer_Tick(object sender, EventArgs e)
    {
        //retrieve the MineSweeperScreenViewModel from the DataContext to access the current game
        MineSweeperScreenViewModel screenModel = (MineSweeperScreenViewModel)DataContext;
        
        //set game time to 0 if the game has not started yet
        if (screenModel != null && Utils.HasGameUncoveredSquares(screenModel.GameViewModel.currentGame.Value))
        {
            //increment game time by 1 second if the game is in progress
            if (screenModel.GameViewModel.currentGame.Value.Status == GameStatus.InProgress)
            {
                elapsed += TimeSpan.FromSeconds(1);
            }
        }
        else
        {
            elapsed = TimeSpan.Zero;
        }
        TimeElapsedTextBlock.Text = elapsed.ToString(@"hh\:mm\:ss");
    }
}