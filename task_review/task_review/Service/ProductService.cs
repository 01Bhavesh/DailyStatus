using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using task_review.IServiceImplementation;
using task_review.Model;
using task_review.Server;

namespace task_review.Service
{
    public class ProductService : IProductService
    {
        private readonly DbProduct _db;
        public ProductService(DbProduct db)
        {
            _db = db;
        }

        public bool CreateProduct(Product product)
        {
            Product? pro = _db.Products.FirstOrDefault(p => p.ProductName == product.ProductName);
            if (pro != null)
            {
                return false;
            }
            _db.Products.Add(product);
            _db.SaveChanges();
            return true;
        }

        public void DeleteProductById(int id)
        {
            Product pro = GetProductById(id);
            pro.IsActive = false;
            _db.SaveChanges();
        }

        public List<Product> GetAllProduct()
        {
            //var products = (IEnumerable<Product>)(_db.Products.Where(p => p.IsActive).ToList()); //IEnumerable
            //var products = _db.Products.Where(p => p.IsActive);//IQueryable
            var products = _db.Products.Where(p => p.IsActive).ToList();//IList
            return products;
        }

        public Product GetProductById(int id)
        {
            Product? pro = _db.Products.FirstOrDefault(p => p.Id == id);
            return pro;
        }

        public void UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }
    }
}
