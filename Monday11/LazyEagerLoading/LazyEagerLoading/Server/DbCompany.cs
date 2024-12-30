using LazyEagerLoading.Models;
using Microsoft.EntityFrameworkCore;

namespace LazyEagerLoading.Server
{
    public class DbCompany : DbContext
    {
        public DbCompany(DbContextOptions<DbCompany> o) : base(o)
        {
            
        }
        public DbSet<Company> company { get; set; }
        public DbSet<Employee> employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().HasData(
                new Company{
                    Id = 1,
                    CompanyName = "TCS",
            },
                new Company
                {
                    Id = 2,
                    CompanyName = "Nimap",
                },
                new Company
                {
                    Id = 3,
                    CompanyName = "Fyntune",
                },
                new Company
                {
                    Id = 4,
                    CompanyName = "IDZ Digital",
                });
            modelBuilder.Entity<Employee>().HasData(

                new Employee { 
                Id = 1,
                CompanyId = 1,
                EmpName = "Swapnil",
                },

                new Employee
                {
                    Id = 2,
                    CompanyId = 1,
                    EmpName = "Mayur",
                },

                new Employee
                {
                    Id = 3,
                    CompanyId = 1,
                    EmpName = "Omkar",
                },

                new Employee
                {
                    Id = 4,
                    CompanyId = 2,
                    EmpName = "Omkar",
                },


                new Employee
                {
                    Id = 5,
                    CompanyId = 2,
                    EmpName = "Bhavesh",
                },

                new Employee
                {
                    Id = 6,
                    CompanyId = 2,
                    EmpName = "Jitesh Sir",
                },

                new Employee
                {
                    Id = 7,
                    CompanyId = 3,
                    EmpName = "Deepak",
                },

                new Employee
                {
                    Id = 8,
                    CompanyId = 3,
                    EmpName = "Vinay",
                },
                new Employee
                {
                    Id = 9,
                    CompanyId = 3,
                    EmpName = "Rahul",
                },

                new Employee
                {
                    Id = 10,
                    CompanyId = 4,
                    EmpName = "Yash",
                },
                new Employee
                {
                    Id = 11,
                    CompanyId = 4,
                    EmpName = "Rohit",
                },

                new Employee
                {
                    Id = 12,
                    CompanyId = 4,
                    EmpName = "Virat",
                }
                );
        }
    }
}
