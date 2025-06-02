using Microsoft.EntityFrameworkCore;

namespace FiltersASP_Web.Model
{
    public class DbProduct: DbContext
    {
        public DbProduct(DbContextOptions<DbProduct> o) : base(o)
        {
            
        }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1 , firstName = "Vinay" , Lastname = "Indulker"},
                new Product { Id = 2, firstName = "Deepak", Lastname = "Vyadande" }
                );
        }
    }
}
