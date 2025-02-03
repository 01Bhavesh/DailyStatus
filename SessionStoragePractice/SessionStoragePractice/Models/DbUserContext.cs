using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SessionStoragePractice.Models;

namespace SessionStoragePractice.Models
{
    public class DbUserContext : DbContext
    {
        public DbUserContext(DbContextOptions<DbUserContext> o) : base(o)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}