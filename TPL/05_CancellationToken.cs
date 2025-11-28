namespace TPL;

internal class _05_CancellationToken
{
	static void Main(string[] args)
	{
		CancellationTokenSource cts = new();
		CancellationToken ct = cts.Token; //Struct, Kopie von dem Standardtoken wird erzeugt

		Task t = new Task(Run, ct);
		t.Start();

		cts.CancelAfter(500);

		Console.ReadKey();
	}

	static void Run(object o)
	{
		if (o is CancellationToken ct)
		{
			for (int i = 0; i < 100; i++)
			{
				if (ct.IsCancellationRequested)
					ct.ThrowIfCancellationRequested(); //Wenn im Task eine Exception auftritt, bekommt man diese nicht mit

				Thread.Sleep(25);
				Console.WriteLine($"Task: {i}");
			}
		}
	}
}