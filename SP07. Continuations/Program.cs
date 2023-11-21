


var firstTask = new Task<int>(() => TaskMethod("First Task", 2));
var secondTask = new Task<int>(() => TaskMethod("Second Task", 5));


//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine($"Continue Task result = {t.Result} " +
//        $"Id: {Thread.CurrentThread.ManagedThreadId} " +
//        $"IsThreadPool thread: {Thread.CurrentThread.IsThreadPoolThread}");
//}, TaskContinuationOptions.OnlyOnRanToCompletion);

//firstTask.ContinueWith((t) =>
//{
//    OtherMethod();
//    Console.WriteLine($"Continue Task result = {t.Result} " +
//        $"Id: {Thread.CurrentThread.ManagedThreadId} " +
//        $"IsThreadPool thread: {Thread.CurrentThread.IsThreadPoolThread}");
//}, TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.NotOnCanceled);


firstTask.Start();
secondTask.Start();

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
    Thread.Sleep(100);
}
//Console.WriteLine(firstTask.Result);
//Console.WriteLine(secondTask.Result);
Task[] tasks = new Task[] { firstTask, secondTask };
Task.WaitAll(firstTask, secondTask);
//Task.WaitAny(tasks);

Console.WriteLine("Lyuboy bir shey");
Console.WriteLine("End of Main");
int TaskMethod(string message, int second)
{
    Console.WriteLine($"Task: {message} is running " +
        $"Id: {Thread.CurrentThread.ManagedThreadId}" +
        $"IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
    Thread.Sleep(second * 1000);
    Console.WriteLine($"{message} Method return value");

    return second * 10;
}

void OtherMethod()
{
    Console.WriteLine("Other method is running");
    Console.WriteLine($"IsThreadPool thread: {Thread.CurrentThread.IsThreadPoolThread}");
}