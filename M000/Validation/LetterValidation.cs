using System.Globalization;
using System.Windows.Controls;

namespace M000.Validation;

class LetterValidation : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		string str = value as string;
		if (string.IsNullOrEmpty(str))
			return new ValidationResult(false, "Bitte gib einen Text ein.");

		if (!str.All(char.IsLetter))
			return new ValidationResult(false, "Der Text darf nur aus Buchstaben bestehen.");

		return ValidationResult.ValidResult;
	}
}