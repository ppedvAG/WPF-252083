using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace M004;

public class FourValueToMarginConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		//double[] doubles = new double[values.Length];
		//for (int i = 0; i < values.Length; i++)
		//{
		//	object o = values[i];
		//	doubles[i] = (double)o;
		//}
		//return new Thickness(doubles[0], doubles[1], doubles[2], doubles[3]);
		
		double[] d = values.OfType<double>().ToArray();
		return new Thickness(d[0], d[1], d[2], d[3]);
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
