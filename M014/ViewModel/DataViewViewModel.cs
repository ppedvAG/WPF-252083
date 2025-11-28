using M014.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace M014.ViewModel;

public class DataViewViewModel : ViewModelBase
{
	public ObservableCollection<Person> Personen { get; } = [];

	public CustomCommand DeletePersonCommand { get; set; }

	public DataViewViewModel()
	{
		DeletePersonCommand = new CustomCommand(DeletePerson);

		string readJson = File.ReadAllText(@"Personen.json");
		Personen = new ObservableCollection<Person>(JsonSerializer.Deserialize<List<Person>>(readJson)!);
	}

	public void DeletePerson(object parameter)
	{
		Personen.Remove((Person) parameter);
	}
}
