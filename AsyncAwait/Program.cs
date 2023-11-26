// Thread -> ThreadPool -> TPL -> syntax sugar + love = async await

Console.WriteLine($"Main method start in thread {Thread.CurrentThread.ManagedThreadId}");
//SomeMethod();
SomeAsyncMethod();

Console.ReadKey();

//void SomeMethod()
//{
//    Console.WriteLine($"Some method start in thread {Thread.CurrentThread.ManagedThreadId}");
//    Task.Run(() =>
//    {
//        Console.WriteLine($"Some method task start in thread {Thread.CurrentThread.ManagedThreadId}");
//        Thread.Sleep( 1000 );
//        Console.WriteLine($"Some method task end in thread {Thread.CurrentThread.ManagedThreadId}");
//    });
//    Console.WriteLine($"Some method end in thread {Thread.CurrentThread.ManagedThreadId}");
//}


async void SomeAsyncMethod()
{
    Console.WriteLine($"Some method start in thread {Thread.CurrentThread.ManagedThreadId}");
    await Task.Run(() =>
    {
        Console.WriteLine($"Some method task start in thread {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
        Console.WriteLine($"Some method task end in thread {Thread.CurrentThread.ManagedThreadId}");
    });
    Console.WriteLine($"Some method end in thread {Thread.CurrentThread.ManagedThreadId}");
}

