using System;
using System.Net;

namespace ADOPM3_09_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri info = new Uri("http://www.domain.com:80/info/");
            Uri page = new Uri("http://www.domain.com/info/page.html");

            Console.WriteLine(Uri.CheckSchemeName(info.Scheme));     // true
            Console.WriteLine(Uri.CheckHostName(info.Host));     // DNS
            Console.WriteLine(info.Host);     // www.domain.com
            Console.WriteLine(info.Port);     // 80

            Console.WriteLine();
            Console.WriteLine(info.IsBaseOf(page));         // True

            Console.WriteLine();
            Uri relative = info.MakeRelativeUri(page);
            Console.WriteLine(relative.IsAbsoluteUri);       // False
            Console.WriteLine(relative.ToString());          // page.html        

            Console.WriteLine();
            IPAddress a1 = new IPAddress(new byte[] { 101, 102, 103, 104 });
            IPAddress a2 = IPAddress.Parse("101.102.103.104");
            Console.WriteLine(a1.Equals(a2));                     // True
            Console.WriteLine(a1.AddressFamily);                   // InterNetwork

            IPAddress a3 = IPAddress.Parse ("[3EA0:FFFF:198A:E4A3:4FF2:54fA:41BC:8D31]");
            Console.WriteLine(a3.AddressFamily);   // InterNetworkV6

            Console.WriteLine();
            Console.WriteLine("Address with port:");
            IPAddress a = IPAddress.Parse("101.102.103.104");
            IPEndPoint ep = new IPEndPoint(a, 222);           // Port 222
            Console.WriteLine(ep.ToString());                 // 101.102.103.104:222
        }
    }
}
