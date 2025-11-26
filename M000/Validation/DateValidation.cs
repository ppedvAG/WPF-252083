using System.Globalization;
using System.Windows.Controls;

namespace M000.Validation;

internal class DateValidation : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		DateTime dt = (DateTime)value;

		if (DateTime.Now.Year - dt.Year > 120)
			return new ValidationResult(false, "Das Datum darf nicht mehr als 120 Jahre in der Vergangenheit liegen.");

		if (dt > DateTime.Now)
			return new ValidationResult(false, "Das Datum darf nicht in der Zukunft liegen.");

		return ValidationResult.ValidResult;
	}
}
