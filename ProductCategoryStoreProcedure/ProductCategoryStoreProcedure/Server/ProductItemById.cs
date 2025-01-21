using Microsoft.EntityFrameworkCore;
using ProductCategoryStoreProcedure.Models;

namespace ProductCategoryStoreProcedure.Server
{
    public class ProductItemById : IProductItemById
    {
        private readonly DbCategory _db;
        public ProductItemById(DbCategory db)
        {
            _db = db;
        }
        public Product? GetProductById(int Id)
        {
            return _db.Products
                .FromSqlRaw<Product>("GetProductById {0}", Id)
                .ToList()
                .FirstOrDefault();
        }

    }
}
