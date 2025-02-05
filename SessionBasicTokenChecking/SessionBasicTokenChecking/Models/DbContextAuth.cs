using Microsoft.EntityFrameworkCore;
using SessionBasicTokenChecking.Models;

namespace SessionBasicTokenChecking.Models
{
    public class DbContextAuth : DbContext
    {
        public DbContextAuth(DbContextOptions<DbContextAuth> o) : base(o)
        {
            
        }

        public DbSet<User> users { get; set; }
        public DbSet<Login> Login { get; set; } = default!;
    }
}
