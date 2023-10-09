using Model.Data;
using Model.MineSweeper;

namespace ViewModel;

public static class Utils
{
    // checks if all squares are mines
    public static bool AllSquaresMines(IGame game)
    {
        if (game.Status == GameStatus.InProgress)
        {
            //game is in progress -> loop through all squares and check if all covered squares are mines
            for (int i = 0; i < game.Board.Width; i++)
            {
                for (int j = 0; j < game.Board.Height; j++)
                {
                    // check if square is covered
                    if (game.Board[new Vector2D(i, j)].Status == SquareStatus.Covered)
                    {
                        IGame newGame = game;
                        newGame = newGame.UncoverSquare(new Vector2D(i, j));
                        // return false if a square is not a mine
                        if (newGame.Board[new Vector2D(i, j)].Status != SquareStatus.Mine)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        // return false if a square is uncovered
                        return false;
                    }
                }
            }
            return true;
        } 
        //game is finished -> mine locations are known
        for (int i = 0; i < game.Board.Width; i++)
        {
            for (int j = 0; j < game.Board.Height; j++)
            {
                // return false if a square is not a mine
                if (!game.Mines.Contains(new Vector2D(i, j)))
                {
                    return false;
                }
            }
        }
        return true;
    }
    
    // checks if any square is uncovered = checks if the game has started
    public static bool HasGameUncoveredSquares(IGame game)
    {
        // loops through all squares and checks if any square is uncovered
        for (int i = 0; i < game.Board.Width; i++)
        {
            for (int j = 0; j < game.Board.Height; j++)
            {
                if (game.Board[new Vector2D(i, j)].Status != SquareStatus.Covered)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
}