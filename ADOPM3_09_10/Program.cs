using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ADOPM3_09_10
{
    class Program
    {
        public static async Task<string> GetWebApiLongLatAsync()
        {
            double latitude = 59.5086798659495;
            double longitude = 18.2654625932976;

            var language = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            //REPLACE WITH YOUR API KEY AFTER TEST
            var apiKey = "eee86395bdce14b3d962d5956193d800";

            var uri = $"https://api.openweathermap.org/data/2.5/forecast?" +
                $"lat={latitude}&lon={longitude}&appid={apiKey}";

            var httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(uri);
            //throw new Exception("Error handling test");
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
            //throw new Exception("Error handling test");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }


        static async Task Main(string[] args)
        {
            Console.WriteLine("\nAsync programming");
            string[] result = new string[4];
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    if (i % 2 == 0)
                        result[i] = await GetWebApiLongLatAsync();
                    else
                        result[i] = await GetWebApiCityAsync();
                }
                catch (Exception ex)
                {
                    result[i] = ex.Message;
                }
            }

            foreach (string s in result)
            {
                Console.WriteLine($"\n{s}");
            }


            Console.WriteLine("\n\nParallell programming");
            Task<string>[] tasks = new Task<string>[4];
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i % 2 == 0)
                        tasks[i] = GetWebApiLongLatAsync();
                    else
                        tasks[i] = GetWebApiCityAsync();
                }

                Task.WaitAll(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex.Message}");
            }
            finally
            {
                foreach (var task in tasks)
                {
                    if (task.IsCompletedSuccessfully)
                    {
                        Console.WriteLine($"\n{task.Result}");
                    }
                }
            }

        }
    }
    //Exercise:
    //1.    Use your own API key from https://openweathermap.org/ and use connect to to api and read the Json string.
    //2.    Create a class structure that corresponds to the response. https://app.quicktype.io/ is helpful here.
    //3.    Deserialize the response Json string into the classes you have defined, using either JsonSerializer.Deserialize or 
    //      ReadFromJsonAsync. Try both and compare
    //4.    Create an event that fires when deserialization is done. Use the event to printout "New data is available"
}
