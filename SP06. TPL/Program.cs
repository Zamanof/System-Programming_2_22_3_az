// TPL - Task Parallel Library

// Thread -> ThreadPoll -> TPL
Console.WriteLine("Start of code");

Task task1 = new Task(() =>
{
    TaskMethod("Task1");
});
Task task2 = new Task(() =>
{
    TaskMethod("Task2");
});

var task3 = Task.Run(()=> { 
    TaskMethod("Task3"); 
});
task1.Start();

var task4 = Task.Factory.StartNew(() => {
    TaskMethod("Task4");
});

var task5 = Task.Factory.StartNew(() => {
    TaskMethod("Task4");
}, TaskCreationOptions.LongRunning);

task2.Start();
Thread.Sleep(1000);
Console.WriteLine("End of code");

void TaskMethod(string message)
{
    // @ - verbatim
    Console.WriteLine($@"Task - {message} is running.
Id - {Thread.CurrentThread.ManagedThreadId}
IsThreadPool - {Thread.CurrentThread.IsThreadPoolThread}
{new String('_', 25)}");
}
