using CRUDoperation.IServiceImplementation;
using CRUDoperation.Model;
using CRUDoperation.Server;
using Microsoft.EntityFrameworkCore;

namespace CRUDoperation.ServiceImplementation
{
    public class ProductService : IProduct
    {
        private readonly DbProduct _db;
        public ProductService(DbProduct db)
        {
            _db = db;
        }
        public async Task<bool> CreateProduct(Product product)
        {
            if (await _db.Products.AnyAsync(p => p.ProductName == product.ProductName))
            {
                return false;
            }
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            Product? product = await _db.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if (product == null)
            {
                return false;
            }
            product.IsActive = false;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IList<Product>> GetAllProduct()
        {
            //var products = _db.Products.Where(p => p.IsActive); //IQueryable
            //var products = (IEnumerable<Product>)_db.Products.Where(p => p.IsActive); //IEnumerable
            var products = await _db.Products.Where(p => p.IsActive).ToListAsync(); // IList
            return products;
        }

        public async Task<Product?> GetProductById(int? Id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == Id);
            return product;

        }

        public async Task<bool> UpdateProduct(Product product)
        {
            Product? prod = await _db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (prod == null)
            {
                return false;
            }
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
