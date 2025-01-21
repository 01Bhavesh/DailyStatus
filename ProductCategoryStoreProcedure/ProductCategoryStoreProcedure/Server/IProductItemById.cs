using ProductCategoryStoreProcedure.Models;

namespace ProductCategoryStoreProcedure.Server
{
    public interface IProductItemById
    {
        public Product GetProductById(int Id);
    }
}
