using System.Globalization;
using System.Windows.Data;

namespace M000;

public class BoolToGenderConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return (Geschlecht) value == (Geschlecht) parameter;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return (bool) value ? (Geschlecht) parameter : Binding.DoNothing;
	}
}
