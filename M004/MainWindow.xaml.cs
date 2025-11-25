using System.Windows;
using System.Windows.Controls;

namespace M004;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Eingabe.GetBindingExpression(TextBox.TextProperty).UpdateSource();
	}
}