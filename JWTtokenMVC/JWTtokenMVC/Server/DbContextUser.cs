using JWTtokenMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTtokenMVC.Server
{
    public class DbContextUser : DbContext
    {
        public DbContextUser(DbContextOptions<DbContextUser> o) : base(o)
        {
            
        }
        public DbSet<User> users { get; set; }
    }
}
