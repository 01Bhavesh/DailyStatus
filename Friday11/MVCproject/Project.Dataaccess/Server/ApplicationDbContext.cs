using Microsoft.EntityFrameworkCore;
using project.Models;

namespace Project.Dataaccess.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> o) : base(o)
        {
            
        }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                 new Category { Id = 1 , Name = "Action" , DisplayOrder = 2},
                 new Category { Id = 2, Name = "Drama", DisplayOrder = 3 },
                 new Category { Id = 3, Name = "History", DisplayOrder = 1 }
            );
        }
    }
}
