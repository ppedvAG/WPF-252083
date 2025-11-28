using System.ComponentModel;

namespace M014.ViewModel;

public class ViewModelBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string param)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(param));
	}
}
