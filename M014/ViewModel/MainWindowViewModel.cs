namespace M014.ViewModel;

public class MainWindowViewModel : ViewModelBase
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

	public CustomCommand ZaehlerCommand { get; set; }

	/// <summary>
	/// Konstruktor wird beim Einsetzen des DataContext im Window ausgeführt
	/// </summary>
	public MainWindowViewModel()
	{
		ZaehlerCommand = new CustomCommand(ZaehlerIncrement);
	}

	public void ZaehlerIncrement(object p)
	{
		Zaehler++;
		//Notify(nameof(Zaehler));
	}
}