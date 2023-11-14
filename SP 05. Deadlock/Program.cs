// Deadlock

object obj1 = new();
object obj2 = new();

Thread thread1 = new(ObliviousMethod);
Thread thread2 = new(BlindMethod);

thread1.Start();
thread2.Start();


void ObliviousMethod()
{
    Console.WriteLine("ObliviousMethod");
	lock (obj1)
	{
		Thread.Sleep(1000);
		lock (obj2) { }
	}
}

void BlindMethod()
{
    Console.WriteLine("BlindMethod");
	lock (obj2) {
        Thread.Sleep(1000);
        lock (obj1) { }
    }
}