using Cells;
using Model.MineSweeper;

namespace ViewModel
{
    public class GameBoardViewModel
    {
        private readonly ICell<IGameBoard> board;
        public IEnumerable<RowViewModel> Rows { get; }
        
        public GameBoardViewModel(ICell<IGame> game, MineSweeperScreenViewModel mineSweeperScreenViewModel)
        {
            this.board = game.Derive(g => g.Board);
            Rows = Rows1(game, mineSweeperScreenViewModel);
        }
        
        // Generate the rows (with squares) of the game board
        public IEnumerable<RowViewModel> Rows1(ICell<IGame> game, MineSweeperScreenViewModel mineSweeperScreenViewModel)
        {
            var rows = new List<RowViewModel>();
            for (int i = 0; i < board.Derive(b => b.Height).Value; i++)
            {
                rows.Add(new RowViewModel(game, i, mineSweeperScreenViewModel));
            }
            return rows;
        }
    }
}