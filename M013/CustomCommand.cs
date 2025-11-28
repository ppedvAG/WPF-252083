using System.Windows.Input;

namespace M013;

public class CustomCommand : ICommand
{
	private Action<object> _executeAction;

	private Func<object, bool> _canExecuteFunc;

	public CustomCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc = null)
	{
		_executeAction = executeAction;
		_canExecuteFunc = canExecuteFunc;
	}

	//////////////////////////////////////////////////////////////////////////////////////

	public void Execute(object? parameter) => _executeAction(parameter);

	public bool CanExecute(object? parameter) => _canExecuteFunc == null ? true : _canExecuteFunc(parameter);

	public event EventHandler? CanExecuteChanged;
}