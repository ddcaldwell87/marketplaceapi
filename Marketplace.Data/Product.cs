using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductUpc { get; set; }
        public double ProductPrice { get; set; }
        public double ProductCost { get; set; }
        public double ProductProfit { get; set; }
        public double ProductQuantity { get; set; }
        public bool OnSale { get; set; }
        public string ProductCategory { get; set; }
        public string ProductDescription { get; set; }
        //TODO: add product image property
        public int RetailerId { get; set; }
        public Guid OwnerId { get; set; }
        public byte[] Image { get; set; }
    }
}
