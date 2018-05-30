using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.IServices
{
    public interface ITarrifsService
    {
        IList<Tarrif> GetByCustomer(string customerCode);
    }
}
