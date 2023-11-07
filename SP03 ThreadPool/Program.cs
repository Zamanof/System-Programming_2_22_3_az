Console.WriteLine("Main method start...");
//ThreadPool.GetAvailableThreads(out int workerCount, out int complCount);
//Console.WriteLine(workerCount);
//Console.WriteLine(complCount);

ThreadPool.QueueUserWorkItem(AsyncOperation, "Salam");
ThreadPool.QueueUserWorkItem(o =>
{
    SomeOperation();
});

Console.WriteLine($"Main method thread Id: {Thread.CurrentThread.ManagedThreadId}");
Console.WriteLine($"Main method isBackground: {Thread.CurrentThread.IsBackground}");
Console.WriteLine($"Main method isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
Console.WriteLine("Main method end...");
Console.ReadKey();

void AsyncOperation(object state)
{
    Console.WriteLine("AsyncOperation method start...");
    Console.WriteLine(state.ToString());
    Thread.Sleep(1000);
    Console.WriteLine($"AsynOperation thread Id: {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"AsynOperation isBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"AsynOperation isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine("AsyncOperation method end...");
}

void SomeOperation()
{
    Console.WriteLine("SomeOperation method start...");
    Thread.Sleep(1000);
    Console.WriteLine($"SomeOperation thread Id: {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"SomeOperation isBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"SomeOperation isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine("SomeOperation method end...");
}
