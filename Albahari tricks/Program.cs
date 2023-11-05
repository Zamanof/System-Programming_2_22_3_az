//for (int i = 0; i < 10; i++)
//{
//    int tmp = i;
//    new Thread(() => { Console.WriteLine(tmp); }).Start();
//}

string text = "Nadir";

Thread thread1 = new Thread(() =>
{
    Console.WriteLine(text);
});
thread1.Start();
text = "Zamanov";

Thread thread2 = new Thread(() =>
{
    Console.WriteLine(text);
});
thread2.Start();