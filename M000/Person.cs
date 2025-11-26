using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace M000;

public class Person : INotifyPropertyChanged
{
	private string vorname;
	private string nachname;
	private DateTime gebdat;
	private bool verheiratet;
	private Color lieblingsfarbe;
	private Geschlecht gender;

	public string Vorname
	{
		get => vorname;
		set
		{
			vorname = value;
			Notify();
		}
	}

	public string Nachname
	{
		get => nachname;
		set
		{
			nachname = value;
			Notify();
		}
	}

	public DateTime Gebdat
	{
		get => gebdat;
		set
		{
			gebdat = value;
			Notify();
		}
	}

	public bool Verheiratet
	{
		get => verheiratet;
		set
		{
			verheiratet = value;
			Notify();
		}
	}

	public Color Lieblingsfarbe
	{
		get => lieblingsfarbe;
		set
		{
			lieblingsfarbe = value;
			Notify();
		}
	}

	public Geschlecht Gender
	{
		get => gender;
		set
		{
			gender = value;
			Notify();
		}
	}

	#region INotifyPropertyChanged
	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	#endregion

	public string Error => null;

	public string this[string columnName]
	{
		get
		{
			switch (columnName)
			{

				case nameof(Vorname):
					if (Vorname.Length <= 0 || Vorname.Length > 50) return "Bitte geben Sie Ihren Vornamen ein.";
					if (!Vorname.All(x => Char.IsLetter(x))) return "Der Vorname darf nur Buchstaben enthalten.";
					if (Char.IsLower(Vorname.First())) return "Der Vorname muss mit einem Groﬂbuchstaben beginnen";
					break;

				case nameof(Nachname):
					if (Nachname.Length <= 0 || Nachname.Length > 50) return "Bitte geben Sie Ihren Nachnamen ein.";
					if (!Nachname.All(x => Char.IsLetter(x))) return "Der Nachname darf nur Buchstaben enthalten.";
					if (Char.IsLower(Nachname.First())) return "Der Nachname muss mit einem Groﬂbuchstaben beginnen";
					break;

				case nameof(Gebdat):
					if (Gebdat > DateTime.Now) return "Das Geburtsdatum darf nicht in der Zukunft liegen.";
					if (DateTime.Now.Year - Gebdat.Year > 150) return "Das Geburtsdatum darf nicht mehr als 150 Jahre in der Vergangenheit liegen.";
					break;

				case nameof(Lieblingsfarbe):
					if (Lieblingsfarbe.ToString().Equals("#00000000")) return "W‰hlen Sie Ihre Lieblingsfarbe aus.";
					break;
			}

			return String.Empty;
		}
	}
}

public enum Geschlecht
{
	M, W, D
}