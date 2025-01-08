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
            product.isActive = true;
            _dbProduct.products.Add(product);
            _dbProduct.SaveChanges();

        }

        public async void DeleteProduct(int id)
        {
            var p = await _dbProduct.products.FirstOrDefaultAsync(p => p.Id == id);
            p.isActive = false;
            _dbProduct.SaveChanges();
        }

        public async Task<Product> GetProductById(int id)
        {
            var p = await _dbProduct.products
                .Include(p => p.category)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (p == null)
            {
                throw new Exception("Product is empty..");
            }
            return p;
        }

        public async Task<(List<Product> , int totalcount)> GetProducts(int page, int pageSize) //Eager Loading
        {
            int totalcount = _dbProduct.products.Count();

            //var product = _dbProduct.products.FirstOrDefault(p => p.Id == 1);

            return (await _dbProduct.products           
                //.Where(p => p.isActive == true)
                .Include(p => p.category)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync() , totalcount);// while using include method first it will
                                                            // include all data then check condition on
                                                            // product, if product isactive or not.
        }

        public void UpdateProduct(Product product)
        {
            _dbProduct.products.Update(product);
            _dbProduct.SaveChanges();
        }
    }
}
