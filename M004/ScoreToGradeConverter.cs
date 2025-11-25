using System.Globalization;
using System.Windows.Data;

namespace M004;

public class ScoreToGradeConverter : IValueConverter
{
	/// <summary>
	/// Quelle -> Ziel
	/// Slider -> TextBlock
	/// 
	/// value: double
	/// Rückgabe: string
	/// </summary>
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		double d = (double)value;
		//string note;
		//switch (d)
		//{
		//	case < 50:
		//		note = "Nicht Genügend";
		//		break;
		//	case < 60:
		//		note = "Ungenügend";
		//		break;
		//	case < 70:
		//		note = "Genügend";
		//		break;
		//	case < 80:
		//		note = "Befriedigend";
		//		break;
		//	case < 90:
		//		note = "Gut";
		//		break;
		//	default:
		//		note = "Sehr Gut";
		//		break;
		//}
		//return note;

		return d switch
		{
			< 50 => "Nicht Genügend",
			< 60 => "Ungenügend",
			< 70 => "Genügend",
			< 80 => "Befriedigend",
			< 90 => "Gut",
			_ => "Sehr Gut"
		};
	}

	/// <summary>
	/// Ziel -> Quelle
	/// TextBlock -> Slider
	/// </summary>
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}