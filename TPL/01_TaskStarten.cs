namespace TPL;

internal class _01_TaskStarten
{
	static void Main(string[] args)
	{
		Task t = new Task(Run);
		t.Start();

		Task t2 = Task.Factory.StartNew(Run); //ab .NET Framework 4.0

		Task t3 = Task.Run(Run); //ab .NET Framework 4.5

		for (int i = 0; i < 100; i++)
		{
			Console.WriteLine($"Main Thread: {i}");
		}

		//Hintergrundthreads: Wenn ein Task angelegt wird, ist dieser ein Hintergrundthread
		//Wenn alle Vordergrundthreads (hier der Main Thread) fertig sind, werden die Hintergrundthreads abgebrochen
		//In WPF automatisch (solange die GUI läuft)
		Console.ReadKey();
	}

	static void Run()
	{
		for (int i = 0; i < 100; i++)
		{
			Console.WriteLine($"Task: {i}");
		}
	}
}
