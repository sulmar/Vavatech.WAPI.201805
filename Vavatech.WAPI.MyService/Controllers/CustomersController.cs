using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Vavatech.WAPI.IServices;
using Vavatech.WAPI.MockServices;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.MyService.Controllers
{
    // [Authorize]
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

        public IHttpActionResult Get()
        {
            return Ok(customersService.Get());
        }


        public IHttpActionResult Post(Customer customer)
        {
            customersService.Add(customer);

            // Created($"http://localhost:52879/api/customers/{customer.Id}", customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }
    }
}
