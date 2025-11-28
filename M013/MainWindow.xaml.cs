using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace M013;

public partial class MainWindow : Window
{
	public ExitCommand Exit { get; set; } = new();

	public CounterCommand Counter { get; set; } = new();

	public CustomCommand CustomCounter { get; set; }

	public CustomCommand EnterCommand { get; set; }

	public WrappedInt Zaehler { get; set; } = new();

	public string Input { get; set; }

	public MainWindow()
	{
		CustomCounter = new CustomCommand(ZaehlerIncrement);
		//EnterCommand = new CustomCommand(EnterPressed);

		InitializeComponent();
	}

	public void ZaehlerIncrement(object parameter)
	{
		Zaehler.Zaehler++;
	}

	public void EnterPressed(object parameter, EventArgs e)
	{
		TextBlock tb = (TextBlock) parameter;
		tb.Text = Input;
	}
}

public class WrappedInt : INotifyPropertyChanged
{
	private int zaehler;

	public int Zaehler
	{
		get => zaehler;
		set
		{
			zaehler = value;
			Notify(nameof(Zaehler));
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string param)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(param));
	}
}