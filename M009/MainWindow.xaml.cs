using System.ComponentModel;
using System.Windows;

namespace M009;

public partial class MainWindow : Window, IDataErrorInfo
{
	public string Vorname { get; set; }

	public string Nachname { get; set; }

	private int alter;
	public int Alter
	{
		get => alter;
		set
		{
			if (value < 6 || value > 30)
				throw new Exception("Alter muss zwischen 6 und 30 sein.");
			alter = value;
		}
	}

	public string MittlererName { get; set; }

	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{

	}

	/// <summary>
	/// Kann ignoriert werden
	/// </summary>
	public string Error => throw new NotImplementedException();

	public string this[string propName]
	{
		get
		{
			switch (propName)
			{
				case nameof(MittlererName):
					if (string.IsNullOrEmpty(MittlererName))
						return "Bitte gib einen Namen ein.";

					if (MittlererName.Length < 3 || MittlererName.Length > 15)
						return "Name muss zw. 3 und 15 Zeichen haben";

					return null; //return null: keine Fehler
			}
			return null;
		}
	}
}