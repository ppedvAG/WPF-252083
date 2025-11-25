using System.Windows;
using System.Windows.Media.Imaging;

namespace M002;

public partial class MainWindow : Window
{
	private string CurrentPath = "C:\\Users\\lk3\\Downloads\\WPF_2025_11_25\\M002\\ppedv-Logo.png";

	public MainWindow()
	{
		InitializeComponent();

		Wochentage.ItemsSource = Enum.GetValues<DayOfWeek>();
	}

	private void DasIstEinButton(object sender, RoutedEventArgs e)
	{
		//Eingabe.Text

		string pfad1 = "C:\\Users\\lk3\\Downloads\\WPF_2025_11_25\\M002\\ppedv-Logo.png";
		string pfad2 = "C:\\Users\\lk3\\Downloads\\WPF_2025_11_25\\M002\\ppedv-Background.png";

		if (CurrentPath == pfad1)
		{
			Img.Source = BitmapFrame.Create(new Uri(pfad2));
			CurrentPath = pfad2;
		}
		else
		{
			Img.Source = BitmapFrame.Create(new Uri(pfad1));
			CurrentPath = pfad1;
		}
	}

	private void ProjektClicked(object sender, RoutedEventArgs e)
	{

	}
}