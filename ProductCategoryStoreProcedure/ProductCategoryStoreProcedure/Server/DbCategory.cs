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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User> ().HasData(
                 new User { Id = 1, UserName = "deepak", Password="1234"},
                 new User {Id = 2, UserName = "bhavesh", Password = "1212" },
                 new User { Id = 3, UserName = "vinay", Password = "3434" },
                 new User { Id = 4, UserName = "mayur", Password = "2345" }
                );
        }
    }

}
