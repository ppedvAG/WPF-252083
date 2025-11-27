using System.Globalization;
using System.Windows.Data;

namespace M010;

internal class PercentConverter : IValueConverter
{
	public double Minimum { get; set; }

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		double d = (double)value;
		return d >= Minimum;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
