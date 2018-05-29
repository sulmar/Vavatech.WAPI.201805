using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WAPI.IServices;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Models.SearchCriteria;
using System.Linq;

namespace Vavatech.WAPI.MockServices
{
    public class MockCustomersService : ICustomersService
    {
        private static IList<Customer> customers = new List<Customer>
        {
            new Customer("C001", "Company 1") {  Id = 1, Code = "C001", Name = "Customer 1", City = "Warszawa" },
            new Customer("C002", "Company 2") {  Id = 2, Code = "C002", Name = "Customer 2", City = "Warszawa" },

            //new Customer {  Id = 2, Code = "C002", Name = "Customer 2", City = "Warszawa" },
            //new Customer {  Id = 3, Code = "C003", Name = "Customer 3", City = "Bydgoszcz" },
            //new Customer {  Id = 4, Code = "C004", Name = "Customer 4", City = "Białystok" },
            //new Customer {  Id = 5, Code = "C005", Name = "Customer 5", City = "Białystok" },
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

        public Customer Get(string code)
        {
            return customers.SingleOrDefault(c => c.Code == code);
        }

        public IList<Customer> Get(Location location)
        {
            return customers;
        }

        public IList<Customer> Get(CustomerSearchCriteria criteria)
        {
            if (criteria.From.HasValue)
            {
                customers = customers.Where(c => c.CreateDate > criteria.From).ToList();
            }

            if (criteria.To.HasValue)
            {
                customers.Where(c => c.CreateDate <= criteria.To);
            }

            return customers;

        }

        public IList<Customer> GetByCity(string city)
        {
            return customers.Where(c => c.City == city).ToList();
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
