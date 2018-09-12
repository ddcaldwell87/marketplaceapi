using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data
{
    public class Retailer
    {
        public int RetailerId { get; set; }
        public string RetailerName { get; set; }
        // Employer Identification Number
        public int RetailerEin { get; set; }
        public string RetailerAddress { get; set; }
        public string RetailerEmail { get; set; }
        public string RetailerPhone { get; set; }
        //TODO: add retailer image property
        public byte[] Image { get; set; }
        public Guid OwnerId { get; set; }
    }
}
