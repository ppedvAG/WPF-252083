using System.Collections.ObjectModel;
using System.Windows;

namespace M007;

public partial class MainWindow : Window
{
	public ObservableCollection<Person> Personen { get; set; } =
	[
		new Person() { Vorname = "Max", Nachname = "Mustermann1" },
		new Person() { Vorname = "Max", Nachname = "Mustermann2" },
		new Person() { Vorname = "Max", Nachname = "Mustermann3" },
		new Person() { Vorname = "Max", Nachname = "Mustermann1" },
		new Person() { Vorname = "Max", Nachname = "Mustermann2" },
		new Person() { Vorname = "Max", Nachname = "Mustermann3" },
		new Person() { Vorname = "Max", Nachname = "Mustermann1" },
		new Person() { Vorname = "Max", Nachname = "Mustermann2" },
		new Person() { Vorname = "Max", Nachname = "Mustermann3" },
		new Person() { Vorname = "Max", Nachname = "Mustermann1" },
		new Person() { Vorname = "Max", Nachname = "Mustermann2" },
		new Person() { Vorname = "Max", Nachname = "Mustermann3" }
	];

	public MainWindow()
	{
		InitializeComponent();
	}
}