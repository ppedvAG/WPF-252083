using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TPL_AsyncAwait;

internal class Program
{
	static async Task Main(string[] args)
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		//Toast();
		//Tasse();
		//Kaffee();
		//Console.WriteLine(stopwatch.ElapsedMilliseconds); //7s

		////////////////////////////////////////////////////////////////

		//Tasks
		//Task t1 = new Task(Toast);
		//t1.Start();
		//Task t2 = new Task(Tasse);
		//t2.Start();
		//t2.Wait(); //Warte, bis die Tasse fertig ist
		//Task t3 = new Task(Kaffee);
		//t3.Start();
		//Task.WaitAll(t1, t3); //Wait und WaitAll kann nicht in der GUI verwendet werden -> ContinueWith
		//Console.WriteLine(stopwatch.ElapsedMilliseconds);

		////////////////////////////////////////////////////////////////

		//Tasks mit ContinueWith
		//int z = 0;
		//Task t1 = new Task(Toast);
		//t1.ContinueWith(v => z++);
		//t1.Start();
		//Task t2 = new Task(Tasse);
		//t2.ContinueWith(v => Kaffee()).ContinueWith(v => z += 2);
		//t2.Start();

		//Task.Run(() =>
		//{
		//	while (z != 3)
		//		continue;
		//	Console.WriteLine(stopwatch.ElapsedMilliseconds);
		//});

		////////////////////////////////////////////////////////////////

		//await
		//Task t1 = Task.Run(Toast);
		//Task t2 = new Task(Tasse);
		//Task t3 = t2.ContinueWith(v => Kaffee());
		//t2.Start();
		////await t1; //Warte auf den Toast
		////await t3; //Warte auf den Kaffee
		//await Task.WhenAll(t1, t3); //Warte auf mehrere Tasks
		//Console.WriteLine(stopwatch.ElapsedMilliseconds);

		////////////////////////////////////////////////////////////////

		//Eigene async Methoden
		//Um innerhalb einer Methode das await Keyword verwenden zu können, muss diese als async gekennzeichet sein

		//Task t1 = ToastAsync(); //async Task Methoden starten automatisch (kein t.Start(), Task.Run(...) notwendig)
		//Task t2 = TasseAsync();
		//await t2;
		//Task t3 = KaffeeAsync();
		//await Task.WhenAll(t1, t3);
		//Console.WriteLine(stopwatch.ElapsedMilliseconds);

		////////////////////////////////////////////////////////////////

		//async/await mit Objekten
		Task<Toast> t1 = ToastObjectAsync();
		Task<Tasse> t2 = TasseObjectAsync();
		Tasse tasse = await t2; //await macht auch ein t.Result
		Task<Kaffee> t3 = KaffeeObjectAsync(tasse);
		await Task.WhenAll(t1, t3);
		Console.WriteLine(stopwatch.ElapsedMilliseconds);

		Console.ReadKey();
	}

	#region Synchron
	public static void Toast()
	{
		Thread.Sleep(4000);
		Console.WriteLine("Toast fertig");
	}

	public static void Tasse()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Tasse fertig");
	}

	public static void Kaffee()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Kaffee fertig");
	}
	#endregion

	#region Asynchron
	static async Task ToastAsync()
	{
		await Task.Delay(4000);
		Console.WriteLine("Toast fertig");
	}

	static async Task TasseAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Tasse fertig");
	}

	static async Task KaffeeAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee fertig");
	}
	#endregion

	#region	Asynchron mit Objekten
	static async Task<Toast> ToastObjectAsync()
	{
		await Task.Delay(4000);
		Console.WriteLine("Toast fertig");
		return new Toast();
	}

	static async Task<Tasse> TasseObjectAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Tasse fertig");
		return new Tasse();
	}

	static async Task<Kaffee> KaffeeObjectAsync(Tasse t)
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee fertig");
		return new Kaffee(t);
	}
	#endregion
}

class Toast;

class Tasse;

class Kaffee(Tasse t);