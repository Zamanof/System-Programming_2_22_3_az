using System.Diagnostics;

int operationCount = 500;
var watch = new Stopwatch();
watch.Start();
UseThread(operationCount);
watch.Stop();
Console.WriteLine($"Milliseconds {watch.ElapsedMilliseconds}");
watch.Reset();

watch.Start();
UseThreadPool(operationCount);
watch.Stop();
Console.WriteLine($"Milliseconds {watch.ElapsedMilliseconds}");
void UseThread(int operationCount)
{
    using(var countdown = new CountdownEvent(operationCount))
    {
        Console.WriteLine("Threads...");
        for (int i = 0; i < operationCount; i++)
        {
            var thread = new Thread(() => {
                Console.Write($"{Thread.CurrentThread.ManagedThreadId} ");
                Thread.Sleep(100);
                countdown.Signal();
            });    
            thread.Start();
        }
        countdown.Wait();
        Console.WriteLine();
    }
}

void UseThreadPool(int operationCount)
{
    using (var countdown = new CountdownEvent(operationCount))
    {
        Console.WriteLine("ThreadPool...");
        for (int i = 0; i < operationCount; i++)
        {
            ThreadPool.QueueUserWorkItem(o => {
                Console.Write($"{Thread.CurrentThread.ManagedThreadId} ");
                Thread.Sleep(100);
                countdown.Signal();
            });
        }
        countdown.Wait();
        Console.WriteLine();
    }
}
