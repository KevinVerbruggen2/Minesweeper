using System.Windows.Input;
using Cells;
using Model.Data;
using Model.MineSweeper;

namespace ViewModel;

public class SquareViewModel
{
    public ICell<Square> Square { get; }
    public ICommand Uncover { get; }
    public ICommand ToggleFlag { get; }
    public Vector2D Position { get; }
    
    // sets boolean to true if the game is over and the square is a mine (to show all mines when the game is over)
    public ICell<bool> IsGameOverAndMine { get; }
    public ICell<IGame> Game { get; }

    public SquareViewModel(ICell<IGame> game, Vector2D position, MineSweeperScreenViewModel mineSweeperScreenViewModel)
    {
        this.Square = game.Derive(g=>g.Board[position]);
        Uncover = new UncoverSquareCommand(this, game, mineSweeperScreenViewModel);
        ToggleFlag = new FlagSquareCommand(this, game);
        this.Position = position;
        this.Game = game;
        // sets boolean to true if the game is over and the square is a mine
        this.IsGameOverAndMine = game.Derive(g => g.Status != GameStatus.InProgress && g.Mines.Contains(position));
    }
}