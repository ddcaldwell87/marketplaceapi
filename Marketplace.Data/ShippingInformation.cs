using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data
{
    public class ShippingInformation
    {
        public string CustomerStreetAddress { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }
    }
}