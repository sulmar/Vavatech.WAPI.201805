using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WAPI.IServices;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.MockServices
{
    public class MockTarrifsService : ITarrifsService
    {
        public IList<Tarrif> GetByCustomer(string customerCode)
        {
            throw new NotImplementedException();
        }
    }
}
