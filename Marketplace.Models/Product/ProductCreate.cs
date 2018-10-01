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

        [Required]
        public double ProductQuantity { get; set; }

        [Required]
        public string ProductCategory { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        public Guid OwnerId { get; set; }
    }
}
