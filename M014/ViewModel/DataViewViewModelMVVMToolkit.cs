using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M014.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace M014.ViewModel;

/// <summary>
/// MVVMToolkit
/// 
/// Viele nervige Dinge automatisieren
/// 
/// WICHTIG: Klasse muss partial sein und das ObservableObject als Oberklasse haben
/// </summary>
public partial class DataViewViewModelMVVMToolkit : ObservableObject
{
	/// <summary>
	/// ObservableProperty
	/// Generiert automatisch das public Property + INotifyPropertyChanged für dieses Feld
	/// </summary>
	[ObservableProperty]
	private ObservableCollection<Person> _personen = [];

	/// <summary>
	/// RelayCommand
	/// Erzeugt automatisch die Command Variable + Anhängen dieser Methode
	/// Generiert das Command mit dem Namen: [Methodenname]Command
	/// </summary>
	[RelayCommand]
	public void DeletePerson(object parameter)
	{
		Personen.Remove((Person) parameter);
	}

	public DataViewViewModelMVVMToolkit()
	{
		string readJson = File.ReadAllText(@"Personen.json");
		Personen = new ObservableCollection<Person>(JsonSerializer.Deserialize<List<Person>>(readJson)!);
	}
}