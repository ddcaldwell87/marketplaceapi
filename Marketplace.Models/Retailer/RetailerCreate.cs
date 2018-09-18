using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models.Retailer
{
     public class RetailerCreate
    {
        public int RetailerId { get; set; }
        [Required]
        public string RetailerName { get; set; }
        // Employer Identification Number
        [Required]
        public int RetailerEin { get; set; }
        [Required]
        public string RetailerAddress { get; set; }
        [Required]
        public string RetailerEmail { get; set; }
        [Required]
        public string RetailerPhone { get; set; }

        public string Image { get; set; }
    }
}
