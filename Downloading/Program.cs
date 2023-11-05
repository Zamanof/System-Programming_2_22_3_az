Thread downloadThread = new Thread(DownloadFile);
downloadThread.Start();
Console.WriteLine("Enter your name: ");
string name = Console.ReadLine();
Console.WriteLine("Enter your surname: ");
string surname = Console.ReadLine();
Console.WriteLine($"Main - {Thread.CurrentThread.ManagedThreadId}");
Console.WriteLine($"{name} {surname}");




void DownloadFile()
{
    Console.WriteLine($"Some function - {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine("Downloading started...");
    Thread.Sleep(10000);
    Console.WriteLine("Downloading finished...");
}
