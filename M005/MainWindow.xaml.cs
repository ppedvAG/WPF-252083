using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace M005;

public partial class MainWindow : Window, INotifyPropertyChanged
{
	private int counter = 123;

	public int Counter
	{
		get => counter;
		set
		{
			counter = value;
			Notify(nameof(Counter));
		}
	}

	public ObservableCollection<int> Zahlen { get; set; } = [];

	public MainWindow()
	{
		//this.DataContext = this;

		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Counter++;
		//Notify("Counter"); //GUI benachrichtigen

		Zahlen.Add(Random.Shared.Next());
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////

	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}