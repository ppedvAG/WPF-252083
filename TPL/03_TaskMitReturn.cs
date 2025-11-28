namespace TPL;

internal class _03_TaskMitReturn
{
	static void Main(string[] args)
	{
		Task<int> t = new Task<int>(Run);
		t.Start();

		//Problem: Blockade des Main Threads
		//In WPF ist t.Result tödlich
		//Lösungen: ContinueWith, await
		bool hasPrinted = false;
		for (int i = 0; i < 100; i++)
		{
			Thread.Sleep(25);
			Console.WriteLine($"Main Thread: {i}");

			if (t.IsCompletedSuccessfully && !hasPrinted)
			{
				Console.WriteLine(t.Result);
				hasPrinted = true;
			}
		}

		Console.ReadKey();
	}

	static int Run()
	{
		Thread.Sleep(500);
		return Random.Shared.Next();
	}
}
