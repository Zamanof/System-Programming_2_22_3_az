var babaTask = new Task<int>(() =>
{
    var ataTask = Task.Factory.StartNew(() =>
    {
        var neveTask = Task.Factory.StartNew(() =>
        {
            TaskMethod("Neve Task", 5);
        }, TaskCreationOptions.AttachedToParent);
        TaskMethod("Ata Task", 5);
       
    }, TaskCreationOptions.AttachedToParent);
    //ataTask.ContinueWith((t) =>
    //{
    //    TaskMethod("Neve task", 2);
    //}, TaskContinuationOptions.AttachedToParent);
    while (!ataTask.IsCompleted)
    {
        Console.WriteLine(ataTask.Status);
    }
    Console.WriteLine(ataTask.Status);
    Thread.Sleep(1000);
    return TaskMethod("Baba Task", 3);
    
});

babaTask.Start();
babaTask.Wait();
Console.WriteLine("End");


int TaskMethod(string message, int second)
{
    Console.WriteLine($"Task: {message} is running " +
        $"Id: {Thread.CurrentThread.ManagedThreadId}" +
        $"IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
    Thread.Sleep(second * 1000);
    Console.WriteLine($"{message} Method return value");

    return second * 10;
}
