//#define UseNewsApiSample  // Remove or undefine to use your own code to read live data

using System.Net;
using System.Net.Http;
using System.Net.Http.Json; //Requires nuget package System.Net.Http.Json
using System.Threading.Tasks;

using ADOPM3_09_12.Models;

namespace ADOPM3_09_12.Services
{
    public class NewsService
    {
        HttpClient httpClient;

        //REPLACE WITH YOUR API KEY AFTER TEST
        readonly string apiKey = "d318329c40734776a014f9d9513e14ae";

        public NewsService()
        {
            httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            httpClient.DefaultRequestHeaders.Add("user-agent", "News-API-csharp/0.1");
            httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }

        public async Task<NewsApiData> GetNewsAsync()
        {

            //var uri = $"https://newsapi.org/v2/top-headlines?country=se&category=sports";
            //var uri = $"https://newsapi.org/v2/top-headlines?country=se&category=business";
            var uri = $"https://newsapi.org/v2/top-headlines?country=se&category=entertainment";

            // make the http request
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await httpClient.SendAsync(httpRequest);
            response.EnsureSuccessStatusCode();

            //Convert Json to Object
            NewsApiData nd = await response.Content.ReadFromJsonAsync<NewsApiData>();

            return nd;
        }
    }
}
