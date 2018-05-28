using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.IServices
{
    public interface ICustomersService
    {
        IList<Customer> Get();

        Customer Get(int id);

        void Add(Customer customer);

        void Update(Customer customer);

        void Remove(int id);
    }
}
