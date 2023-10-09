using Cells;
using Model.Data;
using Model.MineSweeper;

namespace ViewModel;

public class RowViewModel
{
    public IEnumerable<SquareViewModel> Squares { get; }

    public RowViewModel(ICell<IGame> game, int rowIndex, MineSweeperScreenViewModel mineSweeperScreenViewModel)
    {
        Squares = GetSquareViewModels(game, rowIndex, mineSweeperScreenViewModel);
    }
    
    // Generate the SquareViewModels of the game board
    public IEnumerable<SquareViewModel> GetSquareViewModels(ICell<IGame> game, int rowIndex, MineSweeperScreenViewModel mineSweeperScreenViewModel)
    {
        List<SquareViewModel> viewModels = new List<SquareViewModel>();
        for (int i = 0; i < game.Derive(g=> g.Board.Width).Value; i++)
        {
            viewModels.Add(new SquareViewModel(game, new Vector2D(i, rowIndex), mineSweeperScreenViewModel));
        }
        return viewModels;
    }
}