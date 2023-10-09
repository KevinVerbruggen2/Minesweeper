using Cells;
using Model.Data;
using Model.MineSweeper;

namespace ViewModel;

public class GameViewModel
{
    public ICell<IGame> currentGame {get; set; }
    public GameBoardViewModel Board { get; }
    
    public GameViewModel(IGame startGame, MineSweeperScreenViewModel mineSweeperScreenViewModel)
    {
        // Create a cell to hold the current game state
        this.currentGame = Cell.Create(startGame);
        
        // Initialize the game board view model
        Board = new GameBoardViewModel(this.currentGame, mineSweeperScreenViewModel);
    }

    
    // Get a hint for the current game (if possible uncover a random square which is not a mine)
    public void GetHint()
    {
        // only get a hint when the game is in progress (if there are still squares to uncover)
        if (currentGame.Value.Status == GameStatus.InProgress)
        {
            //dont uncover a square when every square is covered with a mine
            if (Utils.AllSquaresMines(currentGame.Value))
            {
                return;
            }
            
            // find and uncover a random square which is not a mine
            // foundHint is true when a random square is uncovered
            bool foundHint = false;
            IGame newGame = currentGame.Value;

            // keep uncovering a random square until a hint is found and the game is not lost
            while (!foundHint || newGame.Status == GameStatus.Lost)
            {
                foundHint = false;
                
                // copy the current game state to a new variable
                newGame = currentGame.Value;
                
                // get a random position
                Vector2D randomPosition = GetRandomPosition();
                
                // uncover the square at the random position if it is covered
                if (newGame.Board[randomPosition].Status == SquareStatus.Covered)
                {
                    newGame = newGame.UncoverSquare(randomPosition);
                    foundHint = true;
                }
            }
            currentGame.Value = newGame;
        }
    }
    
    // generate a random position on the current board
    private Vector2D GetRandomPosition()
    {
        var newGame = currentGame.Value;
        var randomRow = GenerateRandomNumber(newGame.Board.Width);
        var randomColumn = GenerateRandomNumber(newGame.Board.Height);
        var randomPosition = new Vector2D(randomRow, randomColumn);
        return randomPosition;
    }
    
    // generate a random number between 0 and maxValue
    private int GenerateRandomNumber(int maxValue)
    {
        Random random = new Random();
        return random.Next(maxValue);
    }
}