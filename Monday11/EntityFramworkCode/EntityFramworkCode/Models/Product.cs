using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramworkCode.Models
{
    public class Product
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? category { get; set; }
        public string? productName { get; set; }
        public bool? isActive { get; set; }

       
    }
}
