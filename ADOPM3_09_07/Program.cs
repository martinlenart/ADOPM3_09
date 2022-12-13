using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ADOPM3_09_07
{
    class Program
    {
        public static Task<int> MultipleUriDownloadsAsync(IProgress<string> onProgressReporting, CancellationToken token)
        {
            //Notice I can use async in Lambda Expression
            return Task<int>.Run(async () =>
            {
                int totalDownloadCount = 0;
                for (int i = 0; i < 10 && !token.IsCancellationRequested; i++)
                {
                    string html = await new HttpClient().GetStringAsync("https://microsoft.com");
                    totalDownloadCount += html.Length;
                    onProgressReporting.Report($"Downloaded {totalDownloadCount} bytes {(i + 1) * 10}%");
                }

                return totalDownloadCount;
            }, token);
        }
        static void Main(string[] args)
        {
            //Define my progressReporter as an instance of Progress which implements IProgress
            var progressReporter = new Progress<string>(value => Console.WriteLine(value));

            //Implement cancellation
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

            //Create and run the task, but passing the progressReporter as an argument
            var t1 = MultipleUriDownloadsAsync(progressReporter, cancelTokenSource.Token);

            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            cancelTokenSource.Cancel();
            t1.Wait();
        }
    }
    //Exercise:
    //1.    Implement Cancellation in Example 10.4 CPUBoundAsync
}
