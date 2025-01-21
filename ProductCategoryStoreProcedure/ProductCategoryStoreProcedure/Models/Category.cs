using System.ComponentModel.DataAnnotations;

namespace ProductCategoryStoreProcedure.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public IList<Product>? Product { get; set; }
    }
}