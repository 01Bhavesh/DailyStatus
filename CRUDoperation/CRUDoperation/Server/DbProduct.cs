using CRUDoperation.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUDoperation.Server
{
    public class DbProduct : DbContext
    {
        public DbProduct(DbContextOptions<DbProduct> o) : base(o)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
