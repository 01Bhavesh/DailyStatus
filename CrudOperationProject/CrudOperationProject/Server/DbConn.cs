using CrudOperationProject.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationProject.Server
{
    public class DbConn : DbContext
    {
        public DbConn(DbContextOptions<DbConn> O) : base(O)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
