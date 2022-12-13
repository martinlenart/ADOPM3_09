using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json; //Requires nuget package System.Net.Http.Json
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using ADOPM3_09_12.Models;
using ADOPM3_09_12.Services;

namespace ADOPM3_09_12
{
    class Program
    {
        static async Task Main(string[] args)
        {
            NewsApiData news = await new NewsService().GetNewsAsync();

            Console.WriteLine($"Top headlines:");
            foreach (var item in news.Articles)
            {
                Console.WriteLine($"  {item.Title}");
            }
        }
    }
}

