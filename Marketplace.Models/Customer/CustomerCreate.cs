using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models.Customer
{
     public class CustomerCreate
    {
        
        public int CustomerId { get; set; }
        [Required]
        public string CustomerFirstName { get; set; }
        [Required]
        public string CustomerLastName { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerPhone { get; set; }
        [Required]
        public string CustomerStreetAddress { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zip { get; set; }
        private string _shippingInformation;
        public string ShippingInformation
        {
            get { return _shippingInformation; }
            set
            {
                _shippingInformation = $"{CustomerStreetAddress}\n" +
                                       $"{City}, {State} {Zip}";
            }
        }

    }
}
