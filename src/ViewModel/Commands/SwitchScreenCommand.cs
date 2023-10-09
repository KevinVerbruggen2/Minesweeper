using System.Windows.Input;

namespace ViewModel;

public class SwitchScreenCommand : ICommand
{
    private readonly Action action;

    public SwitchScreenCommand(Action action)
    {
        this.action = action;
    }

    public event EventHandler CanExecuteChanged { add { } remove { } }

    public bool CanExecute(object parameter)
    {
        // you can always switch screens
        return true;
    }

    public void Execute(object parameter)
    {
        this.action();
    }
}