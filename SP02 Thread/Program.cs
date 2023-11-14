//Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
Thread thread1 = new Thread(() =>
{
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"\t{Thread.CurrentThread.ManagedThreadId} - {i} - {Thread.CurrentThread.IsBackground}");
    }    
});
//thread1.Priority = ThreadPriority.Highest;
//thread1.IsBackground = true;
thread1.Start();

//new Thread(() =>
//{
//    for (int i = 0; i < 100; i++)
//    {
//        Console.WriteLine($"\t\t\t{Thread.CurrentThread.ManagedThreadId} - {i}");
//    }
//}).Start();
//ThreadStart thread = new ThreadStart(Some);
//ParameterizedThreadStart parameterized = new(Some);
Thread thread2 = new Thread(Some);
//thread2.Priority = ThreadPriority.Lowest;
thread2.Start();

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {i} - {Thread.CurrentThread.IsBackground}");
}

thread1.Join(); // Chaqiran thread-i gozletdirir
// thread1.Suspend(); // Thread-i pause-ya qoyur
// thread1.Resume(); // Thread-i davam etdirir
// thread1.Abort(); // Thread-i dayandirir
// thread1.Interrupt();


void Some()
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"\t\t{Thread.CurrentThread.ManagedThreadId} - {i} - {Thread.CurrentThread.IsBackground}");
    }
}
