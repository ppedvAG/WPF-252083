using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace M011;

public partial class ColorPickerUC : UserControl
{
	////////////////////////////////////////////////////////////////////////////

	public double R
	{
		get => (double) GetValue(RProperty);
		set => SetValue(RProperty, value);
	}

	public static readonly DependencyProperty RProperty =
		DependencyProperty.Register
		(
			nameof(R),
			typeof(double),
			typeof(ColorPickerUC),
			new PropertyMetadata(0d, SliderValueChanged)
		);

	////////////////////////////////////////////////////////////////////////////

	public double G
	{
		get => (double) GetValue(GProperty);
		set => SetValue(GProperty, value);
	}

	public static readonly DependencyProperty GProperty =
		DependencyProperty.Register
		(
			nameof(G),
			typeof(double),
			typeof(ColorPickerUC),
			new PropertyMetadata(0d, SliderValueChanged)
		);

	////////////////////////////////////////////////////////////////////////////

	public double B
	{
		get => (double) GetValue(BProperty);
		set => SetValue(BProperty, value);
	}

	public static readonly DependencyProperty BProperty =
		DependencyProperty.Register
		(
			nameof(B),
			typeof(double),
			typeof(ColorPickerUC),
			new PropertyMetadata(0d, SliderValueChanged)
		);

	////////////////////////////////////////////////////////////////////////////
	
	public double A
	{
		get => (double) GetValue(AProperty);
		set => SetValue(AProperty, value);
	}

	public static readonly DependencyProperty AProperty =
		DependencyProperty.Register
		(
			nameof(A),
			typeof(double),
			typeof(ColorPickerUC),
			new PropertyMetadata(255d, SliderValueChanged)
		);

	////////////////////////////////////////////////////////////////////////////

	public Color PickedColor
	{
		get => (Color) GetValue(PickedColorProperty);
		set => SetValue(PickedColorProperty, value);
	}

	public static readonly DependencyProperty PickedColorProperty =
		DependencyProperty.Register
		(
			nameof(PickedColor),
			typeof(Color),
			typeof(ColorPickerUC),
			new PropertyMetadata(Colors.Transparent, PickedColorChanged)
		);

	////////////////////////////////////////////////////////////////////////////

	public ColorPickerUC()
	{
		InitializeComponent();
	}

	public static void SliderValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//d: ColorPickerUC
		byte r = (byte) (double) d.GetValue(RProperty);
		byte g = (byte) (double) d.GetValue(GProperty);
		byte b = (byte) (double) d.GetValue(BProperty);
		byte a = (byte) (double) d.GetValue(AProperty);

		Color color = Color.FromArgb(a, r, g, b);
		d.SetValue(PickedColorProperty, color);
	}

	public static void PickedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//d: ColorPickerUC
		Color color = (Color) d.GetValue(PickedColorProperty);

		byte r = color.R;
		byte g = color.G;
		byte b = color.B;
		byte a = color.A;

		d.SetValue(RProperty, (double) r);
		d.SetValue(GProperty, (double) g);
		d.SetValue(BProperty, (double) b);
		d.SetValue(AProperty, (double) a);
	}
}