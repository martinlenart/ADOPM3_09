using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ADOPM3_09_09
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //HttpClient is typcially instantiated only created once and used in multiple requests
            //using declaration cares that resources are released when out of scope
            using var client = new HttpClient();
            
            var t2 = client.GetStringAsync("http://www.microsoft.com");
            var t3 = client.GetStringAsync("http://www.apple.com");

            var s2 = await t2;
            await t3;

            //Console.WriteLine(t2.Result);
            Console.WriteLine(s2.Length);
            Console.WriteLine(t3.Result.Length);
            
                
            var response = await client.GetAsync("http://www.microsoft.com");
            //HttpResponseMessage response = response.Result;
            response.EnsureSuccessStatusCode();

            var res = await response.Content.ReadAsStringAsync();
            Console.WriteLine(res.Length);
        }
    }
}
