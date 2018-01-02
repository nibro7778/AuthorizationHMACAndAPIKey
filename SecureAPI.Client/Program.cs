using SecureAPI.Client.RequestModel;
using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace SecureAPI.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {

            Console.WriteLine("Calling the back-end API");

            string apiBaseAddress = "http://localhost:59373/";

            CustomDelegatingHandler customDelegatingHandler = new CustomDelegatingHandler();

            HttpClient client = HttpClientFactory.Create(customDelegatingHandler);

            var customer = new Customer { CustomerId = 1, CustomerName="Niraj", City = "Sydney" };

            HttpResponseMessage response1 = await client.GetAsync(apiBaseAddress + "api/v1/Customers/GetCustomer");

            HttpResponseMessage response = await client.PostAsJsonAsync(apiBaseAddress + "api/v1/Customers/PostCustomer", customer);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
                Console.WriteLine("HTTP Status: {0}, Reason {1}. Press ENTER to exit", response.StatusCode, response.ReasonPhrase);
            }
            else
            {
                Console.WriteLine("Failed to call the API. HTTP Status: {0}, Reason {1}", response.StatusCode, response.ReasonPhrase);
            }

            Console.ReadLine();
        }
    }
}
