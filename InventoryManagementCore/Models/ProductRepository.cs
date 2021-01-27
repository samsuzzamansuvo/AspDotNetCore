using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryDbContext _db;

        public ProductRepository(InventoryDbContext db)
        {
            _db = db;
        }


        public Product GetProductById(int id)
        {
            Product product = _db.Products.FirstOrDefault(p => p.ProductId == id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            var data = _db.Products.Select(p => new Product
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price,
                UrlImage = p.UrlImage,
                CategoryId = p.CategoryId,
                Category = _db.Categories.Where(c => c.CategoryId == p.CategoryId).FirstOrDefault()
            }).ToList();
            return data;
        }

        public Product AddProduct(Product objProduct)
        {
            _db.Products.Add(objProduct);
            _db.SaveChanges();
            return objProduct;
        }

        public Product UpdateProduct(Product changeProduct)
        {
            var product = _db.Products.Attach(changeProduct);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return changeProduct;
        }

        public void DeleteProducr(int id)
        {
            var data = GetProductById(id);
            if (data!=null)
            {
                _db.Remove(data);
            }
            _db.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            var data=_db.Categories.ToList();
            return data;
        }

    }
}
