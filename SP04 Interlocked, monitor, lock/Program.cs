// Critical Section -  thread-lerin eyni resursu (Yaddash sahesini) istifade etmesi

#region Interlocked
//Thread[] threads = new Thread[5];

//for (int i = 0; i < 5; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            //Counter.Count++;
//            Interlocked.Increment(ref Counter.Count);
//            if (Counter.Count % 2 != 0)
//            {
//                Interlocked.Increment(ref Counter.OddCount);
//            }
//        }
//    });
//}

//for (int i = 0; i < 5; i++)
//{
//    threads[i].Start();
//}
//for (int i = 0; i < 5; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine(Counter.Count);
//Console.WriteLine(Counter.OddCount);
#endregion


// monitor - block mechanism, lock - syntax sugar

#region monitor
//Thread[] threads = new Thread[5];

//object obj = new object();

//for (int i = 0; i < 5; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            Monitor.Enter(obj);
//            try
//            {
//                Counter.Count++;
//                if (Counter.Count % 2 != 0)
//                {
//                    Counter.OddCount++;
//                }

//            }
//            finally
//            {
//                Monitor.Exit(obj);
//            }

//        }
//    });
//}

//for (int i = 0; i < 5; i++)
//{
//    threads[i].Start();
//}
//for (int i = 0; i < 5; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine(Counter.Count);
//Console.WriteLine(Counter.OddCount);
#endregion


Thread[] threads = new Thread[5];

object obj = new object();

for (int i = 0; i < 5; i++)
{
    threads[i] = new Thread(() =>
    {
        for (int j = 0; j < 1000000; j++)
        {
           
            lock (obj)
            {
                Counter.Count++;
                if (Counter.Count % 2 != 0)
                {
                    Counter.OddCount++;
                }
            }             
        }
    });
}

for (int i = 0; i < 5; i++)
{
    threads[i].Start();
}
for (int i = 0; i < 5; i++)
{
    threads[i].Join();
}

Console.WriteLine(Counter.Count);
Console.WriteLine(Counter.OddCount);
class Counter
{
    public static int Count = 0;
    public static int OddCount = 0;
}
