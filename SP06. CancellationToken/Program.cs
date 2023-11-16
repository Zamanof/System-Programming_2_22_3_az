#region Interrupt
//Thread thread = new Thread(Download);

//thread.Start();

//var key = Console.ReadKey();
//if (key.Key == ConsoleKey.Enter)
//{
//    Console.WriteLine("Downloading process cancel...");
//    thread.Interrupt();
//}


//void Download()
//{
//    Console.WriteLine("Downloading start...");
//    Thread.Sleep(1000);
//	for (int i = 0; i < 100; i++)
//	{
//        Console.WriteLine($"{i} %");
//        Thread.Sleep(100);
//        Console.Clear();
//    }
//    Console.WriteLine("Downloading end...");
//}
#endregion

#region CancellationToken with return
//using (CancellationTokenSource cts = new())
//{
//    CancellationToken token = cts.Token;
//    ThreadPool.QueueUserWorkItem(o =>
//    {
//        Download(token);
//    });
//    while (true)
//    {
//        var key = Console.ReadKey();
//        if (key.Key == ConsoleKey.Enter)
//        {
//            cts.Cancel();
//            Console.WriteLine("Download procces cancel...");
//            Thread.Sleep(1000);
//            return;
//        }
//        Console.Write(key.KeyChar);

//    };
//}



//void Download(CancellationToken token)
//{
//    Console.WriteLine("Downloading start...");
//    Thread.Sleep(1000);
//    for (int i = 0; i < 100; i++)
//    {
//        if (token.IsCancellationRequested)
//        {
//            return;
//        }
//        Console.WriteLine($"{i} %");
//        Thread.Sleep(100);
//        //Console.Clear();
//    }
//    Console.WriteLine("Downloading end...");
//}
#endregion

#region CancellationToken with exception
//using (CancellationTokenSource cts = new())
//{
//    CancellationToken token = cts.Token;

//    ThreadPool.QueueUserWorkItem(o =>
//    {
//        try
//        {
//            Download(token);
//        }
//        catch (OperationCanceledException ex)
//        {
//            Console.WriteLine(ex.Message);
//            Console.WriteLine("Download procces cancel...");
//        }

//    });
//    while (true)
//    {
//        var key = Console.ReadKey();
//        if (key.Key == ConsoleKey.Enter)
//        {
//            cts.Cancel();
//            Thread.Sleep(1000);
//            return;
//        }
//        Console.Write(key.KeyChar);

//    };
//}

//void Download(CancellationToken token)
//{
//    Console.WriteLine("Downloading start...");
//    Thread.Sleep(1000);
//    for (int i = 0; i < 100; i++)
//    {        
//        token.ThrowIfCancellationRequested();
//        Console.WriteLine($"{i} %");
//        Thread.Sleep(100);
//        //Console.Clear();
//    }
//    Console.WriteLine("Downloading end...");
//}
#endregion




