using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Vavatech.WAPI.IServices;
using Vavatech.WAPI.MockServices;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Models.SearchCriteria;

namespace Vavatech.WAPI.Service.Controllers
{
    [RoutePrefix("api/customers")]
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
        public IHttpActionResult GetByCity(string city)
        {
            var customers = this.customersService.GetByCity(city);

            return Ok(customers);
        }

        [HttpGet]
        public IHttpActionResult GetByCityAndCountry(string city, string country)
        {
            var customers = this.customersService.GetByCity(city);

            return Ok(customers);
        }

        [HttpGet]
        [Route(Order = 1)]
        public IHttpActionResult Get([FromUri] Location location)
        {
            var customers = customersService.Get(location);

            return Ok(customers);
        }
        
        [HttpGet]
        public IHttpActionResult Get([FromUri] CustomerSearchCriteria criteria)
        {
            var customers = customersService.Get(criteria);

            return Ok(customers);
        }


        [HttpGet]
        [Route("{code:regex(^C[0-9]{3}$)}")]
        public IHttpActionResult Get(string code)
        {
            var customer = customersService.Get(code);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet]
        [Route(Order = 0)]
        public IHttpActionResult Pobierz()
        {
            var customers = customersService.Get();

            return Ok(customers);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Pobierz(int id)
        {
            var customer = customersService.Get(id);

            if (customer == null)
            {
                return NotFound();

            }

            return Ok(customer);
        }


     



        public IHttpActionResult Post(Customer customer)
        {
            customersService.Add(customer);

            // Created($"http://localhost:52879/api/customers/{customer.Id}", customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                customersService.Remove(id);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(KeyNotFoundException e)
            {
                throw e;

                // return NotFound();
            }
        }
    }
}