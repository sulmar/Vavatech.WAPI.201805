using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WAPI.ConsoleClient.Models;

namespace Vavatech.WAPI.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Task.Run(() => AddCustomerTest());

            Task.Run(() => GetCustomersTest());

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

        }


        static async Task AddCustomerTest()
        {
            var customer = new Customer
            {
                City = "Warszawa",
                Code = "C004",
                CreateDate = DateTime.Now,
                Name = "Company 4"
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000");

                var response = await client.PostAsJsonAsync("api/customers", customer);

                var newCustomer = await response.Content.ReadAsAsync<Customer>();

                if (customer == newCustomer)
                {

                }

            }
        }

        static async Task GetCustomersTest()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000");

               // client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

                var response = await client.GetAsync("/api/customers");

              //  var content = await response.Content.ReadAsStringAsync();

                // Install-Package Microsoft.AspNet.WebApi.Client
                var customers = await response.Content.ReadAsAsync<IList<Customer>>();


            }

        }
    }
}
