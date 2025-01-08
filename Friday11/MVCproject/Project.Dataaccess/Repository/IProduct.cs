using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.Models;

namespace Project.Dataaccess.Repository
{
    public interface IProduct
    {
        public Task<List<Product>> GetAllProduct();
        public Task<Product> GetProductById(int Id);
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(Product product);
    }
}
