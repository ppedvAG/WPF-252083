using System.Globalization;
using System.Windows.Controls;
using System.Windows.Media;

namespace M000.Validation;

internal class ColorValidation : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		if (value is not Color c || c == Color.FromArgb(0, 0, 0, 0))
			return new ValidationResult(false, "Wähle eine Farbe aus.");

		return ValidationResult.ValidResult;
	}
}
