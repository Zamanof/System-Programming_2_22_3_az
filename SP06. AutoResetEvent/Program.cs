AutoResetEvent _workEvent = new AutoResetEvent(false);
AutoResetEvent _mainEvent = new AutoResetEvent(false);

Thread thread = new Thread(() =>
{
    SomeProcess(1);
});
thread.Start();

Console.WriteLine("Waiting SomeProcess");

_workEvent.WaitOne();
// 2 start
Console.WriteLine("Starting Some Process");
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Main - {i}: ");
    Thread.Sleep(1000);
}
// 2 end
_mainEvent.Set();

Console.WriteLine("Worker is doing some job");
_workEvent.WaitOne();

Console.WriteLine("Complete");
void SomeProcess(int seconds)
{
    // 1 start
    Console.WriteLine("Starting some process");
    Thread.Sleep(TimeSpan.FromSeconds(seconds));
    Console.WriteLine("Ok");
    // 1 end
    _workEvent.Set();
    Console.WriteLine("Main thread is working");
    _mainEvent.WaitOne();

    // 3. start
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Some process - {i}");
        Thread.Sleep(TimeSpan.FromSeconds(seconds));
    }
    // 3. end
    _workEvent.Set();
}
