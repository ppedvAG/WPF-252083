using System.Globalization;
using System.Windows.Controls;

namespace M009.Validation;

class LengthValidation : ValidationRule
{
	public int Min { get; set; }

	public int Max { get; set; }

	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		string str = value as string;
		if (string.IsNullOrEmpty(str))
			return new ValidationResult(false, "Bitte gib einen Text ein.");

		if (str.Length < Min || str.Length > Max)
			return new ValidationResult(false, $"Der Text muss zwischen {Min} und {Max} Zeichen haben.");

		return ValidationResult.ValidResult;
	}
}
