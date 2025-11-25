using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace M004;

class ScoreToColorConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		double d = (double)value;

		return d switch
		{
			< 50 => new SolidColorBrush(Colors.DarkRed),
			< 60 => new SolidColorBrush(Colors.Red),
			< 70 => new SolidColorBrush(Colors.Orange),
			< 80 => new SolidColorBrush(Colors.Yellow),
			< 90 => new SolidColorBrush(Colors.LightGreen),
			_ => new SolidColorBrush(Colors.Green)
		};
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
