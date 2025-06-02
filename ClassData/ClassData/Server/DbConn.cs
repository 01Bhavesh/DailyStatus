using ClassData.Model;
using Microsoft.EntityFrameworkCore;

namespace ClassData.Server
{
    public class DbConn : DbContext
    {
        public DbConn(DbContextOptions<DbConn> o) : base(o)
        {
            
        }
        public DbSet<Student> students { get; set; }
    }
}
