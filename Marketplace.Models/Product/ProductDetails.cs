﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models.Product
{
    public class ProductDetails
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductUpc { get; set; }

        public double ProductPrice { get; set; }

        public double ProductCost { get; set; }

        public double ProductQuantity { get; set; }

        public string ProductCategory { get; set; }

        public string ProductDescription { get; set; }

        public Guid OwnerId { get; set; }
    }
}
