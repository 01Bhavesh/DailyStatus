using Microsoft.EntityFrameworkCore;
using WebProject.Model;

namespace WebProject
{
    public class DbCotextApp : DbContext
    {

        public DbCotextApp(DbContextOptions<DbCotextApp> o):base(o)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
