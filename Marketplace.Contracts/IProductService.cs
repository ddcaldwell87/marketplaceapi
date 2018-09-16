using Marketplace.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Contracts
{
    public interface IProductService
    {
        ProductDetails GetProductbyId(int productId);
        bool CreateProduct(ProductCreate model);
        ICollection<ProductListItem> GetAllProducts();
        bool UpdateProduct(ProductEdit model);
        bool DeleteNote(int productId);
    }
}
