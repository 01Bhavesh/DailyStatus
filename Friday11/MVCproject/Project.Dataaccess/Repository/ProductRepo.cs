using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project.Models;
using Project.Dataaccess.Server;

namespace Project.Dataaccess.Repository
{
    public class ProductRepo : IProduct
    {
        private readonly ApplicationDbContext _db;
        public ProductRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void Delete(Product product)
        {
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _db.Products.Include(p => p.Category).ToListAsync();   
        }

        public async Task<Product> GetProductById(int Id)
        {
            Product? product = await _db.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if (product == null)
            {
                throw new Exception("Product is not present");
            }
            return product;
        }

        public void Update(Product product)
        {
            _db.Update(product);
            _db.SaveChanges();
        }
    }
}
