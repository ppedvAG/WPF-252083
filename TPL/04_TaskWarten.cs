namespace TPL;

internal class _04_TaskWarten
{
	static void Main(string[] args)
	{
		Task t = new Task(Run);
		t.Start();

		t.Wait(); //In WPF tödlich

		for (int i = 0; i < 100; i++)
		{
			Console.WriteLine($"Main Thread: {i}");
		}

		Task.WaitAll(t); //In WPF tödlich
		Task.WaitAny(t); //In WPF tödlich

		Console.ReadKey();
	}

	static void Run()
	{
		Thread.Sleep(500);
		Console.WriteLine("Task fertig");
	}
}
