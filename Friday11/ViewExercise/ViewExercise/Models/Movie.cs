using System.ComponentModel.DataAnnotations;

namespace ViewExercise.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public List<Customer> customer { get; set; }
    }
}