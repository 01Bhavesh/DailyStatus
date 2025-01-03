using System.ComponentModel.DataAnnotations;

namespace ViewExercise.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string CustomerName { get; set; }
        public Movie movie { get; set; }
    }
}
