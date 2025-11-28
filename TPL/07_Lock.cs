namespace TPL;

internal class _07_Lock
{
	public static int Counter;

	public static object LockObj = new();

	static void Main(string[] args)
	{
		List<Task> tasks = [];
		for (int i = 0; i < 100; i++)
			tasks.Add(Task.Run(CounterIncrement));
		Console.ReadKey();
	}

	public static void CounterIncrement()
	{
		lock (LockObj)
		{
			Counter++;
			Console.WriteLine(Counter);
		}

		Interlocked.Add(ref Counter, 1);
	}
}
