using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Models.SearchCriteria;

namespace Vavatech.WAPI.IServices
{
    public interface ICustomersService
    {
        IList<Customer> Get();
        IList<Customer> GetByCity(string city);
        IList<Customer> Get(Location location);

        IList<Customer> Get(CustomerSearchCriteria criteria);

        Customer Get(int id);

        Customer Get(string code);

        void Add(Customer customer);

        void Update(Customer customer);

        void Remove(int id);
    }
}
