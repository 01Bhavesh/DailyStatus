using Microsoft.EntityFrameworkCore;
using NewCRUD.Model;

namespace NewCRUD.Server
{
    public class DBStudent : DbContext
    {
        public DBStudent(DbContextOptions<DBStudent> o) : base(o)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
