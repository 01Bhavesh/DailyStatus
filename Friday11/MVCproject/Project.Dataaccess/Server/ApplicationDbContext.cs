using Microsoft.EntityFrameworkCore;
using project.Models;

namespace Project.Dataaccess.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> o) : base(o)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                 new Category { Id = 1 , Name = "Action" , DisplayOrder = 2},
                 new Category { Id = 2, Name = "Drama", DisplayOrder = 3 },
                 new Category { Id = 3, Name = "History", DisplayOrder = 1 }
            );
            modelBuilder.Entity<Product>().HasData(
                
                new Product { Id = 1,
                Title="Fortune of time",
                Author="Vinay",
                Description= "Fortune Time is a three-reel, nine-line mechanical slot game by Everi that involves searching for hidden treasures",
                ISBN="SWD98320284",
                ListPrice=99,
                Price=90,
                Price50=85,
                Price100=80
                },
                new Product
                {
                    Id = 2,
                    Title = "The Great Gatsby",
                    Author = "Deepak",
                    Description = "this novel is considered a classic and explores themes of class, gender, and tragedy.",
                    ISBN = "SWD98322344",
                    ListPrice = 120,
                    Price = 110,
                    Price50 = 105,
                    Price100 = 100
                },
                new Product
                {
                    Id = 3,
                    Title = "The Pilgrim's Progress",
                    Author = "Mayur",
                    Description = "this book is considered an English classic and tells the story of a man in search of truth.",
                    ISBN = "SWD45320284",
                    ListPrice = 150,
                    Price = 145,
                    Price50 = 140,
                    Price100 = 130
                },
                new Product
                {
                    Id = 4,
                    Title = "Robinson Crusoe",
                    Author = "Saurabh",
                    Description = "this novel is considered a complex literary confection.",
                    ISBN = "SWD9832684",
                    ListPrice = 200,
                    Price = 195,
                    Price50 = 180,
                    Price100 = 170
                }

                );
        }

    }
}
