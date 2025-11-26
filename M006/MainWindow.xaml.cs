using System.Windows;

namespace M006;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{

	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		Resources["DieZahl"] = (double) Resources["DieZahl"] + 1;
	}
}