using FiltersASP_Web.IServiceImplementation;
using FiltersASP_Web.Model;

namespace FiltersASP_Web.ServiceImplementation
{
    public class ProductService : IProductService
    {
        private readonly DbProduct _db;
        public ProductService(DbProduct db)
        {
            _db = db;
        }
        public void AddProduct(Product product)
        {
            _db.products.Add(product);
            _db.SaveChanges();
        }

        public List<Product> GetProduct()
        {
            List<Product> lst = _db.products.ToList();
            return lst;
        }

        public Product? GetProductById(int? id)
        {
            Product? product = _db.products.FirstOrDefault(p => p.Id == id);
            return product;
        }
    }
}
