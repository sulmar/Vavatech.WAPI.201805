using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WAPI.IServices;
using Vavatech.WAPI.MockServices;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.Service.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomersService customersService;

        public CustomersController()
            : this(new MockCustomersService())
        {

        }

        public CustomersController(ICustomersService customersService)
        {
            this.customersService = customersService;
        }

        [HttpGet]
        public IList<Customer> Pobierz()
        {
            return customersService.Get();
        }

        [HttpGet]
        public Customer Pobierz(int id)
        {
            return customersService.Get(id);
        }


        public void Post(Customer customer)
        {
            customersService.Add(customer);
        }

        public void Delete(int id)
        {
            customersService.Remove(id);
        }
    }
}