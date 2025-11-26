using System.Windows.Markup;

namespace M008;

public class EnumExtension : MarkupExtension
{
	public Type EnumType { get; set; }

	/// <summary>
	/// ProvideValue
	/// Wird von der GUI ausgeführt
	/// Setzt den Rückgabewert in der GUI ein
	/// </summary>
	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		if (EnumType == null)
			throw new ArgumentNullException("EnumType darf nicht null sein");

		if (!EnumType.IsEnum)
			throw new ArgumentException("EnumType ist kein Enum Typ");

		return Enum.GetValues(EnumType);
	}
}