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
        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProducts(int page, int pageSize)
        {
            return await _dbProduct.products
                .Include(p => p.category)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
