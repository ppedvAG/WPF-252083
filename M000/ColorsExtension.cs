using System.Reflection;
using System.Windows.Markup;
using System.Windows.Media;

namespace M000;

internal class ColorsExtension : MarkupExtension
{
	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		List<NamedColor> colors = [];
		foreach (PropertyInfo pi in typeof(Colors).GetProperties())
		{
			NamedColor nc = new NamedColor(pi.Name, (Color) pi.GetValue(null)); //pi.GetValue(null): Wert aus dem Property entnehmen (null weil static)
			colors.Add(nc);
		}
		return colors;
	}
}

public class NamedColor
{
	public string Name { get; set; }

	public Color Color { get; set; }

	public SolidColorBrush Brush { get => new SolidColorBrush(Color); }

	public NamedColor(string name, Color color)
	{
		Name = name;
		Color = color;
	}
}