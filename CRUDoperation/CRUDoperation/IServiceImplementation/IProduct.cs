using CRUDoperation.Model;

namespace CRUDoperation.IServiceImplementation
{
    public interface IProduct
    {
        Task<IList<Product>> GetAllProduct();
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int Id);
        Task<Product> GetProductById(int? id);
    }
}
