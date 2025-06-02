using Microsoft.EntityFrameworkCore;
using task_review.Model;

namespace task_review.Server
{
    public class DbProduct : DbContext
    {
        public DbProduct(DbContextOptions<DbProduct> _con) : base(_con)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
