using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP03_Asynchronies_methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var del = new SomeDelegate(SomeMethod);
            var result = del.BeginInvoke(null, null);
            Console.WriteLine($"MainMethod thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"MainMethod isBackground: {Thread.CurrentThread.IsBackground}");
            Console.WriteLine($"MainMethod isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
            del.EndInvoke(result);
            ThreadPool.GetAvailableThreads(out int workerCount, out int complCount);
            Console.WriteLine(workerCount);
            Console.WriteLine(complCount);
        }

        delegate void SomeDelegate();
        static void SomeMethod()
        {
            Console.WriteLine($"SomeMethod start...");
            Console.WriteLine($"SomeMethod thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"SomeMethod isBackground: {Thread.CurrentThread.IsBackground}");
            Console.WriteLine($"SomeMethod isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
            Thread.Sleep(100);
            Console.WriteLine($"SomeMethod end...");
            Console.WriteLine();

        }
        
    }
    
}
