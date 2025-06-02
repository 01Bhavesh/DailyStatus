using task_review.Model;

namespace task_review.IServiceImplementation
{
    public interface IProductService
    {
        List<Product> GetAllProduct();
        bool CreateProduct(Product product);
        Product GetProductById(int id);
        void UpdateProduct(Product product);
        void DeleteProductById(int id);
    }
}
