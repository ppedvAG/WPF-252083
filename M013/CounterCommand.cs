using System.Windows.Input;

namespace M013;

public class CounterCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;

	public bool CanExecute(object? parameter) => true;

	public void Execute(object? parameter)
	{
		WrappedInt w = (WrappedInt) parameter;
		w.Zaehler++;
	}
}
