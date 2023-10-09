using Cells;

namespace ViewModel;

public abstract class ScreenViewModel
{
    protected ICell<ScreenViewModel> CurrentScreen { get; }

    protected ScreenViewModel(ICell<ScreenViewModel> currentScreen)
    {
        this.CurrentScreen = currentScreen;
    }
}