using System.Net;
// Parallel
// PLINQ


namespace AsyncMain
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World!");
        //    string url = @"https://turbo.az/";
        //    WebClient webClient = new();
        //    //Console.WriteLine(webClient.DownloadString(url));
        //    Console.WriteLine(Text().Result);
        //    Console.WriteLine("End");
        //}

        static async Task Main(string[] args)
        {
            List<string> list = new List<string>();
            string url = @"https://turbo.az/";
            WebClient webClient = new();
            Console.WriteLine(await webClient.DownloadStringTaskAsync(url));
        }
        static async Task<string> Text()
        {
            string url = @"https://turbo.az/";
            WebClient webClient = new();
            var text = await webClient.DownloadStringTaskAsync(url);
            return text;
        }
    }
}