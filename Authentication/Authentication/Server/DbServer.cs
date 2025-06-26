using Authentication.Model;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Server
{
    public class DbServer:DbContext
    {
        public DbServer(DbContextOptions<DbServer> o):base(o)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
