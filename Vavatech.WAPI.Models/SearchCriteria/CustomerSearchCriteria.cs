using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.WAPI.Models.SearchCriteria
{
    public abstract class PeriodSearchCriteria
    {
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }

    public class CustomerSearchCriteria : PeriodSearchCriteria
    {
        public string City { get; set; }

        public string Country { get; set; }
    }
}
