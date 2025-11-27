using M011_Pages.Pages;
using System.Windows;

namespace M011_Pages;

public partial class MainWindow : Window
{
	public IPage CurrentPage { get; set; }

	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		if (CurrentPage is Page1)
			CurrentPage = new Page2();
		else
			CurrentPage = new Page1();
	}
}