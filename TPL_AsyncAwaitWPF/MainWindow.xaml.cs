using System.Diagnostics;
using System.Windows;

namespace TPL_AsyncAwaitWPF;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void StartTasks(object sender, RoutedEventArgs e)
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		Task t1 = Task.Run(Toast);
		Task t2 = new Task(Tasse);
		Task t3 = t2.ContinueWith(v => Kaffee());
		t2.Start();
		Task.WaitAll(t1, t3); //Wait und WaitAll kann nicht in der GUI verwendet werden -> ContinueWith
		Output.Text += stopwatch.ElapsedMilliseconds + "\n";
	}

	private async void StartAsync(object sender, RoutedEventArgs e)
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		Task t1 = Task.Run(Toast);
		Task t2 = new Task(Tasse);
		Task t3 = t2.ContinueWith(v => Kaffee());
		t2.Start();
		await t1; //Warte auf den Toast
		await t3; //Warte auf den Kaffee
		Output.Text += stopwatch.ElapsedMilliseconds + "\n";
	}

	public void Toast()
	{
		Thread.Sleep(4000);
		Dispatcher.Invoke(() => Output.Text += "Toast fertig" + "\n");
	}

	public void Tasse()
	{
		Thread.Sleep(1500);
		Dispatcher.Invoke(() => Output.Text += "Tasse fertig" + "\n");
	}

	public void Kaffee()
	{
		Thread.Sleep(1500);
		Dispatcher.Invoke(() => Output.Text += "Kaffee fertig" + "\n");
	}
}