using EntityFramworkCode.Models;
using Microsoft.EntityFrameworkCore;
using EntityFramworkCode.Models.DTO;

namespace EntityFramworkCode.Server
{
    public class DbProduct : DbContext
    {
        public DbProduct(DbContextOptions<DbProduct> o) : base(o)
        {
            
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<LoginUser> LoginUser { get; set; } 
    }
}
