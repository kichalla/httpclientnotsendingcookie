using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SendRequestsAsync().Wait();
        }

        private static async Task SendRequestsAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.Timeout = TimeSpan.FromSeconds(5);

            Console.WriteLine("Making a request to get the antiforgery cookie from server");
            var response = await client.GetAsync("getdata");
            Console.WriteLine("Response headers: " + Environment.NewLine + response.ToString());


            Console.WriteLine("Posting a request to the server");
            response = await client.PostAsync("postdata", new StringContent("asdfasdf"));
            Console.WriteLine("Response headers: " + Environment.NewLine + response.ToString());
            Console.WriteLine("Response content:");
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
