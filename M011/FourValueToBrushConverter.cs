using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace M011;

public class FourValueToBrushConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		byte[] b = values.OfType<double>().Select(e => (byte) e).ToArray();

		Color c = Color.FromArgb(b[0], b[1], b[2], b[3]);

		return new SolidColorBrush(c);
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
