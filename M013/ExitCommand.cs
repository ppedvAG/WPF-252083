using System.Windows.Input;

namespace M013;

public class ExitCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;

	public void Execute(object? parameter)
	{
		Environment.Exit(0);
	}

	public bool CanExecute(object? parameter)
	{
		return true;
	}
}
