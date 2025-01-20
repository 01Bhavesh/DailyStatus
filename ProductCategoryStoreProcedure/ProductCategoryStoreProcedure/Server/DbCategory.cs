using Microsoft.EntityFrameworkCore;
using ProductCategoryStoreProcedure.Models;

namespace ProductCategoryStoreProcedure.Server
{
    public class DbCategory : DbContext
    {
        public DbCategory(DbContextOptions<DbCategory> o) : base(o)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

}
