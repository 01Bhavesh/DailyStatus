using CRUDoperationPractice.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUDoperationPractice.Server
{
    public class DbData : DbContext
    {
        public DbData(DbContextOptions<DbData> o) : base(o)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
