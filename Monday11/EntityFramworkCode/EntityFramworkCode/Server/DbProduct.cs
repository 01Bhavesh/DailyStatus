using EntityFramworkCode.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramworkCode.Server
{
    public class DbProduct : DbContext
    {
        public DbProduct(DbContextOptions<DbProduct> o) : base(o)
        {
            
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
