using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json; //Requires nuget package System.Net.Http.Json
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;

namespace ADOPM3_09_10
{
    class Program
    {
        public static async Task<string> GetWebApiAsync()
        {
            double latitude = 59.5086798659495;
            double longitude = 18.2654625932976;
            
            var language = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var apiKey = "693e91ef5abc527f4b1fb99bf9c0817e";
            var uri = $"https://api.openweathermap.org/data/2.5/forecast?" + 
                $"lat={latitude}&lon={longitude}&units=metric&lang={language}&appid={apiKey}";

            var httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        static void Main(string[] args)
        {
            var t1 = GetWebApiAsync();
            Console.WriteLine(t1.Result.Length); //15556 with my Api key
            Console.WriteLine();
            Console.WriteLine(t1.Result);
        }
    }
    //Exercise:
    //1.    Use your own API key from https://openweathermap.org/ and use connect to to api and read the Json string.
    //2.    Create a class structure that corresponds to the response. https://app.quicktype.io/ is helpful here.
    //3.    Deserialize the response Json string into the classes you have defined, using either JsonSerializer.Deserialize or 
    //      ReadFromJsonAsync. Try both and compare
    //4.    Create an event that fires when deserialization is done. Use the event to printout "New data is available"
}
