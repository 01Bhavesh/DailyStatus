using Microsoft.EntityFrameworkCore;
using MVCproject.Models;

namespace MVCproject.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> o) : base(o)
        {
            
        }
        public DbSet<Category> categories { get; set; }
    }
}
