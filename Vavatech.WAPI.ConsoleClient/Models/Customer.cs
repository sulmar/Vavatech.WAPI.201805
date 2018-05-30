using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.WAPI.ConsoleClient.Models
{
  
    public class Customer
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string City { get; set; }
        public object Location { get; set; }
        public DateTime CreateDate { get; set; }

    }

}
