using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ADOPM3_09_08
{
    class Program
    {
        static async Task DownloadPageAsync(string fname)
        {
            WebRequest request = WebRequest.Create("http://www.microsoft.com");
            request.Proxy = null;
            
            using (WebResponse response = await request.GetResponseAsync())
            using (Stream s = response.GetResponseStream())
            using (FileStream fs = File.Create(fname))
                await s.CopyToAsync(fs);
        }
        static void Main(string[] args)
        {
            var t1 =  DownloadPageAsync(fname("Example10_08.html"));
            t1.Wait();

            static string fname(string name)
            {
                var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                documentPath = Path.Combine(documentPath, "AOOP2", "Examples");
                if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
                return Path.Combine(documentPath, name);
            }
        }
    }
}
