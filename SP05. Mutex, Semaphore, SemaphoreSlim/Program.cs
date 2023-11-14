// lock/monitor - lock mechanism
// Mutex, Semaphore, SemaphoreSlim - signaling mechanism

#region Mutex
//Mutex mutex = new();


//int numb = 1;

//for (int i = 0; i < 5; i++)
//{
//    Thread thread = new(Count);
//    thread.Name = $"Thread number {i}";
//    thread.Start();
//}
//Console.ReadKey();

//void Count()
//{
//    mutex.WaitOne();
//    numb = 1;
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name}: {numb}");
//        numb++;
//    }
//    mutex.ReleaseMutex();
//}
#endregion

#region Global Mutex
//string MutexName = "Yaxchi oqlan";
//using (var mutex = new Mutex(false, MutexName))
//{
//    if (!mutex.WaitOne())
//    {
//        Console.WriteLine("Other instance is running");
//        Thread.Sleep(1000);
//        return;
//    }
//    else
//    {
//        Console.WriteLine("My code is running");
//        Console.ReadKey();
//        Thread.Sleep(100);
//        mutex.ReleaseMutex();
//    }
//}
#endregion

#region Semaphore

//SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3, 3);
Semaphore semaphore = new Semaphore(3, 3, "mySemaphore");
for (int i = 0; i < 15; i++)
{
    ThreadPool.QueueUserWorkItem(Some, semaphore);
}
Some(new object());
Console.ReadKey();


void Some(object state)
{
    
    var s = state as Semaphore;
    bool st = false;
    while (!st)
    {
        if (s.WaitOne(500))
        {
            try
            {
                Console.WriteLine($"Mr. {Thread.CurrentThread.ManagedThreadId} take key");
                Thread.Sleep(10000);

            }
            finally {
                st = true;
                Console.WriteLine($"Mr. {Thread.CurrentThread.ManagedThreadId} return key");
                s.Release();
            }
        }
        else
        {
            Console.WriteLine($"Mr. {Thread.CurrentThread.ManagedThreadId} sorry hele empty otaq yoxdur");
        }
    }
}
#endregion


