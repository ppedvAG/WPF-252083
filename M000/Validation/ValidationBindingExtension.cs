using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace M000.Validation;

class ValidationBindingExtension : MarkupExtension
{
	/// <summary>
	/// Das tatsächliche Binding
	/// </summary>
	public Binding Binding { get; set; }

	/// <summary>
	/// Eine einzelne Regel
	/// </summary>
	public ValidationRule Rule { get; set; }

	/// <summary>
	/// Mehrere Regeln
	/// </summary>
	public ValidationRuleCollection Rules { get; set; }

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		//Regeln hinzufügen
		if (Rule != null)
			Binding.ValidationRules.Add(Rule);

		if (Rules != null)
			foreach (ValidationRule rule in Rules)
				Binding.ValidationRules.Add(rule);

		//Hier wird das Binding einfach weiter ausgeführt
		return Binding.ProvideValue(serviceProvider);
	}
}

/// <summary>
/// Wrapper-Klasse um das Generic los zu werden
/// </summary>
public class ValidationRuleCollection : Collection<ValidationRule>;