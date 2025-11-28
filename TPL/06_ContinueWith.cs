namespace TPL;

internal class _06_ContinueWith
{
	static void Main(string[] args)
	{
		Task<int> t = new Task<int>(Run);
		//Mit ContinueWith kann ein Folgetask konfiguriert werden
		//Wenn t fertig ist, wird der Folgetask gestartet
		t.ContinueWith(v => Console.WriteLine(v.Result)); //WICHTIG: v.Result wird hier in einem Task ausgeführt

		//WICHTIG: ContinueWith muss vor Start passieren
		t.Start();

		for (int i = 0; i < 100; i++)
		{
			Thread.Sleep(25);
			Console.WriteLine($"Main Thread: {i}");
		}

		//////////////////////////////////////////////////////////////////

		Task t2 = new Task(Exception);
		t2.ContinueWith(v => Console.WriteLine("Erfolg"), TaskContinuationOptions.OnlyOnRanToCompletion); //Folgetask mit Bedingung
		t2.ContinueWith(v => Console.WriteLine(v.Exception), TaskContinuationOptions.OnlyOnFaulted); //Folgetask mit Bedingung
		t2.Start();

		Console.ReadKey();
	}

	static int Run()
	{
		Thread.Sleep(Random.Shared.Next(100, 1000));
		return Random.Shared.Next();
	}

	static void Exception()
	{
		throw new OperationCanceledException();
	}
}
