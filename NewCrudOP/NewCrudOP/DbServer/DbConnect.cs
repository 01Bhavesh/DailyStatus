using Microsoft.EntityFrameworkCore;
using NewCrudOP.Model;

namespace NewCrudOP.DbServer
{
    public class DbConnect : DbContext
    {
        public DbConnect(DbContextOptions<DbConnect> o) : base(o) 
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
