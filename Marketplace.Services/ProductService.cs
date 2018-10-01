using Marketplace.Contracts;
using Marketplace.Data;
using Marketplace.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Services 
{
    public class ProductService
    {
        private readonly Guid _userId;
        private readonly int _retailerId;

        public ProductService(Guid userid)
        {
            _userId = userid;
        }

        public ProductService(Guid userId, int retailerId)
        {
            _userId = userId;
            _retailerId = retailerId;
        }
        
        public ProductDetails GetProductbyId(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == productId);
                return
                    new ProductDetails
                    {
                        OwnerId = entity.OwnerId,
                        ProductId = entity.ProductId,
                        ProductName = entity.ProductName,
                        ProductDescription = entity.ProductDescription,
                        ProductPrice = entity.ProductPrice,
                        ProductCost = entity.ProductCost,
                        ProductCategory = entity.ProductCategory,
                        ProductUpc = entity.ProductUpc,
                        ProductQuantity = entity.ProductQuantity,
                    };
            }
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product
                {
                    OwnerId = _userId,
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    ProductCategory = model.ProductCategory,
                    ProductCost = model.ProductCost,
                    ProductDescription = model.ProductDescription,
                    ProductPrice = model.ProductPrice,
                    ProductQuantity = model.ProductQuantity,
                    ProductUpc = model.ProductUpc,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ICollection<ProductListItem> GetAllProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var products =
                ctx
                    .Products
                    .Select(
                    e => new ProductListItem()
                    {
                        ProductId = e.ProductId,
                        ProductCategory = e.ProductCategory,
                        ProductDescription = e.ProductDescription,
                        ProductName = e.ProductName,
                        ProductPrice = e.ProductPrice,
                        ProductQuantity = e.ProductQuantity,
                        ProductUpc = e.ProductUpc,
                    });
                return products.ToList();
            }
        }

        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == model.ProductId && e.OwnerId == _userId);
                entity.OwnerId = model.OwnerId;
                entity.ProductId = model.ProductId;
                entity.ProductName = model.ProductName;
                entity.ProductUpc = model.ProductUpc;
                entity.ProductPrice = model.ProductPrice;
                entity.ProductCost = model.ProductCost;
                entity.ProductQuantity = model.ProductQuantity;
                entity.ProductDescription = model.ProductDescription;
                entity.ProductCategory = model.ProductCategory;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == productId && e.OwnerId == _userId);

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
