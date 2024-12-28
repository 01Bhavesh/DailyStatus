using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Program
    {
        public class Video
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime ReleaseDate { get; set; }
            public Genre genres { get; set; }
            public Classifications types { get; set; }
            public enum Classifications
            {
                Silver,
                Gold,
                Platinum

            }
        }
        public class Genre
        {
            public byte Id { get; set; }
            public string Name { get; set; }
            public IList<Video> videos { get; set; }
        }
        
        public class RentalData : DbContext
        { 
            public DbSet<Video> videos { get; set; }
            public DbSet<Genre> genres { get; set; }
           
            public RentalData() : base("name=DefaultConnection")
            {
                
            }
        }
        static void Main(string[] args)
        {
        }
    }
}

