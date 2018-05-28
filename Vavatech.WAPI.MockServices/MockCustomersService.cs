using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WAPI.IServices;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.MockServices
{
    public class MockCustomersService : ICustomersService
    {
        private static IList<Customer> customers = new List<Customer>
        {
            new Customer {  Id = 1, Name = "Customer 1", City = "Warszawa" },
            new Customer {  Id = 2, Name = "Customer 2", City = "Warszawa" },
            new Customer {  Id = 3, Name = "Customer 3", City = "Bydgoszcz" },
            new Customer {  Id = 4, Name = "Customer 4", City = "Białystok" },
            new Customer {  Id = 5, Name = "Customer 5", City = "Białystok" },
        };

        public void Add(Customer customer)
        {
            int id = customers.Max(c => c.Id);

            customer.Id = ++id;

            customers.Add(customer);
        }

        public IList<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            return customers.SingleOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            var customer = Get(id);

            if (customer == null)
            {
                throw new KeyNotFoundException();                
            }

            customer.IsDeleted = true;

        }

        public void Update(Customer customer)
        {
            var existingCustomer = Get(customer.Id);

            if (existingCustomer == null)
            {
                throw new KeyNotFoundException();
            }
            //            existingCustomer.Name = customer.Name;
            existingCustomer = customer;

        }
    }
}
