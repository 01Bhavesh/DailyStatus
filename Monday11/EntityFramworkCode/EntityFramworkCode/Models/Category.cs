using System.ComponentModel.DataAnnotations;

namespace EntityFramworkCode.Models
{
    public class Category
    {
        [Key]
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public ICollection<Product>? products { get; set; }
        public bool? isActive { get; set; }
    }
}