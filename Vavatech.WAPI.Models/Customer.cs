using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.WAPI.Models
{
    public class Customer : Base
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public string City { get; set; }

        public Location Location { get; set; }

        public DateTime CreateDate { get; set; }


        public Customer(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        protected Customer()
        {

        }

    }


    public class Location : Base
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
