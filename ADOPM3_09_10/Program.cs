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
        public static async Task<string> GetWebApiLongLatAsync()
        {
            double latitude = 59.5086798659495;
            double longitude = 18.2654625932976;
            
            var language = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var apiKey = "eee86395bdce14b3d962d5956193d800";
            var uri = $"https://api.openweathermap.org/data/2.5/forecast?" + 
                $"lat={latitude}&lon={longitude}&units=metric&lang={language}&appid={apiKey}";

            var httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public static async Task<string> GetWebApiCityAsync()
        {
            var language = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var apiKey = "eee86395bdce14b3d962d5956193d800";

            var city = "Stockholm";
            var uri = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={apiKey}";

            var httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }


        static async Task Main(string[] args)
        {
            var res = await GetWebApiLongLatAsync();
            Console.WriteLine(res.Length); 
            Console.WriteLine(res);

            Console.WriteLine();
            var res2 = await GetWebApiCityAsync();
            Console.WriteLine(res2.Length); 
            Console.WriteLine(res2);

        }
    }
    //Exercise:
    //1.    Use your own API key from https://openweathermap.org/ and use connect to to api and read the Json string.
    //2.    Create a class structure that corresponds to the response. https://app.quicktype.io/ is helpful here.
    //3.    Deserialize the response Json string into the classes you have defined, using either JsonSerializer.Deserialize or 
    //      ReadFromJsonAsync. Try both and compare
    //4.    Create an event that fires when deserialization is done. Use the event to printout "New data is available"
}
