﻿using Marketplace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models.Customer
{
    public class CustomerDetails
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerStreetAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string CustomerPhone { get; set; }
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
        public Guid OwnerId { get; set; }
    }
}