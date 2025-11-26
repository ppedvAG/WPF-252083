using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace M006;

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
}

public enum Geschlecht
{
	M, W, D
}