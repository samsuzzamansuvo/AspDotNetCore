using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        Product AddProduct(Product objProduct);
        Product UpdateProduct(Product changeProduct);
        void DeleteProducr(int id);
        IEnumerable<Category> GetCategories();
    }
}
