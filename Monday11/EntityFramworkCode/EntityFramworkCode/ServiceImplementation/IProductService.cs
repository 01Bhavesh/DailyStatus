using EntityFramworkCode.Models;

namespace EntityFramworkCode.ServiceImplementation
{
    public interface IProductService
    {
        Task<(List<Product>, int totalcount)> GetProducts(int page, int pageSize);
        Task<Product> GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
