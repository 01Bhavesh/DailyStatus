using System.ComponentModel.DataAnnotations;

namespace WebProject.Model
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
    }
}
