using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data
{
    public class Retailer
    {
        public int RetailerId { get; set; }

        [Required]
        public string RetailerName { get; set; }

        [Required]
        public int RetailerEin { get; set; }

        [Required]
        public string RetailerAddress { get; set; }

        [Required]
        public string RetailerEmail { get; set; }

        [Required]
        public string RetailerPhone { get; set; }

        public Guid OwnerId { get; set; }
    }
}
