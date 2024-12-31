using EntityFramworkCode.Models;
using EntityFramworkCode.Server;
using Microsoft.EntityFrameworkCore;

namespace EntityFramworkCode.ServiceImplementation
{
    public class ProductService : IProductService
    {
        private readonly DbProduct _dbProduct;
        public ProductService(DbProduct dbProduct)
        {
            _dbProduct = dbProduct;
        }
        public async void AddProduct(Product product)
        {
            if (_dbProduct.products.Any(p => p.productName == product.productName))
            {
                throw new Exception("Duplicate product not allowed");
            }
            _dbProduct.products.Add(product);
            Product? p = await _dbProduct.products.FindAsync(product.Id);
            p.isActive = true;

        }

        public async void DeleteProduct(int id)
        {
            Product? p = await _dbProduct.products.FindAsync(id);
            p.isActive = false;
        }

        public async Task<Product> GetProductById(int id)
        {
            Product? p = await _dbProduct.products.FindAsync(id);
            if (p == null)
            {
                throw new Exception("Product is empty..");
            }
            return p;
        }

        public async Task<List<Product>> GetProducts(int page, int pageSize) //Eager Loading
        {
            return await _dbProduct.products
                .Include(p => p.category.isActive == true)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync();
        }

        public void UpdateProduct(Product product)
        {
            _dbProduct.products.Update(product);
            _dbProduct.SaveChanges();
        }
    }
}
