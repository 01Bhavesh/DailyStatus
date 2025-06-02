using FiltersASP_Web.Model;

namespace FiltersASP_Web.IServiceImplementation
{
    public interface IProductService
    {
        List<Product> GetProduct();
        void AddProduct(Product product);
        Product GetProductById(int? id);

    }
}
