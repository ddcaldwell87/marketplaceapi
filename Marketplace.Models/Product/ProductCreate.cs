using Marketplace.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models.Product
{
    public class ProductCreate
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int ProductUpc { get; set; }

        [Required]
        public double ProductPrice { get; set; }

        [Required]
        public double ProductCost { get; set; }

        public double ProductProfit { get; set; }

        [Required]
        public double ProductQuantity { get; set; }

        public bool ProductOnSale { get; set; }

        [Required]
        public string ProductCategory { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        public int RetailerId { get; set; }

        public Guid OwnerId { get; set; }

        public string ProductImage { get; set; }
    }
}
