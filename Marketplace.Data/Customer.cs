using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerStreetAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string CustomerPhone { get; set; }
        public Guid OwnerId { get; set; }
    }
}
