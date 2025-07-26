using CrudOpPractice.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudOpPractice.Connection
{
    public class ConDB : DbContext
    {
        public ConDB(DbContextOptions<ConDB> o) : base(o)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
