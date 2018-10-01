using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models.Retailer
{
     public class RetailerDetails
    {
        public int RetailerId { get; set; }
        public string RetailerName { get; set; }
        public int RetailerEin { get; set; }
        public string RetailerAddress { get; set; }
        public string RetailerEmail { get; set; }
        public string RetailerPhone { get; set; }
        public Guid OwnerId { get; set; }
    }
}
